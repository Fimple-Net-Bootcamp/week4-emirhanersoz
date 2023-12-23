using FluentValidation;
using VirtualPetCareApi.Dtos;

namespace VirtualPetCareApi.Validation
{
    public class PetValidation : AbstractValidator<PetDto>
    {
        public PetValidation()
        {
            RuleFor(pet => pet.Name)
                .NotEmpty().WithMessage("Name can't be left blank")
                .MinimumLength(3).WithMessage("Name can't be less than 3 characters")
                .MaximumLength(50).WithMessage("Name can't exceed 50 characters");

            RuleFor(pet => pet.Species)
                .NotEmpty().WithMessage("Species can't be left blank")
                .MinimumLength(3).WithMessage("Species can't be less than 3 characters")
                .MaximumLength(50).WithMessage("Species can't exceed 50 characters");

            RuleFor(pet => pet.Age)
                .NotEmpty().WithMessage("Name can't be left blank")
                .InclusiveBetween(0, 150).WithMessage("Age must be between 0 and 150");
        }
    }
}
