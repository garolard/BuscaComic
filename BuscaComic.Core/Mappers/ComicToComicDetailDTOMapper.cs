using BuscaComic.Core.DTOs;
using BuscaComic.Core.Models;
using System;
using System.Linq;

namespace BuscaComic.Core.Mappers
{
    public class ComicToComicDetailDTOMapper : IMapper<Comic, ComicDetailDTO>
    {

        public ComicDetailDTO Map(Comic source)
        {
            return new ComicDetailDTO
            {
                Id = source.Id,
                Title = source.Title,
                Format = source.Format,
                Characters = source.Characters.Items.Select(c => new CharacterInListDTO { Name = c.Name })
            };
        }
    }
}
