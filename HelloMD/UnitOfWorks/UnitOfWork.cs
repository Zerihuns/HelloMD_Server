using HelloMD.UnitOfWorks.Interfaces;
using NameAPIProxyService.Data;

namespace HelloMD.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HelloMDDbContext _context;
        public UnitOfWork(HelloMDDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
