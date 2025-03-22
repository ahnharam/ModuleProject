using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace ModuleProject_WPF_Default.Models
{
    public class BaseDBList<T> : ObservableCollection<T>
    {
        public DataSet dataset { get; set; }

        public BaseDBList()
        {
            dataset = new DataSet();
        }

        public BaseDBList(List<T> collection)
        {
            {
                dataset = new DataSet();

                foreach (var model in collection)
                {
                    this.Add(model);
                }
            }
        }
    }
}
