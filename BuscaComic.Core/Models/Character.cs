using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BuscaComic.Core.Models
{
    // Esta entidad viene con bastantes más propiedades
    // para para hacer algo no demasiado complejo me vale con estas
    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("events")]
        public EventArray Events { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("path")]
        public Uri Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }

    public class EventArray
    {
        [JsonProperty("items")]
        public IEnumerable<Event> Items { get; set; }
    }

    public class Event
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
