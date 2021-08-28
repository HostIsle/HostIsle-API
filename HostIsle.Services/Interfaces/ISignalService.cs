namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ISignalService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> ProccessAsync(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> DeleteAsync(string id);
    }
}
