using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Dtos.SliderDtos
{
    public class SliderPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile BackgroundFile { get; set; }
        public IFormFile SignatureFile { get; set; }

    }

    public class SliderPostDtoValidator : AbstractValidator<SliderPostDto>
    {
        public SliderPostDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.SignatureFile).NotNull();
            RuleFor(x => x.BackgroundFile).NotNull();

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.BackgroundFile != null)
                {
                    if (x.BackgroundFile.Length > 2097152)
                    {
                        context.AddFailure(nameof(x.BackgroundFile), "Background image file must be less than 2MB.");
                    }

                    if (x.BackgroundFile.ContentType != "image/jpeg" && x.BackgroundFile.ContentType != "image/png")
                    {
                        context.AddFailure(nameof(x.BackgroundFile), "Background image file must be image/jpeg and image/png.");
                    }
                }

                if (x.SignatureFile != null)
                {
                    if (x.SignatureFile.Length > 2097152)
                    {
                        context.AddFailure(nameof(x.SignatureFile), "SignatureImage image file must be less than 2MB.");
                    }

                    if (x.SignatureFile.ContentType != "image/jpeg" && x.SignatureFile.ContentType != "image/png")
                    {
                        context.AddFailure(nameof(x.SignatureFile), "SignatureImage image file must be image/jpeg and image/png.");
                    }
                }
            });


        }
    }
}
