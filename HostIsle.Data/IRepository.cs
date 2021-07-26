namespace HostIsle.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        public Task AddAsync(T model);

        public void Update(T model);

        public void Delete(T model);

        public Task<T> GetAsync(string id);

        public Task<List<T>> GetAllAsync();

        public Task SaveChangesAsync();
    }
}
