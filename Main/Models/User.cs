using System.Collections.Generic;

namespace Main.Models
{
	public class User
	{
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public User(UserViewModel userVM)
        {
            Orders = new HashSet<Order>();
            PopulateFromVM(userVM);
        }

        public void PopulateFromVM(UserViewModel userVM)
        {
            FirstName = userVM.FirstName;
            LastName = userVM.LastName;
        }
        
		public int UserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}

    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}