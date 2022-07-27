using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Adı boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyadı boş geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("3ten az olamaz");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("20den fazla giremez");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("3ten az olamaz");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("20den fazla olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Açıklama boş olamaz!!");
        }
    }
}
