using CLayer;
using Microsoft.EntityFrameworkCore;

namespace ERP.Web.DLayer
{
    public class PurchaseOrderRepo
    {
        private ERPContext _context { get; set; }
        public PurchaseOrderRepo(ERPContext _sc)
        {
            _context = _sc;
        }
        public async Task<bool> AddAsync(PurchaseOrderEntity data)
        {

            if (await _context.PurchaseOrder.AnyAsync(d => d.Name == data.Name))
            {
                return false;
            }

            await _context.PurchaseOrder.AddAsync(data);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
