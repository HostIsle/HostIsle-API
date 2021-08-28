namespace HostIsle.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task AddAsync(T model);

        public void Update(T model);

        public void Delete(T model);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<T> GetAsync(string id);

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<List<T>> GetAllAsync();

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task SaveChangesAsync();
    }
}
