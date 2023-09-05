using DemoInjecaoDependencias.Models;

namespace DemoInjecaoDependencias.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(string customerId);
    }
}
