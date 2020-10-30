﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cleanCodeRuleta.Classes
{
	public class UserClass
	{

		public int id { get; set; }
		public DateTime dataCreated { get; set; }
		public int number { get; set; }
		public int money { get; set; }
		public int randomNumber { get; set; }
		public int result { get; set; }
		public Boolean color { get; set; }

	}
}
