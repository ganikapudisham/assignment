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
    }
}
