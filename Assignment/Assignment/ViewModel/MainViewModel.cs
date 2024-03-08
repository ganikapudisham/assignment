using CommunityToolkit.Mvvm.ComponentModel;
using Assignment.Business;

namespace Matri.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IServiceManager _serviceManager;
        public MainViewModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            Task.Run(() => this.GetCategories());
        }

        public bool GetCategories()
        {
            try
            {

                var dbProfilesWithPaging = _serviceManager.GetCategories();

            }
            catch (Exception ex)
            {
            }
            return true;
        }
    }
}
