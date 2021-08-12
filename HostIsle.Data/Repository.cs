namespace HostIsle.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext appDbContext;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.dbSet = appDbContext.Set<T>();
        }

        public async Task AddAsync(T model)
        {
            await this.appDbContext.AddAsync<T>(model);
        }

        public void Delete(T model)
        {
            this.appDbContext.Remove<T>(model);
        }

        public async Task<T> GetAsync(string id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public void Update(T model)
        {
            this.appDbContext.Update<T>(model);
        }

        public async Task SaveChangesAsync()
        {
            await this.appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var records = await this.dbSet.ToListAsync();

            return records;
        }
    }
}
