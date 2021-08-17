using FluentValidation;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.ValidationRules.FluentValidation
{
    public class RegionValidator : AbstractValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(p => p.AddressTitle).NotEmpty().WithMessage("Bölge Adı Alanı Boş Geçilemez.");
            RuleFor(p => p.AddressTitle).NotNull().WithMessage("Bölge Adı Alanı Boş Geçilemez.");
            RuleFor(p => p.Latitude).NotEmpty().WithMessage("GPS Latitude Boş Geçilemez.");
            RuleFor(p => p.Latitude).NotNull().WithMessage("GPS Latitude Boş Geçilemez.");
            RuleFor(p => p.Longitude).NotEmpty().WithMessage("GPS Longitude Alanı Boş Geçilemez.");
            RuleFor(p => p.Longitude).NotNull().WithMessage("GPS Longitude Alanı Boş Geçilemez.");
            RuleFor(p => p.FullAddress).NotEmpty().WithMessage("Tam Adres Alanı Boş Geçilemez.");
            RuleFor(p => p.FullAddress).NotNull().WithMessage("Tam Adres Alanı Boş Geçilemez.");

        }


    }
}
