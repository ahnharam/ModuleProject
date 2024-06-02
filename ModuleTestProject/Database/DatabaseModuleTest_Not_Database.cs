using NUnit.Framework;
using ModuleProject.Interface;
using ModuleProject.Database;
using ModuleProject.Utils;
using Moq;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Reflection;

namespace ModuleTestProject.Database
{
    /// <summary>
    /// 결론 : 해당 테스트 코드는 의미가 없음
    /// 이유 :  1. 데이터베이스에 대한 테스트는 MySqlConnection과 MySqlCommand 에 대한 Mock을 만들 수 없음
    ///         2. 이로 인해 실제 데이터베이스와 연결하지 않으면 테스트가 불가능
    ///         3. 이는 결국 단위 테스트를 진행할 수 없고 통합테스트만 할 수 있음
    ///         4. 따라서 실제 데이터베이스와 연결하여 진행하는 테스트 코드만 있으면 됨
    /// </summary>



    // 팩토리 메서드를 추가하여 테스트 시 Mocking이 가능하도록 함
    // DatabaseModule 클래스에 넣어서 사용가능 / 아래 작성한 테스트 코드가 의미가 없으므로 주석처리
    //public virtual MySqlCommand CreateCommand(string commandText, MySqlConnection connection)
    //{
    //    return new MySqlCommand(commandText, connection);
    //}

    //public virtual IMySqlDataAdapter CreateDataAdapter(MySqlCommand command)
    //{
    //    return new MySqlDataAdapterWrapper(command);
    //}

    //[TestFixture]
    //public class DatabaseModuleTest_Not_Database
    //{
    //    private Mock<IDatabaseConnection> _mockDbConnection;
    //    private Mock<IMySqlDataAdapter> _mockMySqlDataAdapter;
    //    private DatabaseModule _databaseModule;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        _mockDbConnection = new Mock<IDatabaseConnection>();
    //        _mockMySqlDataAdapter = new Mock<IMySqlDataAdapter>();

    //        _databaseModule = new Mock<DatabaseModule> { CallBase = true }.Object;
    //        _databaseModule.ServerSetting("127.0.0.1", "testdb", "user", "password", "3306");

    //        var connectionString = $"SERVER=127.0.0.1; DATABASE=testdb; UID=user; PWD=password; PORT=3306;";
    //        var realConnection = new MySqlConnection(connectionString);

    //        // Setting up the mock database connection
    //        _mockDbConnection.Setup(db => db.Connection).Returns(realConnection);

    //        // Using reflection to set the private _dbConnection field
    //        typeof(DatabaseModule).GetField("_dbConnection", BindingFlags.NonPublic | BindingFlags.Instance)
    //            .SetValue(_databaseModule, _mockDbConnection.Object);
    //    }

    //    [Test]
    //    public void ServerSetting_ShouldSetProperties()
    //    {
    //        _databaseModule.ServerSetting("127.0.0.1", "testdb", "user", "password", "3306");
    //        Assert.That(_databaseModule.ServerIp, Is.EqualTo("127.0.0.1"));
    //        Assert.That(_databaseModule.Database, Is.EqualTo("testdb"));
    //        Assert.That(_databaseModule.Uid, Is.EqualTo("user"));
    //        Assert.That(_databaseModule.Pwd, Is.EqualTo("password"));
    //        Assert.That(_databaseModule.ServerPort, Is.EqualTo("3306"));
    //    }

    //    [Test]
    //    public void CheckServerSetting_MissingServerIp_ShouldThrowException()
    //    {
    //        _databaseModule.ServerIp = null;
    //        Assert.Throws<DatabaseConnectionException>(() => _databaseModule.CheckServerSetting());
    //    }

    //    [Test]
    //    public async Task SelectAsync_ValidSql_ShouldReturnDataTable()
    //    {
    //        var connectionString = $"SERVER=127.0.0.1; DATABASE=mysql; UID=root; PWD=1234; PORT=3306;";
    //        var realConnection = new MySqlConnection(connectionString);

    //        _mockDbConnection.Setup(db => db.Connection).Returns(realConnection);

    //        _mockMySqlDataAdapter.Setup(adapter => adapter.Fill(It.IsAny<DataTable>())).Returns(1);

    //        // 실제 데이터베이스 명령을 설정
    //        var realCommand = new MySqlCommand("SELECT * FROM user", realConnection);
    //        var realAdapter = new MySqlDataAdapterWrapper(realCommand);

    //        var mockDatabaseModule = new Mock<DatabaseModule> { CallBase = true };
    //        mockDatabaseModule.Setup(m => m.CreateCommand(It.IsAny<string>(), It.IsAny<MySqlConnection>())).Returns(realCommand);
    //        mockDatabaseModule.Setup(m => m.CreateDataAdapter(It.IsAny<MySqlCommand>())).Returns(realAdapter);

    //        typeof(DatabaseModule).GetField("_dbConnection", BindingFlags.NonPublic | BindingFlags.Instance)
    //            .SetValue(mockDatabaseModule.Object, _mockDbConnection.Object);

    //        var sql = "SELECT * FROM user";
    //        var result = await mockDatabaseModule.Object.SelectAsync(sql);

    //        Assert.That(result, Is.Not.Null);
    //        Assert.That(result, Is.InstanceOf<DataTable>());
    //    }

    //    [Test]
    //    public void InsertOrUpdate_ValidSql_ShouldExecuteWithoutException()
    //    {
    //        _mockDbConnection.Setup(db => db.Connection).Returns(new MySqlConnection());
    //        var sql = "INSERT INTO test_table (column1) VALUES (value1)";
    //        Assert.DoesNotThrowAsync(() => _databaseModule.InsertOrUpdateAsync(sql));
    //    }

    //    [Test]
    //    public void Disconnect_ShouldCloseConnection()
    //    {
    //        var connectionString = $"SERVER=127.0.0.1; DATABASE=testdb; UID=user; PWD=password; PORT=3306;";
    //        var realConnection = new MySqlConnection(connectionString);

    //        _mockDbConnection.Setup(db => db.Connection).Returns(realConnection);
    //        _databaseModule.Disconnect();
    //        _mockDbConnection.Verify(db => db.Close(), Times.Once);
    //    }
    //}
}
