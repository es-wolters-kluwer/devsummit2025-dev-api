namespace DevSummit2025.Services.Contract
{
    public interface IServiceWebHook
    {
        Task<string> GetAllActive();
        Task<string> GetAllLogs(string idcda);
        Task<bool> Subscribe();
    }
}
