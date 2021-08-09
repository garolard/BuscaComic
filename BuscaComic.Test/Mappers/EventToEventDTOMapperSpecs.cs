using BuscaComic.Core.DTOs;
using BuscaComic.Core.Mappers;
using BuscaComic.Core.Models;
using BuscaComic.Test.Common;
using System.Linq;
using Xunit;

namespace BuscaComic.Test.Mappers
{
    public class EventToEventDTOMapperSpecs
    {
        private readonly ObjectMother db;
        private readonly IMapper<Event, EventDTO> mapper;

        [Fact]
        public void Shoudl_Map_An_Event()
        {
            var @event = mapper.Map(db.Thor.Events.Items.First());

            Assert.Equal(db.Thor.Events.Items.First().Name, @event.Name);
        }

        public EventToEventDTOMapperSpecs()
        {
            db = new ObjectMother();
            mapper = new EventToEventDTOMapper();
        }
    }
}
