using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HelloMD.models;
using System.Text.Json.Serialization;

namespace NameAPIProxyService.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                UserID = 1,
                FirstName = "Zerihun",
                LastName = "H.",
                Username = "zeru",
                Active = true,
                Status = Status.Active,
                LastSeen = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Password = "test"
            },
            new User
            {
                UserID = 2,
                FirstName = "lonel",
                LastName = "Prime",
                Username = "lonel",
                Active = true,
                Status = Status.Active,
                LastSeen = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Password = "test"
            }
            );
        }
    }

}