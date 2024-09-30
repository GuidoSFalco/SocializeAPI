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
    public class AuthenticationRepository : GenericRepository<User>, IAuthenticationRepository
    {
        public AuthenticationRepository(ApplicationDbContext db) : base(db)
        {
        }


    }
}
