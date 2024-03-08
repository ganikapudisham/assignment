using System.Collections;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;

namespace Assignment.Data.Services
{
    public class ServiceBase
    {
        const int MAX_RETRY = 3;
        private readonly Uri _apiEndpoint = new Uri("https://www.themealdb.com//");


        protected HttpClient CreateHttpClient()
        {
            var accessType = Connectivity.Current.NetworkAccess;

            if (accessType != NetworkAccess.Internet)
            {
            }

            var client = new HttpClient() { BaseAddress = _apiEndpoint };
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            return client;
        }
    }
}
