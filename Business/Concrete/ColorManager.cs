using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete1
{
     public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager (IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [SecuredOperation("color.add,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult();
        }
        [SecuredOperation("color.delete,admin")]
        public IResult DeleteColor(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return  new SuccessDataResult<List<Color>> ( _colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=>c.ColorId==id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("color.update,admin")]
        public IResult UpdateColor(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
