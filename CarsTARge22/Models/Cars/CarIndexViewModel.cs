﻿namespace CarsTARge22.Models.Cars
{
	public class CarIndexViewModel
	{
		
			public Guid? Id { get; set; }
			public string Brand { get; set; }
			public string Model { get; set; }
			public int Year { get; set; }
			public decimal Price { get; set; }
			public DateTime CreatedAt { get; set; }
			public DateTime ModifiedAt { get; set; }

        public CarIndexViewModel()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }

	}
