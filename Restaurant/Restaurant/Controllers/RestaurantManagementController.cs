using System.Web.Mvc;
using BusinessLogic.Models;
using BusinessLogic.RestaurantManagement;
using BusinessLogic;
using System.Net;

namespace Restaurant.Controllers
{
    public class RestaurantManagementController : Controller
    {
        ManageRestaurant manage = new ManageRestaurant();
        Mappings map = new Mappings();

        //Dashboard for Restaurant management includes links to menu, table, tax configuration
        public ActionResult Dashboard()
            => View();

        //Tax Configuration
        public ActionResult TaxConfig()
            => View(map.DisplayTaxes());

        [HttpPost]
        public ActionResult TaxConfig(TaxViewModel taxView)
        {
            if (taxView == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            bool flag = manage.AddTax(taxView);
            if (flag == true)
                return RedirectToAction("Dashboard");
            else
                return HttpNotFound();
        }
    }
}


