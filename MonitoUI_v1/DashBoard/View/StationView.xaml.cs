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
    /// StationView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StationView : UserControl
    {
        public string Title { get; set; }

        public TextBox ComboboxSearchData { get; set; }

        public StationView()
        {
            InitializeComponent();
        }
        public StationView(string Title)
        {
            InitializeComponent();
            this.Title = Title;
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            if(e.Source is TreeViewItem)
            {
                TreeViewItem data = e.Source as TreeViewItem;

                if (data.IsSelected == true) return;
                else data.IsSelected = true;
            }
        }

        private void StationSearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            Debug.WriteLine("textinput");
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(StationList.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {
                
                Debug.WriteLine("StationSearchTextBox.Text : " + StationSearchTextBox.Text);
                Debug.WriteLine("text : " + (string)o);
                if (String.IsNullOrEmpty(StationSearchTextBox.Text)) return true;
                else
                {
                    if (((string)o).Contains(StationSearchTextBox.Text)) return true;
                    else return false;
                }
            });

            itemsViewOriginal.Refresh();

            // if datasource is a DataView, then apply RowFilter as below and replace above logic with below one
            /* 
             DataView view = (DataView) Cmb.ItemsSource; 
             view.RowFilter = ("Name like '*" + Cmb.Text + "*'"); 
            */
        }

        private void StationSearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(StationList.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {

                Debug.WriteLine("StationSearchTextBox.Text : " + StationSearchTextBox.Text);
                Debug.WriteLine("text : " + (string)o);
                if (String.IsNullOrEmpty(StationSearchTextBox.Text)) return true;
                else
                {
                    if (((string)o).Contains(StationSearchTextBox.Text)) return true;
                    else return false;
                }
            });

            itemsViewOriginal.Refresh();
        }
        private void StationSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(StationList.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {

                Debug.WriteLine("StationSearchTextBox.Text : " + StationSearchTextBox.Text);
                Debug.WriteLine("text : " + (string)o);
                if (String.IsNullOrEmpty(StationSearchTextBox.Text)) return true;
                else
                {
                    if (((string)o).Contains(StationSearchTextBox.Text)) return true;
                    else return false;
                }
            });

            itemsViewOriginal.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = ((Button)e.Source).Content.ToString() ;
            Debug.WriteLine(content);
            StationSearchTextBox.Text = content;
        }

    }
}
