using Domain.Entities;

namespace Domain.Contracts.Repositories.AddCustomer
{
    public interface IAddCustomerRepository
    {
        Task<int> AddCustomer(Customer customer);
    }
}
