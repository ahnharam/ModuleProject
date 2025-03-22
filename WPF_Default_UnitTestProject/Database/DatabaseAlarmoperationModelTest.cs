using NUnit.Framework;
using System;
using System.Data;
using System.Linq;
using System.Configuration;
using ModuleProject_WPF_Default.Models;
using System.Threading.Tasks;

namespace ModuleProject.Tests
{
    [TestFixture]
    public class AlarmoperationCollectionIntegrationTests
    {
        private DatabaseModule _databaseModule;
        private AlarmOperationDBList _collection;

        [SetUp]
        public void SetUp()
        {
            // DatabaseModule 인스턴스를 초기화합니다.
            _databaseModule = DatabaseModule.Instance;

            // 데이터베이스 연결 설정을 수행합니다.
            _databaseModule.ServerSetting("127.0.0.1", "vms_bss_dev", "root", "1234", "3306");

            // AlarmoperationCollection 인스턴스를 초기화합니다.
            _collection = new AlarmOperationDBList();
        }

        [Test]
        public async Task SelectAllDSParsing_ShouldPopulateCollectionFromDatabase()
        {
            // Arrange
            var query = _collection.SelectAllQuery();

            // 데이터베이스와 연결
            bool isConnected = _databaseModule.Connect();
            Assert.That(isConnected, Is.True, "Database should be connected.");

            // 데이터베이스에서 데이터 가져오기
            DataTable dataTable = await _databaseModule.SelectAsync(query);

            // DataTable이 비어 있지 않은지 확인
            Assert.That(dataTable, Is.Not.Null, "DataTable should not be null.");
            Assert.That(dataTable.Rows.Count, Is.GreaterThan(0), "DataTable should contain rows.");

            // DataTable을 데이터셋으로 변환
            _collection.dataset.Tables.Clear();
            _collection.dataset.Tables.Add(dataTable);

            // Act
            _collection.SelectAllDSParsing();

            // 가져온 첫 번째 모델을 검증합니다.
            var firstModel = _collection[0];
            Assert.That(firstModel, Is.Not.Null, "First model should not be null.");
            Assert.That(firstModel.no, Is.GreaterThan(0), "First model's No should be greater than 0.");
            Assert.That(firstModel.alarmname, Is.Not.Null.And.Not.Empty, "First model's Alarmname should not be null or empty.");
        }

        [Test]
        public async Task GetByNo_ShouldReturnCorrectModel()
        {
            // Arrange
            var query = _collection.SelectAllQuery();
            bool isConnected = _databaseModule.Connect();
            Assert.That(isConnected, Is.True, "Database should be connected.");
            DataTable dataTable = await _databaseModule.SelectAsync(query);
            Assert.That(dataTable, Is.Not.Null, "DataTable should not be null.");
            _collection.dataset.Tables.Clear();
            _collection.dataset.Tables.Add(dataTable);
            _collection.SelectAllDSParsing();

            // Act
            var model = _collection.GetByNo(1); // No가 1인 모델을 검색합니다. 데이터베이스의 실제 데이터에 따라 조정할 수 있습니다.

            // Assert
            Assert.That(model, Is.Not.Null, "Model with No = 1 should be present in the collection.");
            Assert.That(model.no, Is.EqualTo(1), "Model's No should be equal to 1.");
        }
    }
}
