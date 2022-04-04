using FluentValidation;
using Recruitment.Api;



namespace Recruitment.Core.Validation
{
    public class AddProductDtoValidator:AbstractValidator<AddProductDto>
    {
        public AddProductDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(200);
            RuleFor(x=>x.Price).NotEmpty();
        }
    }
}
