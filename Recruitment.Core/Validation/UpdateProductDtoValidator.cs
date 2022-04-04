using FluentValidation;
using Recruitment.Api;

namespace Recruitment.Core.Validation
{
    public class UpdateProductDtoValidator: AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Description).MaximumLength(200);
        }
    }
}
