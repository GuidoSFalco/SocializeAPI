using SocializeData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeData.Interfaces
{
    public interface IAuthenticationRepository : IGenericRepository<User>
    {
    }
}
