namespace HostIsle.Web.Hotels.Areas.Guest.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ICleaningService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> SkipAsync(string id);
    }
}
