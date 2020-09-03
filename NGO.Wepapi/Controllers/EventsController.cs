using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using NEO.App.Domain.Core;
using NGO.EntityFramework;

namespace NGO.Wepapi.Controllers
{
    public class EventsController : ApiController
    {
        private IEventRepository _eventRepository;
       
        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
       
        [HttpGet]
        public async Task<IEnumerable<Event>> AllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }
    }
}