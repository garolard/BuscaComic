using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using BuscaComic.Test.Common;
using Moq;
using System.Linq;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class CharacterToCharacterDetailDTOMapperSpecs
    {
        private readonly ObjectMother db;
        private readonly IMapper<Character, CharacterDetailDTO> mapper;
                

        [Fact]
        public void Should_Map_A_Character()
        {
            var dto = mapper.Map(db.Thor);

            Assert.Equal(db.Thor.Id, dto.Id);
            Assert.Equal(db.Thor.Name, dto.Name);
            Assert.Equal(db.Thor.Description, dto.Description);
            Assert.Equal($"{db.Thor.Thumbnail.Path}.{db.Thor.Thumbnail.Extension}", dto.ThumbnailUrl);
            Assert.Equal(db.Thor.Events.Items.Count(), dto.Events.Count());
        }


        public CharacterToCharacterDetailDTOMapperSpecs()
        {
            db = new ObjectMother();

            var eventMapperMock = new Mock<IMapper<Event, EventDTO>>();
            eventMapperMock.Setup(m => m.Map(It.IsAny<Event>()))
                .Returns((Event ev) => { return new EventDTO { Name = ev.Name }; });

            mapper = new CharacterToCharacterDetailDTOMapper(eventMapperMock.Object);
        }
    }
}
