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
    
    public async Task<CalculationLogEntry> GetLogEntry(string operation, double n1, double n2, double result)
    {
        using (var conn = new NpgsqlConnection(_connString))
        {
            const string sql = @"
                    SELECT operation, number1, number2, result
                    FROM calculations
                    WHERE operation = @Operation AND number1 = @Number1 AND number2 = @Number2 AND result = @Result
                    LIMIT 1;
                ";

            var parameters = new { Operation = operation, Number1 = n1, Number2 = n2, Result = result };
            var logEntry = await conn.QueryFirstOrDefaultAsync<CalculationLogEntry>(sql, parameters);
            return logEntry;
        }
    }
}

public class CalculationLogEntry
{
    public string Operation { get; set; }
    public double Number1 { get; set; }
    public double Number2 { get; set; }
    public double Result { get; set; }
}