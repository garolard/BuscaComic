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
                Description = source.Description,
                ThumbnailUrl = $"{source.Thumbnail.Path}.{source.Thumbnail.Extension}",
                // Si se mapearan mas propiedades debería sacar un mapper completo
                // como con el mapper de personajes, de momento así me vale y me ahorro
                // una dependencia
                Characters = source.Characters.Items.Select(c => new CharacterInListDTO { Name = c.Name })
            };
        }
    }
}
