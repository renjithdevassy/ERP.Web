namespace ERP.Web.Models
{
    public class PurchaseOrderItemListModel
    {
        public string? Id { get; set; }
        public string? PurchaseOrderId { get; set; }
        public string? ItemName { get; set; }
        public float? Qty { get; set; }
        public decimal? Price { get; set; }

    }
}
