using Business.Concrete1;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.AddRental(new Rental { CarId = 5, CustomerId = 3, RentDate = DateTime.Now });

            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.Id + " " + rental.RentDate+" "+rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }










            //CarCrudPlusGetMethods();


            //ColorCrudAndGetMethods();


            //BrandCrudAndGetMethods();

            //CarManager carManager = new CarManager(new EfCarDal());



            //foreach (var car in carManager.GetCarDetailDtos())
            //{
            //    Console.WriteLine(car.Id+" "+car.BrandName+" "+car.ColorName+" "+car.DailyPrice);
            //}










            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.AddUser(new User { FirstName = "Hasan Ali", LastName = "Yücel", Email = "Hay@hotmail.com", Password = "123123" });

            //var result = userManager.GetAll();
            //if (result.Success == true)
            //{
            //    foreach (var user in result.Data)
            //    {
            //        Console.WriteLine(user.FirstName+" "+user.LastName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}









            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.AddCustomer(new Customer { UserId = 1, CompanyName = "Abc Company" });
            //customerManager.AddCustomer(new Customer { UserId = 2, CompanyName = "Zorka Company" });
            //customerManager.AddCustomer(new Customer { UserId = 3, CompanyName = "Yılmaz Company" });
            //customerManager.AddCustomer(new Customer { UserId = 4, CompanyName = "Utkan Company" });


            //var result = customerManager.GetAll();
            //if (result.Success == true)
            //{
            //    foreach (var customer in result.Data)
            //    {
            //        Console.WriteLine(customer.CompanyName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}


        }

        private static void BrandCrudAndGetMethods()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.DeleteBrand(new Brand {BrandId=9,  Name = "Honda" });
            //Console.WriteLine(brandManager.GetById(8).BrandName);

            var result = brandManager.GetAll();
            if (result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorCrudAndGetMethods()
        {
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            ////colorManager.DeleteColor(new Color { ColorId = 7, ColorName = "Pemebe" });

            //Console.WriteLine(colorManager.GetById(2).ColorName);

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}
        }

        private static void CarCrudPlusGetMethods()
        {
            //CarManager carManager = new CarManager(new EfCarDal());

            //carManager.DeleteCar(new Car { Id = 5, BrandId = 2, ColorId = 1, ModelYear = 1999, DailyPrice = 1000, Description = "Deneme1" });

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine(carManager.GetById(2).Description);
        }
    }
}
