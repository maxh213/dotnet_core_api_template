using Api.DataAccess.Models;
using Api.DataAccess.Repositories.Database;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/Users")]
    public class UserController : ControllerBase
    {
        private readonly PostgresRepository _postgresRepository;

        public UserController(PostgresRepository postgresRepository)
        {
            _postgresRepository = postgresRepository;
        }

        [HttpGet("/all")]
        public List<User> GetUsers()
        {
            var users = _postgresRepository.GetUsers();
            return users;
        }
    }
}
