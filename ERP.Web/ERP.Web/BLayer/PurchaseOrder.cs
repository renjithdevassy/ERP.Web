using AutoMapper;
using CLayer;
using ERP.Web.DLayer;
using Models;

namespace ERP.Web.BLayer
{
    public class PurchaseOrder
    {
        private  PurchaseOrderRepo _purchaseOrder { get; set; }
        private  IMapper _mapper { get; set; }
        private readonly ILogger<PurchaseOrderRepo> _logger;
        public PurchaseOrder(PurchaseOrderRepo repo, IMapper mapper, ILogger<PurchaseOrderRepo> log)
        {
            _purchaseOrder = repo;
            _mapper = mapper;
            _logger = log;
        }
        public async Task<PurchaseOrderModel> AddAsync(PurchaseOrderModel data)
        {
            try
            {
                var sdata = _mapper.Map<PurchaseOrderEntity>(data);
                await _purchaseOrder.AddAsync(sdata);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return data;
        }
    }
}
