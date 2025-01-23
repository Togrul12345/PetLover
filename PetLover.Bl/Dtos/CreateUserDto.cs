using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.Dtos
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class CreateAppUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateAppUserValidator()
        {
            RuleFor(a => a.Email).MinimumLength(4).WithMessage("min length must be 4");
            RuleFor(a => a.Password).Equal(a => a.ConfirmPassword).WithMessage("Password must be equal to Confirmpassword");
            RuleFor(a => a.UserName).MinimumLength(3).WithMessage("min length must be 3");
        }
    }
}
