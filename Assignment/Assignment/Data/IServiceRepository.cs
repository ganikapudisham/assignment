namespace Assignment.Data
{
    public interface IServiceRepository
    {
        Task<TResult> GetAsync<TResult>(string url);
    }
}
