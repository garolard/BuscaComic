using BuscaComic.Core.DTOs;
using BuscaComic.Core.Models;

namespace BuscaComic.Core.Mappers
{
    public class CharacterToCharacterDTOMapper : IMapper<Character, CharacterDTO>
    {
        public CharacterDTO Map(Character source)
        {
            return new CharacterDTO
            {
                Name = source.Name,
                Description = source.Description,
                ImageUrl = $"{source.Thumbnail.Path}.{source.Thumbnail.Extension}"
            };
        }
    }
}
