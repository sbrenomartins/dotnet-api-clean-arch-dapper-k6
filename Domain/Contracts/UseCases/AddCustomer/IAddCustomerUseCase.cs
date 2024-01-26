using Domain.Entities;

namespace Domain.Contracts.UseCases.AddCustomer
{
    public interface IAddCustomerUseCase
    {
        Task<int> AddCustomer(Customer customer);
    }
}
