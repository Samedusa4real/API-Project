using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Dtos.CategoryDtos
{
    public class CategoryPutDto
    {
        public string Name { get; set; }
    }

    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}
