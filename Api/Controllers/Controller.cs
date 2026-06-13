using Api.DataAccess.Models;
using Api.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/v1/Users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("/all")]
    public async Task<List<User>> GetUsers()
    {
        return await _userRepository.GetUsersAsync();
    }
}
