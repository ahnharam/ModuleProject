using NUnit.Framework;
using ModuleProject.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using ModuleProject.Interface;

namespace ModuleTestProject.Database
{
    [TestFixture]
    public class DatabaseModuleTest
    {
        private DatabaseModule _databaseModule;

        [SetUp]
        public void Setup()
        {
            _databaseModule = DatabaseModule.Instance;
            _databaseModule.ServerSetting("127.0.0.1", "mysql", "root", "1234", "3306");
        }

        [Test]
        public void ServerSetting_ShouldSetProperties()
        {
            Assert.That(_databaseModule.ServerIp, Is.EqualTo("127.0.0.1"));
            Assert.That(_databaseModule.Database, Is.EqualTo("mysql"));
            Assert.That(_databaseModule.Uid, Is.EqualTo("root"));
            Assert.That(_databaseModule.Pwd, Is.EqualTo("1234"));
            Assert.That(_databaseModule.ServerPort, Is.EqualTo("3306"));
        }

        [Test]
        public void CheckServerSetting_MissingServerIp_ShouldThrowException()
        {
            _databaseModule.ServerIp = null;
            Assert.Throws<DatabaseConnectionException>(() => _databaseModule.CheckServerSetting());
        }

        [Test]
        public async Task SelectAsync_ValidSql_ShouldReturnDataTable()
        {
            var sql = "SELECT * FROM user";
            var result = await _databaseModule.SelectAsync(sql);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
        }

        [Test]
        public void InsertOrUpdate_ValidSql_ShouldExecuteWithoutException()
        {
            var sql = "INSERT INTO user (column1) VALUES ('value1')";
            Assert.DoesNotThrowAsync(() => _databaseModule.InsertOrUpdateAsync(sql));
        }

        [Test]
        public void Disconnect_ShouldCloseConnection()
        {
            _databaseModule.Disconnect();
            var connection = _databaseModule.GetType()
                .GetField("_dbConnection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(_databaseModule) as IDatabaseConnection;

            Assert.That(connection.Connection.State, Is.EqualTo(ConnectionState.Closed));
        }
    }
}
