using SocializeData.DbContexts;
using SocializeData.Interfaces;
using SocializeData.Repositories;

namespace SocializeData.Repositories
{
    public class DbContextTransactionRepository : GenericRepository<ApplicationDbContext>, IDbContextTransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DbContextTransactionRepository(ApplicationDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task ExecuteInTransactionAsync(Func<Task> action)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await action();
                    transaction.Commit(); // comiteas en la base.
                }
                catch (Exception)
                {
                    transaction.Rollback(); // en caso de falla rollback
                    throw; // lanzas la  excepción para manejarla segun lo que desees.
                }
            }
        }
    }
}
