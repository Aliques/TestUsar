using AutoMapper;
using TestTaskUsar.Domain.Core;
using TestTaskUsar.Domain.Core.DTO;

namespace TestTaskUsarApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageForCreationDTO, Message>();
            CreateMap<Message, MessageDTO>();
        }
    }
}
