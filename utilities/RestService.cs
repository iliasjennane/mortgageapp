using System.Net.Http;
using System.Net.Http.Headers;
namespace mortgageui.utilities
{
    public class RestService<T>
    {
        private readonly ILogger<RateAverageSerice> _logger;
        private static readonly HttpClient client = new HttpClient();
        public RestService(ILogger<RateAverageSerice> logger)
        {
            _logger = logger;
        }

        Task<T> InvokeService<T>(string serviceURL,string httpProtocol, string requestBody)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            var stringTask = await client.GetStringAsync(serviceURL);
        }
    }
}