using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ERP.Web.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Edit(string Id)
        {
            PurchaseOrderModel PO = new PurchaseOrderModel();
            if (Id == "New")
            {
                PO = new PurchaseOrderModel();
            }
            else
            {

            }
            return View(PO);
        }
        public async Task<ActionResult> Save(PurchaseOrderModel purchaseOrder)
        {
            PurchaseOrderModel PO = new PurchaseOrderModel();
            return View(PO);
        }
    }
}
