using SocializeData.DbContexts;
using SocializeData.Entities;
using SocializeData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeData.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
