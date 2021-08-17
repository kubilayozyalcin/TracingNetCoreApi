using FluentValidation;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.ValidationRules.FluentValidation
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(p => p.DeviceIdentity).NotEmpty().WithMessage("Cihaz ID Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceIdentity).NotNull().WithMessage("Cihaz ID Alanı Boş Geçilemez.");
            RuleFor(p => p.CreateDate).NotEmpty().WithMessage("İstek Zamanı Boş Geçilemez.");
            RuleFor(p => p.CreateDate).NotNull().WithMessage("İstek Zamanı Boş Geçilemez.");
            RuleFor(p => p.RequestCode).NotEmpty().WithMessage("İstek Kodu Alanı Boş Geçilemez.");
            RuleFor(p => p.RequestCode).NotNull().WithMessage("İstek Kodu Alanı Boş Geçilemez.");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("İstek Gönderen Alanı Boş Geçilemez.");
            RuleFor(p => p.EmployeeId).NotNull().WithMessage("İstek Gönderen Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceId).NotEmpty().WithMessage("İstek Gönderilen Cihaz Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceId).NotNull().WithMessage("İstek Gönderilen Cihaz Alanı Boş Geçilemez.");
            RuleFor(p => p.RequestCode).Must(StartWith).WithMessage("İstek Kodu # ile başlamalıdır.");

        }

        private bool StartWith(string arg)
        {
            return arg.StartsWith("#");
        }
    }
}
