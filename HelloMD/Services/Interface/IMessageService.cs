using HelloMD.Dtos;

namespace HelloMD.Services.Interface
{
    public interface IMessageService
    {
        Task<MessageDto> CreateMessage(MessageDto messageDto);
    }
}
