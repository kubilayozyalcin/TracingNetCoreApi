using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.ValidationRules.FluentValidation
{
    public class DeviceTypeValidator : AbstractValidator<DeviceType>
    {
        public DeviceTypeValidator()
        {
            RuleFor(p => p.DeviceTypeName).NotEmpty().WithMessage("Cihaz Türü Adı Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceTypeName).NotNull().WithMessage("Cihaz Türü Adı Alanı Boş Geçilemez.");

        }
    }
}
