using System.Data;

namespace Protocol.Model.Config
{
    public class SnsModel : BaseM
    {
        private DataTable snsTable;

        public DataTable SnsTable
        {
            get { return snsTable; }
            set { SetProperty(ref snsTable, value); }
        }
    }
}