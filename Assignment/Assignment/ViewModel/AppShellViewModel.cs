using CommunityToolkit.Mvvm.ComponentModel;
using Assignment.Business;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using Assignment.Model;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using Assignment;

namespace Matri.ViewModel
{
    public partial class AppShellViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        IServiceManager _serviceManager;
        public AppShellViewModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            Routing.RegisterRoute("mealDetails", typeof(MealDetailsPage));
        }
    }
}
