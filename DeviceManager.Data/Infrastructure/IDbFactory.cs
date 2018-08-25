using System;

namespace DeviceManager.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DeviceManagerDbContext Init();
    }
}