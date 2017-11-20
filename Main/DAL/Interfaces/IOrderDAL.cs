using Main.Models;
using System.Collections.Generic;

namespace Main.DAL.Interfaces
{
    public interface IOrderDAL
    {
        Order Get(int ID);
        List<Order> GetListByUserID(int userID);
        void Add(Order order);
        void AddFromViewModel(OrderViewModel orderVM);
        void UpdateFromViewModel(int ID, OrderViewModel orderVM);
    }
}