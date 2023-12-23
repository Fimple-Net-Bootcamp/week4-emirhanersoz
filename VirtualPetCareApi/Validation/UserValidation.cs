using FluentValidation;
using VirtualPetCareApi.Dtos;

namespace VirtualPetCareApi.Validation
{
    public class UserValidation : AbstractValidator<UserDto>
    {
        public UserValidation() 
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username can't be left blank")
                .MinimumLength(3).WithMessage("Username can't be less than 3 characters")
                .MaximumLength(30).WithMessage("Username can'exceed 30 characters");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password can't be left blank")
                .MinimumLength(5).WithMessage("Password can't be less than 5 characters")
                .MaximumLength(50).WithMessage("Password can't exceed 50 characters");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email can't be left blank")
                .MaximumLength(50).WithMessage("Email can't exceed 50 characters")
                .EmailAddress().WithMessage("Email must be in e-mail format");
        }
    }
}
