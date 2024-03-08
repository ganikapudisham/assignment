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
            Meals = new ObservableRangeCollection<Meal>();
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

        private ObservableRangeCollection<Meal> meals;
        public ObservableRangeCollection<Meal> Meals
        {
            get { return meals; }
            set
            {
                meals = value;
            }
        }

        [ObservableProperty]
        public MasterData selectedCategory;

        [ObservableProperty]
        public Meal selectedMeal;

        [ObservableProperty]
        public bool isBusy;

        public async Task GetCategories()
        {
            IsBusy = true;
            try
            {
                var dbCategories = await _serviceManager.GetCategories();
                Categories.AddRange(dbCategories);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task SelectedCategoryPicked(Object obj)
        {
            IsBusy = true;
            if (obj != null && obj is MainViewModel)
            {
                var item = (MainViewModel)obj;

                int index = Categories.ToList().FindIndex(a => a.Id == item.SelectedCategory.Id);
                var selCat = Categories[index];
                //var meals = await _serviceManager.GetMeals("Seafood");
                var recipes = await _serviceManager.GetMeals(selCat.Name);

                Meals.AddRange(meals);
            }
            IsBusy = false;
        }

        [RelayCommand]
        public async Task ViewMeal(Object obj)
        {
            IsBusy = true;
            if (obj != null && obj is Meal)
            {
                var item = (Meal)obj;

                var mealDetailsParams = new Dictionary<string, object> { { "mealDetailsInput", item.idMeal} };

                await Shell.Current.GoToAsync("mealDetails", mealDetailsParams);
            }
            IsBusy = false;
        }
    }
}
