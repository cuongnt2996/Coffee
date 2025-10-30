using Coffee.Data;
using Coffee.Models;
using Dapper;

namespace Coffee.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public EmployeeRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Employee?> GetByEmployeeCodeAsync(string code)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = "SELECT * FROM Employees WHERE EmployeeCode = @Code";
        return await conn.QuerySingleOrDefaultAsync<Employee>(sql, new { Code = code });
    }

    public async Task<IEnumerable<Employee>> GetByDepartmentAsync(string department)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = "SELECT * FROM Employees WHERE Department = @Department";
        return await conn.QueryAsync<Employee>(sql, new { Department = department });
    }

    public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = "SELECT * FROM Employees WHERE Status = 'Active'";
        return await conn.QueryAsync<Employee>(sql);
    }
}