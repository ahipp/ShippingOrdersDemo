using Main.Models;
using System.Collections.Generic;

namespace Main.DAL.Interfaces
{
    public interface IUserDAL
    {
        User Get(int ID);
        List<User> GetAll();
        void Add(User user);
        void AddFromViewModel(UserViewModel userVM);
        void UpdateFromViewModel(int ID, UserViewModel userVM);
    }
}
