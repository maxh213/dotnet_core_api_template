using Dapper;
using Npgsql;
using Api.DataAccess.Models;
using Api.DataAccess.Repositories;
using Microsoft.Extensions.Options;

namespace Api.DataAccess.Repositories.Database;

public class PostgresRepository : IUserRepository
{
    private readonly string _connectionString;

    public PostgresRepository(IOptions<ConnectionStrings> connectionStrings)
    {
        _connectionString = connectionStrings?.Value.DefaultConnection ?? string.Empty;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        var users = await connection.QueryAsync<User>("SELECT * FROM Users");
        return users.ToList();
    }

    public async Task InsertNewUserAsync(User user)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(
            "INSERT INTO Users (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)",
            user);
    }
}
