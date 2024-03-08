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
        public string strMeal;

        [ObservableProperty]
        public string strMealThumb;

        [ObservableProperty]
        public string strInstructions;

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

            StrMeal = MealDetails.strMeal;
            StrMealThumb = MealDetails.strMealThumb;
            StrInstructions = MealDetails.strInstructions;
            IsBusy = false;

        }
    }
}
