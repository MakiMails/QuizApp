using QuizApp.ViewModels;

namespace QuizApp.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
    }
}

