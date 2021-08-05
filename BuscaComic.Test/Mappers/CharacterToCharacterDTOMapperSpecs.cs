using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class CharacterToCharacterDTOMapperSpecs
    {
        private readonly IMapper<Character, CharacterDTO> mapper;

        public CharacterToCharacterDTOMapperSpecs()
        {
            mapper = new CharacterToCharacterDTOMapper();
        }

        [Fact]
        public void Should_Map_A_Filled_Character()
        {
            var character = Character();
            var dto = mapper.Map(character);

            Assert.Equal(character.Name, dto.Name);
            Assert.Equal(character.Description, dto.Description);
            Assert.Equal($"{character.Thumbnail.Path}.{character.Thumbnail.Extension}", dto.ImageUrl);
        }

        private Character Character()
        {
            return new Character
            {
                Id = 1,
                Name = "Captain America",
                Description = "An American super-soldier",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("https://placeholder.pics/svg/300"),
                    Extension = "jpg"
                }
            };
        }
    }
}
