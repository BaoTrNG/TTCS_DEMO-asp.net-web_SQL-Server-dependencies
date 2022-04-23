
using WebChungKhoan3._0.TableDependencies;
namespace WebChungKhoan3._0.MiddleWare
{
    public static class AppBuilder
    {
        public static void UseOrderDenpendency(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var service = serviceProvider.GetService<BANGGIATRUCTUYENDenpendency>();
            service.SubscribeTableDenpendency();
            
        }
    }
}
