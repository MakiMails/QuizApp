using QuizApp.ViewModels;

namespace QuizApp.Pages;

public partial class PassingQuizPage : ContentPage
{
	public PassingQuizPage()
	{
		InitializeComponent();
		BindingContext = new PassingQuizViewModel();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        PassingQuizViewModel view = BindingContext as PassingQuizViewModel;
        await view.NextAnswer();
    }
}