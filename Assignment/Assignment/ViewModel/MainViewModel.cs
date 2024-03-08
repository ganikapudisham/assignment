using CommunityToolkit.Mvvm.ComponentModel;
using Assignment.Business;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using Assignment.Model;

namespace Matri.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IServiceManager _serviceManager;
        public MainViewModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            Categories = new ObservableCollection<MasterData>();
            Task.Run(() => this.GetCategories());
        }

        private ObservableCollection<MasterData> categories;
        public ObservableCollection<MasterData> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
            }
        }

        public async Task GetCategories()
        {
            try
            {
                var dbCategories = await _serviceManager.GetCategories();
                
                foreach(var ca in dbCategories)
                {
                    Categories.Add(ca);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
