namespace Main.Models
{
	public class Order
	{
        public Order() { }

        public Order(OrderViewModel orderVM)
        {
            PopulateFromVM(orderVM);
        }

        public void PopulateFromVM(OrderViewModel orderVM)
        {
            UserID = orderVM.UserID;
            TrackingID = orderVM.TrackingID;
            Name = orderVM.Name;
            Address = orderVM.Address;
            City = orderVM.City;
            State = orderVM.State;
            ZipCode = orderVM.ZipCode;
        }

		public int OrderID { get; set; }
		public string TrackingID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
	}

    public class OrderViewModel
    {
        public int UserID { get; set; }
        public string TrackingID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}