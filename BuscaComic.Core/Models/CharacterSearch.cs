using System;
using Newtonsoft.Json;

namespace BuscaComic.Core.Models
{
    public partial class CharacterSearch
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
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
        public Result[] Results { get; set; }
    }

    // Esta entidad viene con bastantes más propiedades
    // para para hacer algo no demasiado complejo me vale con estas
    public partial class Result
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }
    }

    public partial class Thumbnail
    {
        [JsonProperty("path")]
        public Uri Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}
