using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMomoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMomoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2019,DailyPrice=500000,Description="Sol Ön Çaamurluk Lokal Boya" },
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2018,DailyPrice=450000,Description="Hatasız" },
                new Car{Id=3,BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=600000,Description="Doktordan" },
                new Car{Id=4,BrandId=1,ColorId=3,ModelYear=2010,DailyPrice=200000,Description="Dosta Gider" }
            };
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
