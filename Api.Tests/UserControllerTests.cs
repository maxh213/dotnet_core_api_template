using Api.Controllers;
using Api.DataAccess.Models;
using Api.DataAccess.Repositories;
using Moq;

namespace Api.Tests;

public class UserControllerTests
{
    private readonly Mock<IUserRepository> _mockRepository;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _mockRepository = new Mock<IUserRepository>();
        _controller = new UserController(_mockRepository.Object);
    }

    [Fact]
    public async Task GetUsers_ReturnsUsersFromRepository()
    {
        var expectedUsers = new List<User>
        {
            new() { Id = "1", FirstName = "John", LastName = "Doe", Email = "john@example.com" },
            new() { Id = "2", FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }
        };
        _mockRepository.Setup(r => r.GetUsersAsync()).ReturnsAsync(expectedUsers);

        var result = await _controller.GetUsers();

        Assert.Equal(2, result.Count);
        Assert.Equal("John", result[0].FirstName);
        Assert.Equal("Jane", result[1].FirstName);
    }

    [Fact]
    public async Task GetUsers_ReturnsEmptyList_WhenNoUsers()
    {
        _mockRepository.Setup(r => r.GetUsersAsync()).ReturnsAsync([]);

        var result = await _controller.GetUsers();

        Assert.Empty(result);
    }
}
