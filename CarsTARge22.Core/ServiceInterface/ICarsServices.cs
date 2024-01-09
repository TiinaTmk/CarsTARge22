using CarsTARge22.Core.Domain;
using CarsTARge22.Core.Dto;

namespace CarsTARge22.Core.ServiceInterface
{
	public interface ICarsServices
	{
		Task<Car> Create(CarDto dto);
		Task<Car> Update(CarDto dto);
		Task<Car> DetailsAsync(Guid id);
		Task<Car> Delete(Guid id);
	}
}
