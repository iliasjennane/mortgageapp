using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using mortgage.mortgageui.Models;

namespace mortgageui.Services
{
    public class AverageRateApiService
    {
        public HttpClient _httpClient;
        private string _OcpApimSubscriptionKey;
        private string _OcpApimTrace;

        public AverageRateApiService(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _OcpApimSubscriptionKey = configuration.GetValue<string>("ocpApimSubscriptionKey");
            _OcpApimTrace = configuration.GetValue<string>("ocpApimTrace");

        }
        public Mortgage GetMortgageFixedRate(MortgageRequestor requestor)
        {
            
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            
            var requestBody = new StringContent(JsonSerializer.Serialize(requestor, jsonSerializerOptions),Encoding.UTF8,"application/json");
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _OcpApimSubscriptionKey);
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Trace", _OcpApimTrace);
            var response =  _httpClient.PostAsync("fixedrates/Mortgage/1.0", requestBody).Result;
            //response.EnsureSuccessStatusCode();

            var reponseContent =  response.Content.ReadAsStringAsync().Result;
            var averageMortgageRate =  JsonSerializer.Deserialize<Mortgage>(reponseContent);

            
            return averageMortgageRate;
            
        }
        public Mortgage GetMortgageVariableRate(MortgageRequestor requestor)
        {
            
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            
            var requestBody = new StringContent(JsonSerializer.Serialize(requestor, jsonSerializerOptions),Encoding.UTF8,"application/json");
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _OcpApimSubscriptionKey);
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Trace", _OcpApimTrace);
            var response =  _httpClient.PostAsync("variablerates/Mortgage/1.0", requestBody).Result;
            //response.EnsureSuccessStatusCode();

            var reponseContent =  response.Content.ReadAsStringAsync().Result;
            var averageMortgageRate =  JsonSerializer.Deserialize<Mortgage>(reponseContent);

            
            return averageMortgageRate;
            
        }
        public Mortgage GetMortgageAverageRate(MortgageRequestor requestor)
        {
            
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            
            var requestBody = new StringContent(JsonSerializer.Serialize(requestor, jsonSerializerOptions),Encoding.UTF8,"application/json");
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _OcpApimSubscriptionKey);
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Trace", _OcpApimTrace);
            var response =  _httpClient.PostAsync("fixedrates/Average/1.0", requestBody).Result;
            //response.EnsureSuccessStatusCode();

            var reponseContent =  response.Content.ReadAsStringAsync().Result;
            var averageMortgageRate =  JsonSerializer.Deserialize<Mortgage>(reponseContent);

            
            return averageMortgageRate;
            
        }

    }
}
