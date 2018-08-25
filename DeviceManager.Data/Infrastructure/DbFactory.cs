namespace DeviceManager.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DeviceManagerDbContext dbContext;

        public DeviceManagerDbContext Init()
        {
            return dbContext ?? (dbContext = new DeviceManagerDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}