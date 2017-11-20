using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Main.DAL;
using Main.Models;

namespace Main.Controllers
{
    public class UserController : Controller
    {
        private OrderSystemContext db = new OrderSystemContext();

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
            return Json(user.CreateViewModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDropdownList()
        {
            List<DropdownItem> dropdownList = db.Users.Select(user => new DropdownItem()
            {
                Value = user.UserID.ToString(),
                Label = user.FirstName + " " + user.LastName + " (userID: " + user.UserID.ToString() + ")",
            }).ToList();

            return Json(dropdownList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create([Bind] UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                User user = new User(userVM);

                db.Users.Add(user);
                db.SaveChanges();
                return Json(userVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Edit(int? id, [Bind] UserViewModel userVM)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                user.PopulateFromVM(userVM);

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Json(userVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
