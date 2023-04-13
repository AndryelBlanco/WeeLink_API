using Microsoft.AspNetCore.Mvc;
using WeeLink_API.Utils.Context;
using WeeLink_Domain.Entities.User;

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
    }
}
