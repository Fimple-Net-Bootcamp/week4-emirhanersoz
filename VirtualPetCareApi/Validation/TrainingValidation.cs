using FluentValidation;
using VirtualPetCareApi.Dtos;

namespace VirtualPetCareApi.Validation
{
    public class TrainingValidation : AbstractValidator<TrainingDto>
    {
        public TrainingValidation()
        {
            RuleFor(training => training.Name)
                .NotEmpty().WithMessage("Name can't be left blank")
                .MinimumLength(3).WithMessage("Name can't be less than 3 characters")
                .MaximumLength(50).WithMessage("Name can'exceed 50 characters");

            RuleFor(training => training.Fee)
                    .NotEmpty().WithMessage("Fee can't be left blank")
                    .GreaterThanOrEqualTo(0).WithMessage("Fee must be greater than or equal to 0.");

            RuleFor(training => training.Duration)
                    .NotEmpty().WithMessage("Duration can't be left blank");
        }
    }
}
