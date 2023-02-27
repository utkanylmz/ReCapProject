using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //Burada IValidator tipinde bir validator istiyoruz gelen validator yanlışsa hata fırlatıyoruz hata fırlamazsa construcator içinde set ediyoruz
            //
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                //throw new System.Exception(AspectMessages.WrongValidationType);
                throw new System.Exception("Bu  doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //MethodInterception içindeki on before metodunu override edip dolduruyoruz
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection çalışma anındactordan gelen değere göre intance olusturuyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//ctordan gelen değerin ana sınıfını bul vegeneric parametrelerinde ilkini al
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
