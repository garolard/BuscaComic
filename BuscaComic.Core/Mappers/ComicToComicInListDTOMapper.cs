using BuscaComic.Core.DTOs;
using BuscaComic.Core.Models;

namespace BuscaComic.Core.Mappers
{
    public class ComicToComicInListDTOMapper : IMapper<Comic, ComicInListDTO>
    {
        public ComicInListDTO Map(Comic source)
        {
            return new ComicInListDTO
            {
                Id = source.Id,
                Name = source.Title,
                Description = source.Description,
                ImageUrl = $"{source.Thumbnail.Path}.{source.Thumbnail.Extension}",
                Type = ItemType.Comic
            };
        }
    }
}
