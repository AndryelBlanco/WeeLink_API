using Microsoft.AspNetCore.Mvc;
using WeeLink_API.Utils.Context;
using WeeLink_Domain.Entities.User;
using WeeLink_Domain.UseCases;
using WeeLink_Domain.Validations;

namespace WeeLink_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ContextDb _contextDb;

        public UserController(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                Name = "UEe",
                Email = "uee",
                Password = "ueee",
                CreatedAt = DateTime.Now,
            };

            _contextDb.User.Add(newUser);
            _contextDb.SaveChanges();

            return Ok();
        }


        [HttpPost]
        public IActionResult RegisterUser([FromBody] User inputData)
        {
            if (inputData == null) return BadRequest("Não foi informado um usuário válido");

            try
            {
                var inputedUser = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = inputData.Name,
                    Email = inputData.Email,
                    Password = inputData.Password,
                    CreatedAt = DateTime.Now
                };

                var registerUseCase = new UserRegisterUseCase();

                var result = registerUseCase.ValidateUserRegister(inputedUser);

                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                inputedUser = registerUseCase.EncryptUserPassword(inputedUser);

                _contextDb.User.Add(inputedUser);
                _contextDb.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
