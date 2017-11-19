using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Main.DAL;
using Main.Models;

namespace Main.Controllers
{
    public class OrderController : Controller
    {
        private OrderSystemContext db = new OrderSystemContext();

        [HttpGet]
        public ActionResult GetById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return Json(order, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create([Bind] OrderViewModel orderVM)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order(orderVM);

                db.Orders.Add(order);
                db.SaveChanges();
                return Json(orderVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Edit(int? id, [Bind] OrderViewModel orderVM)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                Order order = db.Orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                order.PopulateFromVM(orderVM);

                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return Json(orderVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}