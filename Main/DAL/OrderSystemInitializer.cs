using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Main.Models;

namespace Main.DAL
{
	public class OrderSystemInitializer : DropCreateDatabaseIfModelChanges<OrderSystemContext>
	{
		protected override void Seed(OrderSystemContext context)
		{
			base.Seed(context);

			var orders = new List<Order>
			{
				new Order{ ID=1, Address="2156 W Fulton St", City="Chicago", State="IL", ZipCode="60612", TrackingID="XX001", Name="ShipBob HQ" },
				new Order{ ID=2, Address="123 Fake St", City="Springfield", State="IN", ZipCode="60612", TrackingID="XX002", Name="Marge Simpson" },
				new Order{ ID=3, Address="666 Beast Rd", City="Hell", State="OH", ZipCode="60612", TrackingID="XX003", Name="Satan" },
			};

			orders.ForEach(x => context.Orders.Add(x));
			context.SaveChanges();

			var users = new List<User>
			{
				new User{ ID=1, FirstName="Ship", LastName="Bob" },
				new User{ ID=2, FirstName="Marge", LastName="Simpson" },
				new User{ ID=3, FirstName="The one and only", LastName="Satan" }
			};

			users.ForEach(x => context.Users.Add(x));
			context.SaveChanges();
		}
	}
}