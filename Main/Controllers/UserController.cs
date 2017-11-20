using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Main.DAL;
using Main.Models;
using Main.DAL.Interfaces;

namespace Main.Controllers
{
    public class UserController : Controller
    {
        private OrderSystemContext db;
        private IUserDAL userDAL;

        public UserController()
        {
            db = new OrderSystemContext();
            userDAL = new UserDAL(db);
        }

        public UserController(IUserDAL userDAL)
        {
            db = new OrderSystemContext();
            this.userDAL = userDAL;
        }

        [HttpGet]
        public ActionResult GetById(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            User user = userDAL.Get(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return Json(user.CreateViewModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDropdownList()
        {
            List<DropdownItem> dropdownList = userDAL.GetAll().Select(user => new DropdownItem()
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
                userDAL.AddFromViewModel(userVM);
                return Json(userVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Edit(int? id, [Bind] UserViewModel userVM)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            if (ModelState.IsValid)
            {
                userDAL.UpdateFromViewModel(id.Value, userVM);
                return Json(userVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
