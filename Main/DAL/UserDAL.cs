using Main.DAL.Interfaces;
using Main.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Main.DAL
{
    public class UserDAL : IUserDAL
    {
        private OrderSystemContext db;

        public UserDAL(OrderSystemContext db)
        {
            this.db = db;
        }

        public User Get(int ID)
        {
            return db.Users.Find(ID);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void AddFromViewModel(UserViewModel userVM)
        {
            Add(new User(userVM));
        }

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void UpdateFromViewModel(int ID, UserViewModel userVM)
        {
            User user = db.Users.Find(ID);
            if (user == null)
            {
                throw new System.Exception("No user matches the provided ID");
            }
            user.PopulateFromVM(userVM);

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}