using Api.Controllers;
using Api.DataAccess.Models;
using Api.DataAccess.Repositories;
using NSubstitute;

namespace Api.Tests;

public class UserControllerTests
{
    private readonly IUserRepository _repository;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _repository = Substitute.For<IUserRepository>();
        _controller = new UserController(_repository);
    }

    [Fact]
    public async Task GetUsers_ReturnsUsersFromRepository()
    {
        var expectedUsers = new List<User>
        {
            new() { Id = "1", FirstName = "John", LastName = "Doe", Email = "john@example.com" },
            new() { Id = "2", FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }
        };
        _repository.GetUsersAsync().Returns(expectedUsers);

        var result = await _controller.GetUsers();

        Assert.Equal(2, result.Count);
        Assert.Equal("John", result[0].FirstName);
        Assert.Equal("Jane", result[1].FirstName);
    }

    [Fact]
    public async Task GetUsers_ReturnsEmptyList_WhenNoUsers()
    {
        _repository.GetUsersAsync().Returns(new List<User>());

        var result = await _controller.GetUsers();

        Assert.Empty(result);
    }
}
