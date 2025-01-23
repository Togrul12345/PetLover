using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.Dtos
{
    public class CreateMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public IFormFile Img { get; set; }
    }
    public class CreateMemberValidator : AbstractValidator<CreateMemberDto>
    {
        public CreateMemberValidator()
        {
            RuleFor(a => a.Name).MinimumLength(3).WithMessage("min length must be 3");
            RuleFor(a => a.Profession).MinimumLength(3).WithMessage("min length must be 3");
            RuleFor(a => a.Img).NotEmpty().NotNull().WithMessage("Cannot be null or empty");
        }
    }
}
