using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Controls;

namespace Protocol.Model.Dashboard
{
    public class PanelM : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int use;

        public int Use
        {
            get { return use; }
            set { SetProperty(ref use, value); }
        }

        private int panel;

        public int Panel
        {
            get { return panel; }
            set { SetProperty(ref panel, value); }
        }

        private int panelNo;

        public int PanelNo
        {
            get { return panelNo; }
            set { SetProperty(ref panelNo, value); }
        }

        private string height;

        public string Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

        private UserControl userControl;

        public UserControl UserControl
        {
            get { return userControl; }
            set { SetProperty(ref userControl, value); }
        }

        public PanelM()
        { }

        public PanelM(DataRow dataRow) : base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            try
            {

            this.No = ConvertInt(dataRow, "no");
            this.Name = ConvertString(dataRow, "name");
            this.Use = ConvertInt(dataRow, "use");
            this.Panel = ConvertInt(dataRow, "panel");
            this.PanelNo = ConvertInt(dataRow, "panelno");
            }
                catch(Exception e)
            {
                Debug.WriteLine("Create PanelM Error : " + e.Message);
            }
        }
    }

    public class PanelList : BaseList<PanelM>
    { }
}