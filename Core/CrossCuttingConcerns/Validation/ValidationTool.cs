using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {

        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); // Burada nesneyi doğrulamak için alıyorum ve context değişkenin içine atıyorum

            var result = validator.Validate(context);//Burada Contextim kurallardan geçiyormu diyorum ve sonucu result değişkenine atıyorum

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);//Eğer Sonuc geçmediyse valid değilse hata fırlat diyorum
            }
        }

    }
}
