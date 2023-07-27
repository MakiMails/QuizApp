using QuizApp.ViewModels;

namespace QuizApp.Pages;

public partial class EvaluationQuizPage : ContentPage
{
	public EvaluationQuizPage()
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsEnabled = false, IsVisible = false });
        BindingContext = new EvaluationQuizViewModel();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}