using QuizApp.ViewModels;

namespace QuizApp.Pages;

public partial class QuizPage : ContentPage
{
	public QuizPage()
	{
		InitializeComponent();
        BindingContext = new QuizViewModel();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}