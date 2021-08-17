using FluentValidation;
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
