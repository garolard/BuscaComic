using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class CharacterToCharacterDetailDTOMapperSpecs
    {
        private readonly IMapper<Character, CharacterDetailDTO> mapper;

        public CharacterToCharacterDetailDTOMapperSpecs()
        {
            var eventMapperMock = new Mock<IMapper<Event, EventDTO>>();
            eventMapperMock.Setup(m => m.Map(It.IsAny<Event>()))
                .Returns((Event ev) => { return new EventDTO { Name = ev.Name }; });

            this.mapper = new CharacterToCharacterDetailDTOMapper(eventMapperMock.Object);
        }

        [Fact]
        void Should_Map_A_Character()
        {
            var character = Character();
            var dto = mapper.Map(character);

            Assert.Equal(character.Id, dto.Id);
            Assert.Equal(character.Name, dto.Name);
            Assert.Equal(character.Description, dto.Description);
            Assert.Equal($"{character.Thumbnail.Path}.{character.Thumbnail.Extension}", dto.ThumbnailUrl);
            Assert.Equal(character.Events.Items.Count(), dto.Events.Count());
        }

        private Character Character()
        {
            return new Character
            {
                Id  = 1,
                Name = "Hulk",
                Description = "Un tipo verde",
                Thumbnail = new Thumbnail
                {
                    Path = new Uri("https://placeholder.pics/svg/300"),
                    Extension = "jpg"
                },
                Events = new EventArray
                {
                    Items = new Event[]
                    {
                        new Event
                        {
                            Name = "Avengers"
                        },
                        new Event
                        {
                            Name = "Avengers 2"
                        },
                        new Event
                        {
                            Name = "Super Avengers"
                        }
                    }
                }
            };
        }
    }
}
