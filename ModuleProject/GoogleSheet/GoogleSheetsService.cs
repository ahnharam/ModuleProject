using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.GoogleSheet
{
    public class GoogleSheetsService : IGoogleSheetsService
    {
        private SheetsService _sheetsService;
        private string _spreadsheetId = "1s5aeUgnHN26VyK7gxgW0ob2h8K65aB5jD_Mo587VMP8";
        private string _sheetName = "Test1";
        private readonly string credentialPath = "Config\\test-418801-ecb6e8848fb5.json"; // 출력된 파일 이름

        public GoogleSheetsService()
        {
            GoogleCredential credential;
            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.Spreadsheets);
            }

            _sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "WpfGoogleSheetsApp",
            });
        }

        public async Task<IList<IList<object>>> ReadSheetAsync()
        {
            var range = $"{_sheetName}!A1:D10";
            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
            try
            {
                var response = await request.ExecuteAsync();
                return response.Values;
            }
            catch (GoogleApiException ex)
            {
                Debug.WriteLine("Google API 오류: " + ex.Message);
                throw;
            }
        }
    }

}
