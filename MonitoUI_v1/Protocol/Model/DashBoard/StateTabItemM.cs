using Prism.Mvvm;
using Protocol.Model.Dashboard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Protocol.Model.Dashboard
{
    public class StateTabItemM : BindableBase
    {
        private string stateTabItemHeader;
        public string StateTabItemHeader
        {
            get { return stateTabItemHeader; }
            set { SetProperty(ref stateTabItemHeader, value); }
        }

        private UserControl stateTabItemContent;
        public UserControl StateTabItemContent
        {
            get { return stateTabItemContent; }
            set { SetProperty(ref stateTabItemContent, value); }
        }

        public StateTabItemM(string header, UserControl content)
        {
            this.StateTabItemHeader = header;
            this.StateTabItemContent = content;
        }
    }

    public class StateTabItemList : ObservableCollection<StateTabItemM>
    {
    }
}
