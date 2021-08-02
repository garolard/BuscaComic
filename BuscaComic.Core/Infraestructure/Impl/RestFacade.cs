using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuscaComic.Core.Infraestructure.Impl
{
    public class RestFacade : IRestFacade
    {
        private static HttpClient client;

        public static HttpClient Client
        {
            get
            {
                if (client == null)
                    client = new HttpClient();

                return client;
            }
        }

        public async Task<TRes> Get<TRes>(string url)
        {
            var response = await Client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TRes>(content);
        }

        public async Task<TRes> Post<TRes, TReq>(string url, TReq requestBody)
        {
            var body = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TRes>(responseContent);
        }
    }
}
