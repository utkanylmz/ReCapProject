using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete1
{
    class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfProductCount(), CheckIfCarNameExists(car.Description));

            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
        private IResult CheckIfProductCount()
        {
            var result = _carDal.GetAll().Count;
            if (result >= 20)
            {
                return new ErrorResult(Messages.CarCountIsMax);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarNameExists(string carDescription)
        {
            var result = _carDal.GetAll(c => c.Description == carDescription).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarDescriptionMustDifferent);
            }
            return new SuccessResult();
        }
    }
}
