using Assignment.Data;
using Assignment.Model;

namespace Assignment.Business.Impl
{
    public class ServiceManager : IServiceManager
    {
        IServiceRepository _serviceRepository;
        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<MasterData>> GetCategories()
        {
            var categories = await _serviceRepository.GetAsync<Categories>("api/json/v1/1/categories.php");

            var masterDataList = new List<MasterData>();
            foreach(var cat in categories.categories)
            {
                var md = new MasterData();
                md.Id = cat.idCategory;
                md.Name = cat.strCategory;
                masterDataList.Add(md);
            }
            return masterDataList;
        }

        public async Task<List<Meal>> GetMeals(string categoryName)
        {
            var meals = await _serviceRepository.GetAsync<Meals>(string.Format("api/json/v1/1/filter.php?c={0}", categoryName));
            return meals.meals;
        }

        public async Task<List<Meal>> GetMealDetails(string mealId)
        {
            var meals = await _serviceRepository.GetAsync<Meals>(string.Format("api/json/v1/1/lookup.php?i={0}", mealId));
            return meals.meals;
        }
    }
}
