using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostIsle.Mobile.Services
{
    public interface IDataStore<T>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> AddItemAsync(T item);
        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> UpdateItemAsync(T item);
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> DeleteItemAsync(string id);
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<T> GetItemAsync(string id);
        /// <summary>
        ///
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
