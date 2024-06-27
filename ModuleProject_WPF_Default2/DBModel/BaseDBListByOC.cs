using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace SystemEditor.DBModel
{
    public class BaseDBListByOC<T> : ObservableCollection<T>
    {
        public DataSet dataset { get; set; }

        public BaseDBListByOC()
        {
            dataset = new DataSet();
        }

        public BaseDBListByOC(List<T> collection)
        {
            dataset = new DataSet();

            foreach (var model in collection)
            {
                this.Add(model);
            }
        }
    }
}
