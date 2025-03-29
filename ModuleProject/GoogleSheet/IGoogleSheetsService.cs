using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.GoogleSheet
{
    public interface IGoogleSheetsService
    {
        /// <summary>
        /// 구글 시트에서 지정된 범위의 데이터를 읽습니다.
        /// </summary>
        /// <returns>시트의 행 목록 (각 행은 object 리스트)</returns>
        Task<IList<IList<object>>> ReadSheetAsync();
    }
}
