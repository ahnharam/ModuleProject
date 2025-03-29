using System.Data;

namespace Protocol.Model.Config
{
    public class UserStateModel : BaseM
    {
        private DataTable userStateTable;

        public DataTable UserStateTable
        {
            get { return userStateTable; }
            set { SetProperty(ref userStateTable, value); }
        }
    }
}