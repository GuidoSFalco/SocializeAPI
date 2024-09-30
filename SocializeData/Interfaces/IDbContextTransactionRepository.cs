using SocializeData.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeData.Interfaces
{
    public interface IDbContextTransactionRepository : IGenericRepository<ApplicationDbContext>
    {
        public Task ExecuteInTransactionAsync(Func<Task> action);
    }
}
