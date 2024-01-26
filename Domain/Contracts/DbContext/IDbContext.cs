using System.Data;

namespace Domain.Contracts.DbContext
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }
}
