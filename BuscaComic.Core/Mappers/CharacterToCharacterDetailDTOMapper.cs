using BuscaComic.Core.DTOs;
using BuscaComic.Core.Models;
using System.Linq;

namespace BuscaComic.Core.Mappers
{
    public class CharacterToCharacterDetailDTOMapper : IMapper<Character, CharacterDetailDTO>
    {
        private readonly IMapper<Event, EventDTO> mapper;

        public CharacterToCharacterDetailDTOMapper(IMapper<Event, EventDTO> mapper)
        {
            this.mapper = mapper;
        }

        public CharacterDetailDTO Map(Character source)
        {
            return new CharacterDetailDTO
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                ThumbnailUrl = $"{source.Thumbnail.Path}.{source.Thumbnail.Extension}",
                Events = source.Events.Items.Select(mapper.Map)
            };
        }
    }
}
