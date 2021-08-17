using FluentValidation;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.ValidationRules.FluentValidation
{
    public class DeviceValidator : AbstractValidator<Device>
    {
        public DeviceValidator()
        {
            RuleFor(p => p.DeviceIdentity).NotEmpty().WithMessage("Cihaz ID Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceIdentity).NotNull().WithMessage("Cihaz ID Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceIdentity).Length(17, 30).WithMessage("Cihaz ID En az 17 En fazla 30 Karakter Olmalıdır.");
            RuleFor(p => p.DeviceTypeId).NotEmpty().WithMessage("Cihaz Türü Seçmelisiniz.");
            RuleFor(p => p.DeviceTypeId).NotNull().WithMessage("Cihaz Türü Seçmelisiniz.");
            RuleFor(p => p.RegionId).NotEmpty().WithMessage("Cihaz Bölgesi Seçmelisiniz.");
            RuleFor(p => p.RegionId).NotNull().WithMessage("Cihaz Bölgesi Seçmelisiniz.");
            RuleFor(p => p.DeviceStatus).NotEmpty().WithMessage("Cihaz Durumu Seçmelisiniz.");
            RuleFor(p => p.DeviceStatus).NotNull().WithMessage("Cihaz Durumu Seçmelisiniz.");
            RuleFor(p => p.Maintenance).NotEmpty().WithMessage("Cihaz Bakım Durumu Seçmelisiniz.");
            RuleFor(p => p.Maintenance).NotNull().WithMessage("Cihaz Bakım Durumu Seçmelisiniz.");
            RuleFor(p => p.DeviceName).NotEmpty().WithMessage("Cihaz İsmi Alanı Boş Geçilemez.");
            RuleFor(p => p.DeviceName).NotNull().WithMessage("Cihaz İsmi Alanı Boş Geçilemez.");
        }
    }
}
