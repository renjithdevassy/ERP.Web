using AutoMapper;
using CLayer;
using ERP.Web.CLayer;
using ERP.Web.Models;
using Models;

namespace ERP.Web.Extensions
{
    public static  class ClassMapperExtension
    {
        public static void RegisterMapping(this IServiceCollection services)
        {
            var cfg = new MapperConfiguration(x =>
            {
                
                x.CreateMap<PurchaseOrderEntity, PurchaseOrderModel>();
                x.CreateMap<PurchaseOrderItemListEntity, PurchaseOrderItemListModel>();



            });
            var mapper = cfg.CreateMapper();

            services.AddSingleton(mapper);
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
