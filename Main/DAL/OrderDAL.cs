using Main.DAL.Interfaces;
using Main.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Main.DAL
{
    public class OrderDAL : IOrderDAL
    {
        private OrderSystemContext db;

        public OrderDAL(OrderSystemContext db)
        {
            this.db = db;
        }

        public Order Get(int ID)
        {
            return db.Orders.Find(ID);
        }

        public List<Order> GetListByUserID(int userID)
        {
            User user = db.Users.Find(userID);
            List<Order> orders = new List<Order>();
            if (user != null)
            {
                orders = user.Orders.ToList();
            }

            return orders;
        }

        public void AddFromViewModel(OrderViewModel orderVM)
        {
            Add(new Order(orderVM));
        }

        public void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void UpdateFromViewModel(int ID, OrderViewModel orderVM)
        {
            Order order = db.Orders.Find(ID);
            if (order == null)
            {
                throw new System.Exception("No order matches the provided ID");
            }
            order.PopulateFromVM(orderVM);

            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}