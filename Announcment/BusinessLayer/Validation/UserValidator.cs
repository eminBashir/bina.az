using BusinessLayer.DTO.RequestDTO;
using DataLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class UserValidator : AbstractValidator<CreateUserDTO>
    {
        public UserValidator()
        {
            RuleFor(reg => reg.UserName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(20);
            RuleFor(x => x.RepeatPassword).NotEmpty().MinimumLength(8).MaximumLength(20);
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(10);
        }
    }
}
