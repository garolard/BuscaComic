using System.Collections.Generic;

namespace BuscaComic.Core.DTOs
{
    public class ComicDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public IEnumerable<CharacterInListDTO> Characters { get; set; }
    }
}
