using System;
using System.Collections.Generic;
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
using PoleServerWithUI.Utils;
using PoleServerWithUI.ViewModel;

namespace PoleServerWithUI.View
{
    /// <summary>
    /// DeviceStateView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeviceStateView : UserControl
    {
        public DeviceStateView()
        {
            InitializeComponent();
        }

        private void ListBox_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scrollViewer &&
                    Math.Abs(e.ExtentHeightChange) > 0.0)
            {
                scrollViewer.ScrollToBottom();
            }
        }

        private void ItemsControl_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Console.WriteLine("check");
        }

        private void ItemsControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            Console.WriteLine("size changed check");
        }

        private void ItemsControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            Console.WriteLine("ItemsControl_DataContextChanged changed check");
        }
    }
}
