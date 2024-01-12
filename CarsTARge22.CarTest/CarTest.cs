using CarsTARge22.ApplicationServices.Services;
using CarsTARge22.Core.Domain;
using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;

namespace CarsTARge22.Test
{
  
    public class CarTest : TestBase
    {


        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
        {
            
            CarDto car = new();

            car.Brand = "asd";
            car.Model = "mkmk";
            car.Year = 5;
            car.Price = 3;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            
            var result = await Svc<ICarsServices>().Create(car);

            Assert.NotNull(result);
        }




        [Fact]
        public async Task ShouldNot_GetByIdCar_WhenReturnsNotEqual()
        {
            
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("111d934e-6446-4a36-f201-516eb63d1123");

            await Svc<ICarsServices>().DetailsAsync(guid);

            Assert.NotEqual(wrongGuid, guid);
        }






        [Fact]
        public async Task Should_DeleteByIdCar_whenDeleteCar()
        {

            CarDto car = MockCarData();

            var addCar = await Svc<ICarsServices>().Create(car);
            var result = await Svc<ICarsServices>().Delete((Guid)addCar.Id);


            Assert.Equal(result, addCar);
        }



        [Fact]
        public async Task ShouldNot_DeleteByIdCar_WhenDidNotDeleteCar()
        {
            CarDto car = MockCarData();

            var car1 = await Svc<ICarsServices>().Create(car);
            var car2 = await Svc<ICarsServices>().Create(car);

            var result = await Svc<ICarsServices>().Delete((Guid)car2.Id);

            Assert.NotEqual(result.Id, car1.Id);

        }


        [Fact]
        public async Task Should_UpdateCar_WhenUpdateData()
        {
          

            var guid = new Guid("111d934e-6446-4a36-f201-516eb63d1123");

            CarDto dto = MockCarData();

           
            CarDto car = new();

            car.Id = Guid.Parse("111d934e-6446-4a36-f201-516eb63d1123");
            car.Model = "asd";
            car.Brand = "1024";
            car.Year = 2003;
            car.Price = 333;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;



            await Svc<ICarsServices>().Update(dto);

            Assert.Equal(car.Id, guid);
            Assert.DoesNotMatch(car.Model, dto.Model);
            Assert.DoesNotMatch(car.Brand.ToString(), dto.Brand.ToString());
            Assert.Equal(car.Year, dto.Year);
        }






        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {
            CarDto dto = MockCarData();
            var createCar = await Svc<ICarsServices>().Create(dto);

            CarDto nullUpdate = MockNullCar();
            var result = await Svc<ICarsServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }


        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                Brand = "asd",
                Model = "bcd",
                Year = 2003,
                Price = 3,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return car;
        }

        private CarDto MockUpdateCarData()
        {
            CarDto car = new()
            {
                Brand = "asdasd",
                Model = "bcdbcd",
                Year = 53,
                Price = 300,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return car;
        }

        private CarDto MockNullCar()
        {
            CarDto nullDto = new()
            {
                Id = null,
                Brand = "Brand123",
                Model = "opopopo",
                Year = 123,
                Price = 123,
                CreatedAt = DateTime.Now.AddYears(-1),
                ModifiedAt = DateTime.Now.AddYears(-1),
            };

            return nullDto;
        }
    }
}
