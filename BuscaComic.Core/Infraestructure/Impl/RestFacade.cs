using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<string> Get(string url)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Post<TReq>(string url, TReq requestBody)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var body = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(url, content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
