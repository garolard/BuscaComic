using Newtonsoft.Json;
using System;

namespace BuscaComic.Core.Models
{
    public partial class Comic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("dates")]
        public Date[] Dates { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("images")]
        public Thumbnail[] Images { get; set; }

        [JsonProperty("creators")]
        public Creators Creators { get; set; }

        [JsonProperty("characters")]
        public Characters Characters { get; set; }
    }

    public partial class Characters
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public Uri CollectionUri { get; set; }

        [JsonProperty("items")]
        public CharacterInDetail[] Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public partial class CharacterInDetail
    {
        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Creators
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public Uri CollectionUri { get; set; }

        [JsonProperty("items")]
        public CreatorsItem[] Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public partial class CreatorsItem
    {
        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public partial class Date
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("date")]
        public string DateDate { get; set; }
    }
}
