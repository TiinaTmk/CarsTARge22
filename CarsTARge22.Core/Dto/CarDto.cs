

namespace CarsTARge22.Core.Dto
{
	public class CarDto
	{
		public Guid? Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int Price { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
   

        public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
