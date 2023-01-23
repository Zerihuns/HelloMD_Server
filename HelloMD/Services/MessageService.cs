using AutoMapper;
using HelloMD.Dtos;
using HelloMD.Models;
using HelloMD.Repositories.Interfaces;
using HelloMD.Services.Interface;

namespace HelloMD.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public async Task<MessageDto> CreateMessage(MessageDto messageDto)
        {
            await _messageRepository.AddAsync(_mapper.Map<Message>(messageDto));
            return messageDto;
        }
    }
}
