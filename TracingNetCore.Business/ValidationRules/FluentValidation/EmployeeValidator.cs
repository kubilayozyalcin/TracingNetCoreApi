using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.Identity).NotEmpty().WithMessage("Personel TC Alanı Boş Geçilemez.");
            RuleFor(p => p.Identity).MaximumLength(11).WithMessage("Personel TC 11 Karakter Olmalıdır.");
            RuleFor(p => p.Identity).MinimumLength(11).WithMessage("Personel TC 11 Karakter Olmalıdır.");
            RuleFor(p => p.Identity).NotNull().WithMessage("Personel TC Alanı Boş Geçilemez.");
            RuleFor(p => p.FullName).NotEmpty().WithMessage("Personel Adı - Soyadı Alanı Boş Geçilemez.");
            RuleFor(p => p.FullName).NotNull().WithMessage("Personel Adı - Soyadı Alanı Boş Geçilemez.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Personel Email Alanı Boş Geçilemez.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçersiz Email Adresi Türü.");
            RuleFor(p => p.Email).NotNull().WithMessage("Personel Email Alanı Boş Geçilemez.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Personel Telefon Alanı Boş Geçilemez.");
            RuleFor(p => p.PhoneNumber).NotNull().WithMessage("Personel Telefon Alanı Boş Geçilemez.");
            RuleFor(p => p.PhoneNumber).MaximumLength(10).WithMessage("Personel Telefon 10 Karakter Olmalıdır.");
            RuleFor(p => p.PhoneNumber).MinimumLength(10).WithMessage("Personel Telefon 10 Karakter Olmalıdır.");
        }
    }
}
