using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;

namespace Coffee.Repositories;

internal static class SqlBuilder
{
    public static (string sql, object parameters) BuildInsert<T>(string tableName, T entity)
    {
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        var columns = string.Join(", ", props.Select(p => $"[{p.Name}]") );
        var paramNames = string.Join(", ", props.Select(p => $"@{p.Name}"));
        var sql = $"INSERT INTO [{tableName}] ({columns}) VALUES ({paramNames})";
        var parameters = new DynamicParameters();
        foreach (var p in props)
        {
            parameters.Add(p.Name, p.GetValue(entity));
        }

        return (sql, parameters);
    }

    public static (string sql, object parameters) BuildUpdate<T>(string tableName, T entity)
    {
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var key = props.FirstOrDefault(p => string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase))
                  ?? throw new InvalidOperationException("Entity must have an Id property for Update");

        var setProps = props.Where(p => !string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase)).ToArray();
        var setClause = string.Join(", ", setProps.Select(p => $"[{p.Name}] = @{p.Name}"));
        var sql = $"UPDATE [{tableName}] SET {setClause} WHERE [{key.Name}] = @{key.Name}";

        var parameters = new DynamicParameters();
        foreach (var p in props)
        {
            parameters.Add(p.Name, p.GetValue(entity));
        }

        return (sql, parameters);
    }
}
