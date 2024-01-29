using BusinessLogic.DTOs;
using DataAccess.Data.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.CategoryId)
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can not be negative.");

            RuleFor(x => x.Discount)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can not be negative.");

            RuleFor(x => x.Description)
                .Length(10, 4000)
                .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .Must(LinkMustBeAUri).WithMessage("{PropertyName} must be a valid URL address.");
        }

        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
