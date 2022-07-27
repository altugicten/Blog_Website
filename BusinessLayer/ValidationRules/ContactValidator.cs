using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Maili boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Adı boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("3 karakterden az isim veremezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("3 harften az veremezsiniz");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("20 harften fazla veremezsiniz");
        }
    }
}
