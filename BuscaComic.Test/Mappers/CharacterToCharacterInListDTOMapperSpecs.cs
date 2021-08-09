using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using BuscaComic.Test.Common;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class CharacterToCharacterInListDTOMapperSpecs
    {
        private readonly ObjectMother db;
        private readonly IMapper<Character, CharacterInListDTO> mapper;
                
        [Fact]
        public void Should_Map_A_Character()
        {
            var dto = mapper.Map(db.Thor);

            Assert.Equal(db.Thor.Id, dto.Id);
            Assert.Equal(db.Thor.Name, dto.Name);
            Assert.Equal(db.Thor.Description, dto.Description);
            Assert.Equal($"{db.Thor.Thumbnail.Path}.{db.Thor.Thumbnail.Extension}", dto.ImageUrl);
            Assert.Equal(ItemType.Character, dto.Type);
        }

        public CharacterToCharacterInListDTOMapperSpecs()
        {
            mapper = new CharacterToCharacterInListDTOMapper();
            db = new ObjectMother();
        }
    }
}
