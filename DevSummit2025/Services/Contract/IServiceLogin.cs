namespace DevSummit2025.Services.Contract
{
    public interface IServiceLogin
    {
        Task<string> GetToken();
    }
}
