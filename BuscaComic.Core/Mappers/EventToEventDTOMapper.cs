using BuscaComic.Core.DTOs;
using BuscaComic.Core.Models;

namespace BuscaComic.Core.Mappers
{
    public class EventToEventDTOMapper : IMapper<Event, EventDTO>
    {
        public EventDTO Map(Event source)
        {
            return new EventDTO
            {
                Name = source.Name
            };
        }
    }
}
