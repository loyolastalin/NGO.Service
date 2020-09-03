using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using NEO.App.Domain.Core;
using NGO.Common.Logging;
using NGO.EntityFramework;

namespace NEO.App.Domain
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public async Task<List<Event>> GetAllEvents()
        {
            Logger.Current.LogVerbose("All events from repository is called.");
            return await Entities.Events.ToListAsync();
        }
    }
}
