using Dapper;
using Npgsql;

namespace Calculator;

public class Database
{
    private readonly string _connString;

    public Database()
    {
        _connString = Environment.GetEnvironmentVariable("ConnectionString")!;
        
        if (string.IsNullOrEmpty(_connString))
        {
            throw new InvalidOperationException("The connection string environment variable 'ConnectionString' is not set.");
        }
    }

    public async Task Log(string operation, double n1, double n2, double result)
    {
        using (var conn = new NpgsqlConnection(_connString))
        {
            const string sql = @"
                INSERT INTO calculations (operation, number1, number2, result) 
                VALUES (@Operation, @Number1, @Number2, @Result);
            ";

            var parameters = new { Operation = operation, Number1 = n1, Number2 = n2, Result = result };
            await conn.ExecuteAsync(sql, parameters);
        }
    }
}