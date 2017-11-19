using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Main.DAL;
using Main.Models;

namespace Main.Controllers
{
    public class UserController : Controller
    {
        private OrderSystemContext db = new OrderSystemContext();

        // GET: User/5
        [HttpGet]
        public ActionResult GetById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Json(user, JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.AllowGet);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Json(user, JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.AllowGet);
        }
    }
}
