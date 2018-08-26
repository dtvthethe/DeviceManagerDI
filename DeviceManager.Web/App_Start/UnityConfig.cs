using DeviceManager.Data.Infrastructure;
using DeviceManager.Data.IRepositories;
using DeviceManager.Service.IServices;
using DeviceManager.Service.Services;
using System;

using Unity;

namespace DeviceManager.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterSingleton<IDbFactory, DbFactory>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUnitRepository, UnitRepository>();
            container.RegisterType<IProviderRepository, ProviderRepository>();
            container.RegisterType<IStatusRepository, StatusRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IReceiptRepository, ReceiptRepository>();
            container.RegisterType<IDeliveryRepository, DeliveryRepository>();
            container.RegisterType<IReceiptDetailRepository, ReceiptDetailRepository>();
            container.RegisterType<IDeliveryDetailRepository, DeliveryDetailRepository>();
            container.RegisterType<IDeviceRepository, DeviceRepository>();

            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUnitService, UnitService>();
            container.RegisterType<IProviderService, ProviderService>();
            container.RegisterType<IStatusService, StatusService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IReceiptService, ReceiptService>();
            container.RegisterType<IDeliveryService, DeliveryService>();
            container.RegisterType<IReceiptDetailService, ReceiptDetailService>();
            container.RegisterType<IDeviceService, DeviceService>();


        }
    }
}