using Protocol.Model.Dashboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DashBoard.View
{
    /// <summary>
    /// StateView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StateView : UserControl
    {
        TabControl tabchanger { get; set; }

        public StateView()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine(sender.GetType());

            //if (sender is TabControl)
            //{
            //    TabControl headerName = sender as TabControl;
            //    Debug.WriteLine(headerName.SelectedItem);
            //    if(headerName.SelectedItem != null)
            //    {

            //        StateTabItemM header = headerName.SelectedItem as StateTabItemM;
            //        if(header != null)
            //        {

            //            switch (header.StateTabItemHeader)
            //            {
            //                case "power":
            //                    Debug.WriteLine("power header : " + header);
            //                    header.StateTabItemContent = new UserControl();
            //                    break;
            //                case "control":
            //                    Debug.WriteLine("control header : " + header);
            //                    header.StateTabItemContent = new ControlView();
            //                    break;
            //                default:
            //                    Debug.WriteLine("default header : " + header);
            //                    break;
            //            }
            //            Debug.WriteLine(header.ToString());
            //        }
            //    }
            //}
        }

        private void TabControl_Initialized(object sender, EventArgs e)
        {

        }
    }
}
