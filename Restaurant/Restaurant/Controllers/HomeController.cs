using System.Web.Mvc;
using BusinessLogic.Billing;
using BusinessLogic.Models.MultiModels;
using BusinessLogic.DataStoring;
using BusinessLogic.Models;
using System.Collections.Generic;
using BusinessLogic;
using System;
using System.Net;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        Mappings map = new Mappings();

        #region Index and Orders
        //Landing Menu page 
        public ActionResult Index()
            => View(map.DisplayMenu());

        //Current placed Orders
        public ActionResult Details()
             => View(map.DisplayOrders());
        #endregion

        #region Take Order  
        //Take Order
        public ActionResult OrderMenu()
        {
            OrderDisplay order = new OrderDisplay();
            ViewBag.obj = order.DisplayOrder();
            return View();
        }

        //Place Order
        public JsonResult OrderPlacedData(List<OrderViewModel> jsnData)
        {
            if (jsnData == null)
                return Json(false, JsonRequestBehavior.AllowGet);
            OrderDataStoring order = new OrderDataStoring(jsnData);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region  Bill Creation and Payment
        //Bill payment
        public ActionResult Bill()
        {
            BillDisplay bill = new BillDisplay();
            CustomerBillViewModel billDisplay = bill.Bill();
            return View(billDisplay);
        }

        [HttpPost]
        public ActionResult Bill(CustomerBillViewModel tableNo)
        {
            if (tableNo == null)
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            int? TableNo = Convert.ToInt32(tableNo.SelectedTable);
            BillDisplay bill = new BillDisplay();
            CustomerBillViewModel billDisplay = bill.DisplayBillDetails(TableNo);
            return View(billDisplay);
        }

        public JsonResult BillUpdate(CustomerBillStoringViewModel storeBill)
        {
            if (storeBill == null)
                return Json(false, JsonRequestBehavior.AllowGet);
            BillStoring bill = new BillStoring(storeBill);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Order Editing
        //Edit Order
        public ActionResult EditOrder()
        {
            ViewBag.obj = map.DisplayTable(true);
            return View("View");
        }

        [HttpPost]
        public ActionResult EditOrder(int? tableNo)
        {
            if (tableNo == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            EditOrderViewModel order = new EditOrderViewModel();
            order.OrderList = map.DisplayOrdersByTable(tableNo);
            ViewBag.obj = map.DisplayTable(true);
            return View(order);
        }

        //Update Order 
        public JsonResult EditOrderUpdateData(EditOrderViewModel order)
        {
            if (order == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            EditOrder edit = new EditOrder(order);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
