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
using System.Windows.Shapes;

namespace Protocol.Message
{
    /// <summary>
    /// MessageBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ErrorMessageBox : Window
    {
        public string ErrorTitle { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorMessageBox()
        {
            InitializeComponent();
            DataContext = this;
            ErrorTitle = "title";
            ErrorMessage = "message";
        }
        public ErrorMessageBox(string title, string message)
        {
            InitializeComponent();
            DataContext = this;
            ErrorTitle = title;
            ErrorMessage = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
