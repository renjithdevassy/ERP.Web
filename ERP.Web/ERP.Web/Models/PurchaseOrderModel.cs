using ERP.Web.Models;

namespace Models
{
    public class PurchaseOrderModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get;set; }
        public DateTime? Date { get; set; }
        public List<PurchaseOrderItemListModel> POLIs { get; set; }

    }
}
