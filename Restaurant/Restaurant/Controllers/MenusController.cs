using System.Net;
using System.Web.Mvc;
using BusinessLogic.RestaurantManagement;
using BusinessLogic;
using BusinessLogic.Models;

namespace Restaurant.Controllers
{
    public class MenusController : Controller
    {
        ManageRestaurant manage = new ManageRestaurant();
        Mappings map = new Mappings();

        // GET: Menu List Index
        public ActionResult Index()
        => View(map.DisplayMenu());

        // GET: Menus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            MenuViewModel menu = manage.FindMenu(id);
            if (menu == null)
                return HttpNotFound();
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
       => View();

        // POST: Menus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuId,Price,Category")] MenuViewModel menu)
        {
            if (ModelState.IsValid)
            {
                manage.AddMenu(menu);
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            MenuViewModel menu = manage.FindMenu(id);
            if (menu == null)
                return HttpNotFound();
            return View(menu);
        }

        // POST: Menus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuId,Price,Category")] MenuViewModel menu)
        {
            if (ModelState.IsValid)
            {
                manage.EditMenu(menu);
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            MenuViewModel menu = manage.FindMenu(id);
            if (menu == null)
                return HttpNotFound();
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            manage.DeleteMenu(id);
            return RedirectToAction("Index");
        }
    }
}
