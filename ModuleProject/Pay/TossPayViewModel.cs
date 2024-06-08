using Microsoft.Web.WebView2.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;


namespace ModuleProject.Pay
{
    public class TossPayViewModel : BindableBase
    {
        private readonly string _clientKey = "test_ck_Z1aOwX7K8mXanq06ME7PryQxzvNP";
        private readonly string _secretKey = "test_sk_Poxy1XQL8Rxw5Gb0o5wXV7nO5Wml";
        private readonly WebView2 _webView; 
        private TossPay tossPay;

        public DelegateCommand PayCommand { get; private set; }

        public TossPayViewModel(WebView2 webView)
        {
            tossPay = new TossPay(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_secretKey}:"))); // 실제 API 키로 대체
            PayCommand = new DelegateCommand(async () => await MakePayment());
        }

        private async Task MakePayment()
        {
            try
            {
                string orderId = "order-12345";
                int amount = 10000;
                string orderName = "테스트 결제";

                string result = await tossPay.ProcessPaymentAsync(orderId, amount, orderName);
                MessageBox.Show($"결제 성공: {result}");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"결제 실패: {ex.Message}");
            }
        }


        public async void PayCommandMethod()
        {
            var client = new RestClient("https://api.tosspayments.com/");
            var request = new RestRequest("v1/payments/confirm", Method.Post);
            string credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_secretKey}:"));
            Debug.WriteLine("credentials: " + credentials);
            request.AddHeader("Authorization", $"Basic {credentials}");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                amount = 10000,
                orderId = Guid.NewGuid().ToString(),
                paymentKey = Guid.NewGuid().ToString(),
            });

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                // Handle success
                Debug.WriteLine("Success: " + response.Content);
            }
            else
            {
                // Handle failure
                Debug.WriteLine("Error: " + response.ErrorException.Message);
            }
        }
    }
}
