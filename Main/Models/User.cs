﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main.Models
{
	public class User
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}