using ERP.Web.CLayer;

namespace CLayer
{
    public class PurchaseOrderEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public DateTime? Date { get; set; }
        public List<PurchaseOrderItemListEntity> POLIs { get; set; }
    }
}
