using AT.Service.RoleService;
using AT.Service.Services.ErrorLogService;
using AT.Service.Services.MenuToUserAndPermission;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
 

namespace AT.Service.DepedencyService
{
    public static class DepedencyAllService
    {
        public static void AddAllService(this IServiceCollection services)
        {
            services.TryAddTransient<IHtmlHelper, HtmlHelper>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IRoleService, RoleService.RoleService>();
            services.AddScoped<IErrorLogService, ErrorLogService>();
        }
    }
}
