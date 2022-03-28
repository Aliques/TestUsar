using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskUsar.Domain.Core;

namespace TestTaskUsar.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAll();
        Message Create(Message message);
        Task<int> SaveChangesAsync();
    } 
}
