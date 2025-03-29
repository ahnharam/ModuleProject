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

namespace DashBoard.View
{
    /// <summary>
    /// ScreenView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ScreenView : UserControl
    {
        public ScreenView()
        {
            InitializeComponent();
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            if (e.Source is TreeViewItem)
            {
                TreeViewItem data = e.Source as TreeViewItem;

                if (data.IsSelected == true) return;
                else data.IsSelected = true;
            }
        }
    }
}
