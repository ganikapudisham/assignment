using Assignment.Model;

namespace Assignment.Business
{
    public interface IServiceManager
    {
        Task<List<MasterData>> GetCategories();

        Task<List<Recipe>> GetRecipes(string categoryName);
    }
}
