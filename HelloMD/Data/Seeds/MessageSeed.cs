using HelloMD.models;
using HelloMD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloMD.Data.Seeds
{
    public class MessageSeed : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasData(
                new Message {
                    MessageID = 1,
                    WriterID= 1,
                    ReceiverID = 2,
                    Body = "Hi Bro",
                    Status = "Active",
                },
                new Message {
                    MessageID = 2,
                    WriterID= 2,
                    ReceiverID = 1,
                    Body = "How Are you ?",
                    Status = "Active",
                }, new Message {
                    MessageID = 3,
                    WriterID = 1,
                    ReceiverID = 2,
                    Body = "I am God",
                    Status = "Active",
                }, new Message {
                    MessageID = 4,
                    WriterID = 2,
                    ReceiverID = 1,
                    Body = "Any News ?",
                    Status = "Active",
                });
        }
    }
}
