﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModuleProject.TossPay
{
    public class TossPay
    {
        private readonly string apiKey;

        public TossPay(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<string> ProcessPaymentAsync(string orderId, int amount, string orderName)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + apiKey);

                var paymentData = new
                {
                    amount,
                    orderId,
                    orderName,
                    successUrl = "http://localhost:5000/success",
                    failUrl = "http://localhost:5000/fail"
                };

                var content = new StringContent(JsonConvert.SerializeObject(paymentData), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://api.tosspayments.com/v1/payments", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    throw new HttpRequestException($"결제 요청 실패: {response.StatusCode}");
                }
            }
        }
    }
}
