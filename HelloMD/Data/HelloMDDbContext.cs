using HelloMD.models;
using HelloMD.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NameAPIProxyService.Data
{
    public class HelloMDDbContext : DbContext
    {
        public virtual DbSet<User> Accounts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        public HelloMDDbContext(DbContextOptions<HelloMDDbContext> context) : base(context){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //..Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(HelloMDDbContext)));

            base.OnModelCreating(modelBuilder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is User entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            Entry(entityReference).Property(x => x.CreatedAt).IsModified = false;
                            entityReference.UpdatedAt = DateTime.Now;
                            break;
                        case EntityState.Added:
                            entityReference.CreatedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}