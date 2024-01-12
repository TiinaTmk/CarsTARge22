namespace CarsTARge22.Models.Cars
{
	public class CarDetailsViewModel
	{
		public Guid? Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int Price { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
