namespace HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IRequestService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> AcceptAsync(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> DeleteAsync(string id);
    }
}
