using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskUsar.Domain.Core;
using TestTaskUsar.Domain.Interfaces;

namespace TestTaskUsar.Infrastructure.Data
{
    public class MessagesRepository : IMessageRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public MessagesRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Message Create(Message message)
        {
            return  _repositoryContext.Messages.Add(message).Entity;
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            return await _repositoryContext.Messages.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _repositoryContext.SaveChangesAsync();
        }
    }
}
