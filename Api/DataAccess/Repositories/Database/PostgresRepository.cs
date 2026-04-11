using Dapper;
using Microsoft.Data.SqlClient;
using Api.DataAccess.Models;
using Microsoft.Extensions.Options;

namespace Api.DataAccess.Repositories.Database
{
    public class PostgresRepository
    {
        private readonly string _connectionString;
        private readonly string _useDatabase = "use imnotlovinit ";

        public PostgresRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionString = connectionStrings?.Value.Server ?? string.Empty;
        }

        public virtual List<User> GetUsers()
        {
            var queryString = _useDatabase + @"select * from Users";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var users = connection.Query<User>(queryString).ToList();
            return users;
        }

        public void InsertNewUser(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var queryString = _useDatabase +
                @"
                INSERT INTO Users (FirstName, LastName, Email)
                VALUES (@FirstName, @LastName, @Email)
                ";
            connection.Execute(queryString, user);
        }
    }
}
