using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.ValidationRules.FluentValidation
{
    public class EmployeeDevicesValidator : AbstractValidator<EmployeeDevice>
    {
        public EmployeeDevicesValidator()
        {
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("Personel Alanı Boş Geçilemez.");
            RuleFor(p => p.EmployeeId).NotNull().WithMessage("Personel Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceId).NotNull().WithMessage("Cihaz Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceId).NotEmpty().WithMessage("Cihaz Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceIdentity).NotEmpty().WithMessage("Cihaz ID Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceIdentity).NotNull().WithMessage("Cihaz ID Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceName).NotNull().WithMessage("Cihaz İsmi Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceName).NotEmpty().WithMessage("Cihaz İsmi Alanı Boş Geçilemez.");

        }
    }
}
