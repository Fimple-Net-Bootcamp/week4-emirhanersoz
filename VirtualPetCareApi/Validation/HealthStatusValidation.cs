using FluentValidation;
using VirtualPetCareApi.Dtos;

namespace VirtualPetCareApi.Validation
{
    public class HealthStatusValidation : AbstractValidator<HealthStatusDto>
    {
        public HealthStatusValidation()
        {
            RuleFor(healthStatus => healthStatus.Health)
                .NotEmpty().WithMessage("Health can't be left blank")
                .InclusiveBetween(0, 100).WithMessage("Health must be between 0 and 100");

            RuleFor(healthStatus => healthStatus.HappinessLevel)
                .NotEmpty().WithMessage("HappinessLevel can't be left blank")
                .InclusiveBetween(0, 100).WithMessage("HappinessLevel must be between 0 and 100");

            RuleFor(healthStatus => healthStatus.HungerLevel)
                .NotEmpty().WithMessage("HungerLevel can't be left blank")
                .InclusiveBetween(0, 100).WithMessage("HungerLevel must be between 0 and 100");

            RuleFor(healthStatus => healthStatus.CleanlinessLevel)
                .NotEmpty().WithMessage("CleanlinessLevel can't be left blank")
                .InclusiveBetween(0, 100).WithMessage("CleanlinessLevel must be between 0 and 100");
        }
    }
}
