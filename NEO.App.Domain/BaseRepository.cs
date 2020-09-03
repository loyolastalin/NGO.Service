using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGO.EntityFramework;

namespace NEO.App.Domain
{
    public abstract class BaseRepository
    {
        private NGODBEntities _entities = null;

        protected NGODBEntities Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = new NGODBEntities();
                }

                return _entities;
            }
        }
    }
}
