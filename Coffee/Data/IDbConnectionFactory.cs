using System.Data;

namespace Coffee.Data;

public interface IDbConnectionFactory
{
    /// <summary>
    /// Create and open a new DB connection. Caller should not dispose the connection if using DI-managed lifetime.
    /// </summary>
    IDbConnection CreateConnection();
}
