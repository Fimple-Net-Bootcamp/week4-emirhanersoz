using FluentValidation;
using VirtualPetCareApi.Dtos;

namespace VirtualPetCareApi.Validation
{
    public class ActivityValidation : AbstractValidator<ActivityDto>
    {
        public ActivityValidation()
        {
            RuleFor(activity => activity.Name)
                .NotEmpty().WithMessage("Name can't be left blank")
                .MinimumLength(3).WithMessage("Name can't be less than 3 characters")
                .MaximumLength(50).WithMessage("Name can'exceed 50 characters");

            RuleFor(activity => activity.HealthBonus)
                    .NotEmpty().WithMessage("HealthBonus can't be left blank")
                    .InclusiveBetween(0, 100).WithMessage("HealthBonus must be between 0 and 100");

            RuleFor(activity => activity.HappinessBonus)
                    .NotEmpty().WithMessage("HappinessBonus can't be left blank")
                    .InclusiveBetween(0, 100).WithMessage("HappinessBonus must be between 0 and 100");

            RuleFor(activity => activity.CleanlinessReduction)
                    .NotEmpty().WithMessage("CleanlinessReduction can't be left blank")
                    .InclusiveBetween(0, 100).WithMessage("CleanlinessReduction must be between 0 and 100");
        }
    }
}
