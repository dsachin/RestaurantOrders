using BusinessLogic;
using BusinessLogic.Models;
using BusinessLogic.RestaurantManagement;
using System.Net;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class TableController : Controller
    {
        ManageRestaurant manage = new ManageRestaurant();
        Mappings map = new Mappings();

        // GET: Table Index List
        public ActionResult TableIndex()
     => View(map.DisplayTable(false));

        // GET: Table/Details/5
        public ActionResult TableDetails(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TableViewModel table = manage.FindTable(id);
            if (table == null)
                return HttpNotFound();
            return View(table);
        }

        // GET: Table/Create
        public ActionResult TableCreate()
       => View();

        // POST: Table/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TableCreate([Bind(Include = "TableID")] TableViewModel table)
        {
            if (ModelState.IsValid)
            {
                manage.AddTable(table);
                return RedirectToAction("TableIndex");
            }

            return View(table);
        }

        // GET: Table/Edit/5
        public ActionResult TableEdit(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TableViewModel table = manage.FindTable(id);
            if (table == null)
                return HttpNotFound();
            return View(table);
        }

        // POST: Table/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TableEdit([Bind(Include = "TableID,TableStatus")] TableViewModel table)
        {
            if (ModelState.IsValid)
            {
                manage.EditTable(table);
                return RedirectToAction("TableIndex");
            }
            return View(table);
        }

        // GET: Table/Delete/5
        public ActionResult TableDelete(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TableViewModel table = manage.FindTable(id);
            if (table == null)
                return HttpNotFound();

            return View(table);
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("TableDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedTable(int id)
        {
            manage.DeleteTable(id);
            return RedirectToAction("TableIndex");
        }
    }
}