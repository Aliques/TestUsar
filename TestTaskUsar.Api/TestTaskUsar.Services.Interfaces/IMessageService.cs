using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskUsar.Domain.Core;
using TestTaskUsar.Domain.Core.DTO;

namespace TestTaskUsar.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDTO>> GetAll();
        Task<Message> Create(MessageForCreationDTO message);
    }
}
