using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using Main.DAL;
using Main.DAL.Interfaces;
using Main.Models;

namespace Main.Controllers
{
    public class OrderController : Controller
    {
        private OrderSystemContext db;
        private IOrderDAL orderDAL;

        public OrderController()
        {
            db = new OrderSystemContext();
            orderDAL = new OrderDAL(db); 
        }

        public OrderController(IOrderDAL orderDAL)
        {
            db = new OrderSystemContext();
            this.orderDAL = orderDAL;
        }

        [HttpGet]
        public ActionResult GetById(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Order order = orderDAL.Get(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return Json(order.CreateViewModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetListByUserId(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            List<OrderSelectItem> orders = new List<OrderSelectItem>();
            foreach (Order order in orderDAL.GetListByUserID(id.Value))
            {
                orders.Add(new OrderSelectItem {
                    OrderID = order.OrderID,
                    TrackingID = order.TrackingID
                });
            }
            return Json(orders, JsonRequestBehavior.AllowGet);
        }
         
        [HttpPost]
        public ActionResult Create([Bind] OrderViewModel orderVM)
        {
            if (ModelState.IsValid)
            {
                orderDAL.AddFromViewModel(orderVM);
                return Json(orderVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Edit(int? id, [Bind] OrderViewModel orderVM)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            if (ModelState.IsValid)
            {
                orderDAL.UpdateFromViewModel(id.Value, orderVM);
                return Json(orderVM, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}