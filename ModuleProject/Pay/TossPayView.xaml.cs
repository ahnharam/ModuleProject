using Microsoft.Web.WebView2.Core;
using System.Windows;
using System;
using System.Windows.Controls;

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
        }

        private async void OnPayButtonClick(object sender, RoutedEventArgs e)
        {
            await WebViewControl.EnsureCoreWebView2Async(null);
            WebViewControl.Visibility = Visibility.Visible;
            //http://localhost:5173/
            WebViewControl.Source = new Uri("http://localhost:5173/");
        }

        private void WebViewControl_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (WebViewControl.Source.ToString().Contains("success"))
            {
                MessageBox.Show("결제 성공");
            }
            else if (WebViewControl.Source.ToString().Contains("fail"))
            {
                MessageBox.Show("결제 실패");
            }
        }
    }
}
