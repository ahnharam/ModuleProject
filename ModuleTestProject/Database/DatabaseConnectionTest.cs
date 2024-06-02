using NUnit.Framework;
using Moq;
using System.Data;
using ModuleProject.Database;

namespace ModuleTestProject.Database
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        // 올바른 연결을 위한 문자열
        private string _validConnectionString = "SERVER=127.0.0.1;DATABASE=mysql;UID=root;PWD=1234;";

        // 잘못된 연결을 위한 문자열
        // 의도적인 오류 발생
        private string _invalidConnectionString = "SERVER=127.0.0.1;DATABASE=invalid;UID=root;PWD=wrongpassword;";

        [Test]
        public void Open_ValidConnectionString_ShouldOpenConnection()
        {
            // 올바른 DB 연결을 위한 인스턴스 생성
            var dbConnection = new DatabaseConnection(_validConnectionString);

            // DB 연결 시 예외 발생 여부 확인 - 예외 발생x
            Assert.DoesNotThrow(() => dbConnection.Open());
            Assert.That(dbConnection.Connection.State, Is.EqualTo(ConnectionState.Open));
            dbConnection.Close();
        }

        [Test]
        public void Open_InvalidConnectionString_ShouldThrowDatabaseConnectionException()
        {
            // 잘못된 DB 연결을 위한 인스턴스 생성
            var dbConnection = new DatabaseConnection(_invalidConnectionString);

            // Open을 호출 시 예외 발생 여부 확인 - 예외 발생o
            Assert.Throws<DatabaseConnectionException>(() => dbConnection.Open());
        }

        [Test]
        public void Close_OpenConnection_ShouldCloseConnection()
        {
            // 올바른 DB 연결을 위한 인스턴스 생성
            var dbConnection = new DatabaseConnection(_validConnectionString);

            // Open 호출 이후 실제로 열렸는지 확인
            dbConnection.Open();
            Assert.That(dbConnection.Connection.State, Is.EqualTo(ConnectionState.Open));

            // Close 호출 이후 실제로 닫혔는지 확인
            dbConnection.Close();
            Assert.That(dbConnection.Connection.State, Is.EqualTo(ConnectionState.Closed));
        }

        [Test]
        public void Dispose_ShouldDisposeConnection()
        {
            // 올바른 DB 연결을 위한 인스턴스 생성
            var dbConnection = new DatabaseConnection(_validConnectionString);
            dbConnection.Open();

            // Dispose 호출 시 예외 발생 여부 확인 -> 예외 발생x
            Assert.DoesNotThrow(() => dbConnection.Dispose());
        }
    }
}
