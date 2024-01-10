using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsTARge22.Core.Domain
{
	public class Car
	{
			public Guid? Id { get; set; }
			public string Brand { get; set; }
			public string Model { get; set; }
			public int Year { get; set; }
			public decimal Price { get; set; }
			public DateTime CreatedAt { get; set; }
			public DateTime ModifiedAt { get; set; }
		}
}
