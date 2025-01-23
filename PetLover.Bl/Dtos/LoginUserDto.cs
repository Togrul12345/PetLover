using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.Dtos
{
    public class LoginUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(a => a.Email).MinimumLength(4).WithMessage("min length must be 4");
        }
    }
}
