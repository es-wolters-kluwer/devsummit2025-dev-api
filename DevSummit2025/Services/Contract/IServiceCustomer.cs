using DevSummit2025.Model;

namespace DevSummit2025.Services.Contract
{
    public interface IServiceCustomer
    {
        Task<List<CustomerDto>> GetAll();
        Task<string> GetNew();
        Task Create();
    }
}
