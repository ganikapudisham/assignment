using CommunityToolkit.Mvvm.ComponentModel;
using Assignment.Business;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using Assignment.Model;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace Matri.ViewModel
{
    public partial class MealDetailsViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        IServiceManager _serviceManager;
        public MealDetailsViewModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

    }
}
