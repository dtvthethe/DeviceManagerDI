using AutoMapper;
using DeviceManager.Model.Models;
using DeviceManager.Web.Areas.Admin.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DeviceManager.Web.App_Start.AutoMapperConfig))]

namespace DeviceManager.Web.App_Start
{
    public class AutoMapperConfig
    {
        public void Configuration(IAppBuilder app)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserViewModel, User>();
                cfg.CreateMap<User, UserViewModel>();

            });
        }
    }
}
