using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTaskUsar.Core.Interfaces.Serivces
{
    /// <summary>
    /// Message api interaction service
    /// </summary>
    public interface IHttpClientServiceImplementation
    {
        /// <summary>
        /// Create new message
        /// </summary>
        /// <param name="entity">Message entity</param>
        /// <returns>Created entity</returns>
        Task<Message> Create(Message entity);

        /// <summary>
        /// Recive all messages from server
        /// </summary>
        /// <returns>Message list</returns>
        Task<IEnumerable<Message>> Get();
    }
}
