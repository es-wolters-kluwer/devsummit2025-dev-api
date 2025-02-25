using DevSummit2025.Model;

namespace DevSummit2025.Services.Contract
{
    public interface IServiceProduct
    {
        Task<List<ProductGetAllDto>> GetAll();
        Task<string> GetNew();
        Task Create();
    }
}
