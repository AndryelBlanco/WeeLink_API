using System.ComponentModel.DataAnnotations;
using WeeLink_Domain.Entities.User;
using WeeLink_Domain.Validations;
using WeeLink_Infrastructure.Criptography;

namespace WeeLink_Domain.UseCases;

public class UserRegisterUseCase
{
    
    public FluentValidation.Results.ValidationResult ValidateUserRegister(User inputedUser)
    {

        var validator = new UserValidation();

        var result = validator.Validate(inputedUser);

        return result;
    }


    public User EncryptUserPassword(User inputedUser)
    {
        var passwordEncrypt = new PasswordEncrypt();

        inputedUser.Password = passwordEncrypt.Encrypt(inputedUser.Password);

        return inputedUser;
    }
}
