using Assignment.Model;

namespace Assignment.Business
{
    public interface IServiceManager
    {
        Task<List<MasterData>> GetCategories();
    }
}
