using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskUsar.Domain.Core;
using TestTaskUsar.Domain.Core.DTO;
using TestTaskUsar.Domain.Interfaces;
using TestTaskUsar.Services.Interfaces;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace TestTaskUsar.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMapper mapper, IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Message> Create(MessageForCreationDTO messageDto)
        {
            var messageEntity = _mapper.Map<Message>(messageDto);
            var result = _messageRepository.Create(messageEntity);
            await _messageRepository.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<MessageDTO>> GetAll()
        {
            var configuration = new MapperConfiguration(cfg =>
               cfg.CreateMap<Message, MessageDTO>());
            var result = await _messageRepository.GetAll();

            return result.AsQueryable()
                .ProjectTo<MessageDTO>(configuration);
        }
    }
}
