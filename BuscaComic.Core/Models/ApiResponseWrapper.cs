using Newtonsoft.Json;

namespace BuscaComic.Core.Models
{
    public partial class ApiResponseWrapper<T>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data<T> Data { get; set; }
    }

    public partial class Data<T>
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public T[] Results { get; set; }
    }
}
