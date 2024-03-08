using CommunityToolkit.Mvvm.ComponentModel;
using Assignment.Business;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using Assignment.Model;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace Matri.ViewModel
{
    public partial class MealDetailsViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject, IQueryAttributable
    {
        IServiceManager _serviceManager;
        public MealDetailsViewModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [ObservableProperty]
        public bool isBusy;

        [ObservableProperty]
        public string meal;

        [ObservableProperty]
        public string mealThumb;

        [ObservableProperty]
        public string instructions;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var mealId = query["mealDetailsInput"] as string;
            Task.Run(() => this.GetMealDetails(mealId));
        }

        public async Task GetMealDetails(string mealId)
        {
            IsBusy = true;
            var mealDetails = await _serviceManager.GetMealDetails(mealId);

            var MealDetails = mealDetails.Where(md => md.idMeal == mealId).FirstOrDefault();

            Meal = MealDetails.strMeal;
            MealThumb = MealDetails.strMealThumb;
            Instructions = MealDetails.strInstructions;
            IsBusy = false;

        }
    }
}
