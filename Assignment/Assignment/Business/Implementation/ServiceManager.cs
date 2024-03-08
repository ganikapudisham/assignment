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
            var lst = await _serviceRepository.GetAsync<List<Category>>("api/json/v1/1/categories.php");
            return new List<MasterData>();
        }
    }
}
