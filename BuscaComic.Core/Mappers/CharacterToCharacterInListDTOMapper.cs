using BuscaComic.Core.DTOs;
using BuscaComic.Core.Models;

namespace BuscaComic.Core.Mappers
{
    public class CharacterToCharacterInListDTOMapper : IMapper<Character, CharacterInListDTO>
    {
        public CharacterInListDTO Map(Character source)
        {
            return new CharacterInListDTO
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                ImageUrl = $"{source.Thumbnail.Path}.{source.Thumbnail.Extension}",
                Type = ItemType.Character
            };
        }
    }
}
