using System.Collections.Generic;

namespace BuscaComic.Core.DTOs
{
    public class CharacterDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public IEnumerable<EventDTO> Events { get; set; }
    }

    public class SerieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
    }

    public class EventDTO
    {
        public string Name { get; set; }
    }
}
