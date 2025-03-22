using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SystemEditor.DBModel
{
    public interface IDBQuery
    {
        void SetAutoIncrementIndex(long autoincrementindex);
        string InsertQuery();
        string[] InsertSubQuery();
        string[] UpdateQuery();
        string[] DeleteQueryList();
    }
}
