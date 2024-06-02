using NUnit.Framework;
using Moq;
using System.Data;
using ModuleProject.Database;

namespace ModuleProject.Database
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private string _validConnectionString = "SERVER=127.0.0.1;DATABASE=mysql;UID=root;PWD=1234;";
        private string _invalidConnectionString = "SERVER=127.0.0.1;DATABASE=invalid;UID=root;PWD=wrongpassword;";

        [Test]
        public void Open_ValidConnectionString_ShouldOpenConnection()
        {
            var dbConnection = new DatabaseConnection(_validConnectionString);
            Assert.DoesNotThrow(() => dbConnection.Open());
            Assert.That(dbConnection.Connection.State, Is.EqualTo(ConnectionState.Open));
            dbConnection.Close();
        }

        [Test]
        public void Open_InvalidConnectionString_ShouldThrowDatabaseConnectionException()
        {
            var dbConnection = new DatabaseConnection(_invalidConnectionString);
            Assert.Throws<DatabaseConnectionException>(() => dbConnection.Open());
        }

        [Test]
        public void Close_OpenConnection_ShouldCloseConnection()
        {
            var dbConnection = new DatabaseConnection(_validConnectionString);
            dbConnection.Open();
            dbConnection.Close();
            Assert.That(dbConnection.Connection.State, Is.EqualTo(ConnectionState.Closed));
        }

        [Test]
        public void Dispose_ShouldDisposeConnection()
        {
            var dbConnection = new DatabaseConnection(_validConnectionString);
            dbConnection.Open();
            Assert.DoesNotThrow(() => dbConnection.Dispose());
        }
    }
}
