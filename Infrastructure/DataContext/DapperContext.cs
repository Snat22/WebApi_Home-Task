using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string _connectionString = $"Server = localhost;Port = 5432; Database=HomeTaskWebApi2_db;User Id=postgres;Password=11223344;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
