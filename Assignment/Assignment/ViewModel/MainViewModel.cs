using CommunityToolkit.Mvvm.ComponentModel;
using Assignment.Business;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using Assignment.Model;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace Matri.ViewModel
{
    public partial class MainViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        IServiceManager _serviceManager;
        public MainViewModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            Categories = new ObservableRangeCollection<MasterData>();
            Task.Run(() => this.GetCategories());
        }

        private ObservableRangeCollection<MasterData> categories;
        public ObservableRangeCollection<MasterData> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
            }
        }

        [ObservableProperty]
        public MasterData selectedCategory;

        public async Task GetCategories()
        {
            try
            {
                var dbCategories = await _serviceManager.GetCategories();
                Categories.AddRange(dbCategories);
            }
            catch (Exception ex)
            {
            }
        }

        [RelayCommand]
        private async Task SelectedCategoryPicked(Object obj)
        {
            if (obj != null && obj is MainViewModel)
            {
                var item = (MainViewModel)obj;

                int index = Categories.ToList().FindIndex(a => a.Id == item.SelectedCategory.Id);
                var selCat = Categories[index];
                var catname = "Seafood";
                var recipes = await _serviceManager.GetMeals(catname);
            }
        }
    }
}
