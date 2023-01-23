using HelloMD.models;
using HelloMD.Models;
using HelloMD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NameAPIProxyService.Data;

namespace HelloMD.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository 
    {
        public MessageRepository(IDbContextFactory<HelloMDDbContext> context) : base(context) { }

    }
}
