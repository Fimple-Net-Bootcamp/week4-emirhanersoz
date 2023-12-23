using FluentValidation;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Validation
{
    public class FoodValidation : AbstractValidator<FoodDto>
    {
        public FoodValidation() 
        {
            RuleFor(food => food.Name)
                .NotEmpty().WithMessage("Name can't be left blank")
                .MinimumLength(3).WithMessage("Name can't be less than 3 characters")
                .MaximumLength(50).WithMessage("Name can'exceed 50 characters");

            RuleFor(food => food.HealthBonus)
                    .NotEmpty().WithMessage("HealthBonus can't be left blank")
                    .InclusiveBetween(0, 100).WithMessage("HealthBonus must be between 0 and 100");

            RuleFor(food => food.HungerReduction)
                    .NotEmpty().WithMessage("HungerReduction can't be left blank")
                    .InclusiveBetween(0, 100).WithMessage("HungerReduction must be between 0 and 100");

            RuleFor(food => food.ExpirationDate)
                    .NotEmpty().WithMessage("ExpirationDate can't be left blank");
        }
    }
}
