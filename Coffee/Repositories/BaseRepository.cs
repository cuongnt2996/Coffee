using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Coffee.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Coffee.Repositories;

/// <summary>
/// A minimal Dapper-backed base repository. Assumes simple primary key named Id.
/// For more complex scenarios override methods in derived repositories.
/// </summary>
public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly string _tableName;

    public BaseRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
        var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();//lấy thuộc tính(Tên bảng) của class
        _tableName = tableAttr?.Name ?? typeof(T).Name; // Convention: table name equals entity class name
    }

    public async Task<int> AddAsync(T entity)
    {
        using var conn = _connectionFactory.CreateConnection();
        var insertSql = SqlBuilder.BuildInsert(_tableName, entity);
        return await conn.ExecuteAsync(insertSql.sql, insertSql.parameters);
    }

    public async Task<int> DeleteAsync(object id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = $"DELETE FROM [{_tableName}] WHERE Id = @Id";
        return await conn.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = $"SELECT * FROM [{_tableName}]";
        return await conn.QueryAsync<T>(sql);
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = $"SELECT * FROM [{_tableName}] WHERE Id = @Id";
        return await conn.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
    }

    public async Task<int> UpdateAsync(T entity)
    {
        using var conn = _connectionFactory.CreateConnection();
        var updateSql = SqlBuilder.BuildUpdate(_tableName, entity);
        return await conn.ExecuteAsync(updateSql.sql, updateSql.parameters);
    }
}
