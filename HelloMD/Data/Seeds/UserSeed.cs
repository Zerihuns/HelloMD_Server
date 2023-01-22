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
                Id = 1,
                FirstName = "Zerihun",
                LastName = "H.",
                Username = "zeru",
                LastSeen = DateTime.Now,
                CreatedAt= DateTime.Now,
                UpdatedAt= DateTime.Now,
                Password="test"
            },
            new User
            {
                Id = 2,
                FirstName = "loine",
                LastName = "K.",
                Username = "loli",
                LastSeen = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Password = "test"
            }
            );
        }
    }

}