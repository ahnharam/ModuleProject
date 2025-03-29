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

namespace MONITOR_UI.View
{
    /// <summary>
    /// MainToolbar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubToolbarView : UserControl
    {
        public SubToolbarView()
        {
            InitializeComponent();
        }

        private void StationSelectComboBox_Selected(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("test");
        }

        private void StationSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Console.WriteLine("test");
        }
    }
}
