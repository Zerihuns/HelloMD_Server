namespace HelloMD.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
