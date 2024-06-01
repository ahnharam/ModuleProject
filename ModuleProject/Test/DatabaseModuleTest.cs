using Moq;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using ModuleProject.Utils;
using Mysqlx.Crud;

namespace ModuleProject.Tests
{
    [TestFixture]
    public class DatabaseModuleTests
    {
        private Mock<MySqlConnection> _mockConnection;
        private Mock<MySqlDataAdapter> _mockDataAdapter;
        private Mock<MySqlCommand> _mockCommand;
        private DatabaseModule _databaseModule;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<MySqlConnection>();
            _mockDataAdapter = new Mock<MySqlDataAdapter>();
            _mockCommand = new Mock<MySqlCommand>();
            _databaseModule = DatabaseModule.Instance;
            _databaseModule.Conn = _mockConnection.Object;
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

            // DataAdapter의 Fill 메서드를 모킹하여 expectedTable을 반환하도록 설정
            _mockDataAdapter
                .Setup(da => da.Fill(It.IsAny<DataTable>()))
                .Callback<DataTable>(dt => dt.Merge(expectedTable));

            // MySqlConnection이 Open 상태임을 모킹
            _mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Open);

            // MySqlCommand의 매개변수화된 쿼리 설정
            _mockCommand.Setup(cmd => cmd.CommandText).Returns(sql);
            _mockCommand.Setup(cmd => cmd.Connection).Returns(_mockConnection.Object);

            // Arrange - 모킹된 DataAdapter가 새로운 인스턴스를 반환하도록 설정
            _mockDataAdapter
                .Setup(da => da.SelectCommand)
                .Returns(_mockCommand.Object);

            // Act
            DataTable result = await _databaseModule.SelectAsync(sql);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedTable.Rows.Count, result.Rows.Count);
            Assert.AreEqual(expectedTable.Columns.Count, result.Columns.Count);
            for (int i = 0; i < expectedTable.Rows.Count; i++)
            {
                for (int j = 0; j < expectedTable.Columns.Count; j++)
                {
                    Assert.AreEqual(expectedTable.Rows[i][j], result.Rows[i][j]);
                }
            }
        }

        [Test]
        public async Task SelectAsync_ShouldReturnNull_WhenConnectionIsClosedAndReconnectFails()
        {
            // Arrange
            string sql = "SELECT * FROM Users";

            // MySqlConnection이 Closed 상태임을 모킹
            _mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Closed);

            // DatabaseModule의 Connect 메서드가 false를 반환하도록 설정
            var mockDatabaseModule = new Mock<DatabaseModule> { CallBase = true };
            mockDatabaseModule.Setup(db => db.Connect()).Returns(false);
            mockDatabaseModule.Object.Conn = _mockConnection.Object;

            // Act
            DataTable result = await mockDatabaseModule.Object.SelectAsync(sql);

            // Assert
            Assert.IsNull(result);
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
            var ex = Assert.Throws<DatabaseConnectionException>(() => _databaseModule.ServerSetting(serverIp, database, uid, pwd, serverPort));
            Assert.AreEqual("Server IP cannot be null or empty.", ex.Message);
        }

        [Test]
        public void Connect_ShouldReturnFalse_WhenConnectionFails()
        {
            // Arrange
            _mockConnection.Setup(conn => conn.Open()).Throws(new Exception("Connection failed"));

            // Act
            bool result = _databaseModule.Connect();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Disconnect_ShouldCloseConnection_WhenConnectionIsOpen()
        {
            // Arrange
            _mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Open);

            // Act
            _databaseModule.Disconnect();

            // Assert
            _mockConnection.Verify(conn => conn.Close(), Times.Once);
        }

        // 기타 테스트 케이스들...
    }
}
