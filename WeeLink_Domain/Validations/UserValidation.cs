using FluentValidation;
using WeeLink_Domain.Entities.User;

namespace WeeLink_Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            //Empty Fields
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorRegisterUser.Name_Empty);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceErrorRegisterUser.Email_Empty);
            RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceErrorRegisterUser.Password_Empty);

            //Invalid Fields
            When(user => !string.IsNullOrWhiteSpace(user.Email), () =>
            {
                RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceErrorRegisterUser.Email_Invalid);
            });

            When(user => !string.IsNullOrWhiteSpace(user.Password), () =>
            {
                RuleFor(user => user.Password.Length).GreaterThan(6).WithMessage(ResourceErrorRegisterUser.Password_Invalid);
            });

        }
    }
}
