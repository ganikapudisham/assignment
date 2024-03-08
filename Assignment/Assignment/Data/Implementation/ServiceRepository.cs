using Assignment.Data.Services;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Assignment.Data.Impl
{
    public class ServiceRepository : ServiceBase, IServiceRepository
    {
        HttpClient client = new HttpClient();

        public async Task<TResult> GetAsync<TResult>(string url)
        {
            TResult objectToReturn = default(TResult);
            HttpResponseMessage response = null;

            try
            {
                var httpClient = CreateHttpClient();
                response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Not found, please try again with different data");
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("Something went wrong, please try again");
                    }
                }
                else
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    objectToReturn = JsonConvert.DeserializeObject<TResult>(responseJson);
                }
            }
            catch (HttpRequestException ex)
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objectToReturn;
        }
    }
}
