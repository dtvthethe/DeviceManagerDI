namespace DeviceManager.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}