using Microsoft.AspNetCore.Mvc;
using WeeLink_API.Utils.Context;
using WeeLink_Domain.Entities.User;

namespace WeeLink_API.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly ContextDb _contextDb;

        public UsersController(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        [HttpGet]
        public IActionResult Index([FromBody] User newUser)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "teste",
                Email = "teste2",
                Password = "123Teste",
                CreatedAt = DateTime.Now
            };

            // Adiciona o novo usuário ao contexto do banco de dados e salva as alterações
            _contextDb.User.Add(user);
            _contextDb.SaveChanges();

            // Retorna uma resposta HTTP indicando que o usuário foi adicionado com sucesso
            return Ok();

        }
    }
}
