using FluentValidation;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Validation
{
    public class SocialInteractionValidation : AbstractValidator<SocialInteractionDto>
    {
        public SocialInteractionValidation()
        {
            RuleFor(socialInteraction => socialInteraction.Name)
                .NotEmpty().WithMessage("Name can't be left blank")
                .MinimumLength(3).WithMessage("Name can't be less than 3 characters")
                .MaximumLength(50).WithMessage("Name can'exceed 50 characters");

            RuleFor(socialInteraction => socialInteraction.Place)
                .NotEmpty().WithMessage("Place can't be left blank")
                .MinimumLength(3).WithMessage("Place can't be less than 3 characters")
                .MaximumLength(100).WithMessage("Place can'exceed 100 characters");

            RuleFor(socialInteraction => socialInteraction.Description)
                .NotEmpty().WithMessage("Description can't be left blank")
                .MinimumLength(10).WithMessage("Description can't be less than 3 characters")
                .MaximumLength(200).WithMessage("Description can'exceed 200 characters");
        }
    }
}
