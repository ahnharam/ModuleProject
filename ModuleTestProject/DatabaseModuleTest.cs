using Moq;
using NUnit.Framework;
using System.Data;
using System.Threading.Tasks;
using ModuleProject.Utils;
using MySql.Data.MySqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleProject.Interface;
using NUnit.Framework.Legacy;
using System;

namespace ModuleProject.Tests
{
    [TestFixture]
    public class DatabaseModuleTests
    {
        private Mock<IDatabaseConnection> _mockDbConnection;
        private DatabaseModule _databaseModule;

        [SetUp]
        public void Setup()
        {
            _mockDbConnection = new Mock<IDatabaseConnection>();
            _databaseModule = DatabaseModule.Instance;

            // 싱글톤 인스턴스 초기화
            _databaseModule.ServerSetting("127.0.0.1", "mysql", "root", "root", "3306");
            var privateObject = new PrivateObject(_databaseModule);
            privateObject.SetField("_dbConnection", _mockDbConnection.Object);
        }

        [Test]
        public async Task SelectAsync_ShouldReturnDataTable_WhenQueryIsValid()
        {
            // Arrange
            string sql = "SELECT * FROM Users";
            DataTable expectedTable = new DataTable();
            expectedTable.Columns.Add("Id", typeof(int));
            expectedTable.Columns.Add("Name", typeof(string));
            expectedTable.Rows.Add(1, "John Doe");

            var mockConnection = new Mock<MySqlConnection>();
            _mockDbConnection.Setup(conn => conn.Connection).Returns(mockConnection.Object);

            var mockDataAdapter = new Mock<MySqlDataAdapter>();
            mockDataAdapter.Setup(adapter => adapter.Fill(It.IsAny<DataTable>()))
                .Callback<DataTable>(dt => dt.Merge(expectedTable));

            // Act
            DataTable result = await _databaseModule.SelectAsync(sql);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(expectedTable.Rows.Count, result.Rows.Count);
            ClassicAssert.AreEqual(expectedTable.Columns.Count, result.Columns.Count);
            for (int i = 0; i < expectedTable.Rows.Count; i++)
            {
                for (int j = 0; j < expectedTable.Columns.Count; j++)
                {
                    ClassicAssert.AreEqual(expectedTable.Rows[i][j], result.Rows[i][j]);
                }
            }
        }

        [Test]
        public async Task SelectAsync_ShouldReturnNull_WhenConnectionIsClosedAndReconnectFails()
        {
            // Arrange
            string sql = "SELECT * FROM Users";
            var mockConnection = new Mock<MySqlConnection>();
            _mockDbConnection.Setup(conn => conn.Connection).Returns(mockConnection.Object);
            mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Closed);

            _mockDbConnection.Setup(db => db.Open()).Throws(new Exception("Connection failed"));

            // Act
            DataTable result = await _databaseModule.SelectAsync(sql);

            // Assert
            ClassicAssert.IsNull(result);
        }

        [Test]
        public void ServerSetting_ShouldThrowException_WhenServerIpIsEmpty()
        {
            // Arrange
            string serverIp = "";
            string database = "TestDB";
            string uid = "root";
            string pwd = "password";
            string serverPort = "3306";

            // Act & Assert
            var ex = ClassicAssert.Throws<DatabaseConnectionException>(() => _databaseModule.ServerSetting(serverIp, database, uid, pwd, serverPort));
            ClassicAssert.AreEqual("Server IP cannot be null or empty.", ex.Message);
        }

        [Test]
        public void Connect_ShouldReturnFalse_WhenConnectionFails()
        {
            // Arrange
            _mockDbConnection.Setup(conn => conn.Open()).Throws(new Exception("Connection failed"));

            // Act
            bool result = _databaseModule.Connect();

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Disconnect_ShouldCloseConnection_WhenConnectionIsOpen()
        {
            // Arrange
            var mockConnection = new Mock<MySqlConnection>();
            _mockDbConnection.Setup(conn => conn.Connection).Returns(mockConnection.Object);
            mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Open);

            // Act
            _databaseModule.Disconnect();

            // Assert
            mockConnection.Verify(conn => conn.Close(), Times.Once);
        }
    }
}
