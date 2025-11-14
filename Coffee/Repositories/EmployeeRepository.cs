using Coffee.Data;
using Coffee.Models;
using Dapper;
using System.Linq;

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
        var sql = "SELECT E.Id, E.EmployeeCode, E.FirstName, E.LastName, E.DateOfBirth, E.PhoneNumber, E.Address, E.JoinDate, E.Department, E.Position, E.Salary, E.TerminationDate, S.StatusName As Status FROM Employees E with(NOLOCK) INNER JOIN EmployeeStatus S WITH(NOLOCK) ON E.Status = S.StatusId";
        return await conn.QueryAsync<Employee>(sql);
    }

    public async Task<IEnumerable<EmployeeStatus>> GetEmployeeStatusesAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = "SELECT * FROM EmployeeStatus WITH(NOLOCK) ORDER BY OrderNo";
        return await conn.QueryAsync<EmployeeStatus>(sql);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"        SELECT 
            E.Id,
            E.EmployeeCode,
            E.FirstName,
            E.LastName,
            E.DateOfBirth,
            E.PhoneNumber,
            E.Address,
            E.JoinDate,
            E.Department,
            E.Position,
            E.Salary,
            E.StatusId,
            E.TerminationDate,
            S.StatusId,
            S.StatusCode,
            S.StatusName,
            S.Description,
            S.OrderNo,
            S.IsActive,
            S.IsDeleted,
            S.CreatedDate,
            S.ModifiedDate
        FROM Employee E WITH (NOLOCK)
        INNER JOIN EmployeeStatus S WITH (NOLOCK) ON E.StatusId = S.StatusId";
        var employees = await conn.QueryAsync<Employee, EmployeeStatus, Employee>(
            sql,
            (emp, status) =>
            {
                emp.Status = status;
                return emp;
            },
            splitOn: "StatusId");
        return employees;
    }

    // public new async Task<Employee?> GetByIdAsync(object id)
    // {
    //     using var conn = _connectionFactory.CreateConnection();
    //     var sql = "SELECT E.Id, E.EmployeeCode, E.FirstName, E.LastName, E.DateOfBirth, E.PhoneNumber, E.Address, E.JoinDate, E.Department, E.Position, E.Salary, E.TerminationDate, S.StatusName As Status, E.Status As StatusId FROM Employee E with(NOLOCK) INNER JOIN EmployeeStatus S WITH(NOLOCK) ON E.Status = S.StatusId WHERE E.Id = @Id";
    //     return await conn.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
    public new async Task<Employee?> GetByIdAsync(object id)
    {
        using var conn = _connectionFactory.CreateConnection();

        var sql = @"
        SELECT 
            E.Id,
            E.EmployeeCode,
            E.FirstName,
            E.LastName,
            E.DateOfBirth,
            E.PhoneNumber,
            E.Address,
            E.JoinDate,
            E.Department,
            E.Position,
            E.Salary,
            E.StatusId,
            E.TerminationDate,
            S.StatusId,
            S.StatusCode,
            S.StatusName,
            S.Description,
            S.OrderNo,
            S.IsActive,
            S.IsDeleted,
            S.CreatedDate,
            S.ModifiedDate
        FROM Employee E WITH (NOLOCK)
        INNER JOIN EmployeeStatus S WITH (NOLOCK) ON E.StatusId = S.StatusId
        WHERE E.Id = @Id";

        var employees = await conn.QueryAsync<Employee, EmployeeStatus, Employee>(
            sql,
            (emp, status) =>
            {
                emp.Status = status;
                return emp;
            },
            new { Id = id },
            splitOn: "StatusId"
        );

        return employees.FirstOrDefault();
    }
    public new async Task<int> AddAsync(Employee entity)
{
    using var conn = _connectionFactory.CreateConnection();

    var sql = @"
        INSERT INTO Employee (
            EmployeeCode,
            FirstName,
            LastName,
            DateOfBirth,
            PhoneNumber,
            Address,
            JoinDate,
            Department,
            Position,
            Salary,
            StatusId,
            TerminationDate
        )
        VALUES (
            @EmployeeCode,
            @FirstName,
            @LastName,
            @DateOfBirth,
            @PhoneNumber,
            @Address,
            @JoinDate,
            @Department,
            @Position,
            @Salary,
            @StatusId,
            @TerminationDate
        );
        SELECT CAST(SCOPE_IDENTITY() as int);";

    // Trả về Id vừa insert
    var newId = await conn.ExecuteScalarAsync<int>(sql, entity);
    return newId;
}
}
