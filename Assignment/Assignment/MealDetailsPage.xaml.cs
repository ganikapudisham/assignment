using Matri.ViewModel;

namespace Assignment;

public partial class MealDetailsPage : ContentPage
{
	public MealDetailsPage(MealDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}