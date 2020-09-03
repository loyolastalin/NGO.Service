using System.Collections.Generic;
using System.Threading.Tasks;
using NGO.EntityFramework;

namespace NEO.App.Domain.Core
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents();
    }
}
