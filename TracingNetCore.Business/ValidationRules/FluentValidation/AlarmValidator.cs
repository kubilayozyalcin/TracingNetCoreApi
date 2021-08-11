using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.ValidationRules.FluentValidation
{
    public class AlarmValidator : AbstractValidator<Alarm>
    {
        public AlarmValidator()
        {
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("Personel Alanı Boş Geçilemez.");
            RuleFor(p => p.EmployeeId).NotNull().WithMessage("Personel Alanı Boş Geçilemez.");

        }
    }
}
