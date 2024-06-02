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
        // 테스트할 클래스 선언
        private DatabaseModule _databaseModule;

        [SetUp]
        public void Setup()
        {
            // 기본 설정
            _databaseModule = DatabaseModule.Instance;
            _databaseModule.ServerSetting("127.0.0.1", "mysql", "root", "1234", "3306");
        }

        [Test]
        public void ServerSetting_ShouldSetProperties()
        {
            // Setup에서 설정한 값이 제대로 프로퍼티를 통해 설정되었는지 확인
            Assert.That(_databaseModule.ServerIp, Is.EqualTo("127.0.0.1"));
            Assert.That(_databaseModule.Database, Is.EqualTo("mysql"));
            Assert.That(_databaseModule.Uid, Is.EqualTo("root"));
            Assert.That(_databaseModule.Pwd, Is.EqualTo("1234"));
            Assert.That(_databaseModule.ServerPort, Is.EqualTo("3306"));
        }

        [Test]
        public void CheckServerSetting_MissingServerIp_ShouldThrowException()
        {
            // 서버 아이피가 없을 경우 오류 발생을 위한 초기화
            _databaseModule.ServerIp = null;
            // CheckServerSetting 메서드가 ServerIp가 null일 때 DatabaseConnectionException 예외 발생
            Assert.Throws<DatabaseConnectionException>(() => _databaseModule.CheckServerSetting());
        }

        [Test]
        public async Task SelectAsync_ValidSql_ShouldReturnDataTable()
        {
            // 검색할 테이블에 대한 SQL문 생성
            var sql = "SELECT * FROM user";
            // _databaseModule에 있는 SelectAsync를 사용하여 Select 진행 및 결과 반환
            var result = await _databaseModule.SelectAsync(sql);

            // 결과가 Null 값인지 확인
            Assert.That(result, Is.Not.Null);
            // 결과가 DataTable 형식인지 확인
            Assert.That(result, Is.InstanceOf<DataTable>());
        }

        [Test]
        public void InsertOrUpdate_ValidSql_ShouldExecuteWithoutException()
        {
            // 삽입할 테이블에 대한 SQL문 생성
            var sql = "INSERT INTO user (column1) VALUES ('value1')";

            // _databaseModule에 있는 InsertOrUpdateAsync 메서드를 사용하여 SQL 쿼리를 실행
            // 쿼리 실행 중 예외가 발생하지 않는지 확인
            Assert.DoesNotThrowAsync(() => _databaseModule.InsertOrUpdateAsync(sql));
        }

        [Test]
        public void Disconnect_ShouldCloseConnection()
        {
            // _databaseModule의 Disconnect 메서드를 호출하여 데이터베이스 연결을 닫음
            _databaseModule.Disconnect();

            // 리플렉션을 사용하여 _databaseModule의 비공개 필드인 _dbConnection에 접근
            var connection = _databaseModule.GetType()
                .GetField("_dbConnection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(_databaseModule) as IDatabaseConnection;

            // 데이터베이스 연결 상태가 Closed인지 확인
            Assert.That(connection.Connection.State, Is.EqualTo(ConnectionState.Closed));
        }
    }
}
