using ERP.Web.DLayer;
using Microsoft.EntityFrameworkCore;
namespace ERP.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void DBRegistration(this IServiceCollection services, string connectionString, int mySQLMajorVersion, int mySQLMinorVersion, int mySQLBuildNo)
        {
            var serverVersion = new MySqlServerVersion(new Version(mySQLMajorVersion, mySQLMinorVersion, mySQLBuildNo));
            services.AddDbContext<ERPContext>(options =>
                options.UseMySql(connectionString, serverVersion,
                mysqlopt =>
                {
                    mysqlopt.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }
                )
            );
        }
        public static void RegisterCoreClasses(this IServiceCollection services)
        {
            
            services.AddScoped(typeof(PurchaseOrderRepo));
            
        }
    }
}
