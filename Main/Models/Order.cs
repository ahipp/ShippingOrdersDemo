using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main.Models
{
	public class Order
	{
		public int ID { get; set; }
		public string TrackingID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
	}
}