using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace ModuleProject.Pay
{
    /// <summary>
    /// Interaction logic for TossPayView
    /// </summary>
    public partial class TossPayView : UserControl
    {
        public TossPayView()
        {
            InitializeComponent();
            //InitializeWebView();
        }
        //private async void InitializeWebView()
        //{
        //    var currentDirectory = Directory.GetCurrentDirectory();
        //    var htmlFilePath = Path.Combine(currentDirectory, "payment_widget.html");

        //    if (File.Exists(htmlFilePath))
        //    {
        //        await webView.EnsureCoreWebView2Async(null);
        //        webView.CoreWebView2.Navigate(htmlFilePath);
        //    }
        //    else
        //    {
        //        MessageBox.Show("HTML 파일을 찾을 수 없습니다.");
        //    }
        //}
    }
}
