using Dapper;
using Domain.Contracts.DbContext;
using Domain.Contracts.Repositories.AddCustomer;
using Domain.Entities;

namespace Infra.Repositories.AddCustomer
{
    public class AddCustomerRepository : IAddCustomerRepository
    {
        private readonly IDbContext _dbContext;

        public AddCustomerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            var query = @"
                INSERT INTO Customer(name, email, document)
                VALUES(@name, @email, @document)
            ";

            var parameters = new DynamicParameters();
            parameters.Add("name", customer.Name, System.Data.DbType.String);
            parameters.Add("email", customer.Email, System.Data.DbType.String);
            parameters.Add("document", customer.Document, System.Data.DbType.String);

            using var connection = _dbContext.CreateConnection();

            var retorno = await connection.ExecuteAsync(query, parameters);

            return retorno;
        }
    }
}
