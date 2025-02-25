using DevSummit2025.Model;

namespace DevSummit2025.Services.Contract
{
    public interface IServiceSaleInvoice
    {
        Task<string> GetAll();
        Task<SaleInvoiceDtoRs> GetNew();
        Task<InvoiceLineDto> GetNewLine();
        Task Create();
    }
}
