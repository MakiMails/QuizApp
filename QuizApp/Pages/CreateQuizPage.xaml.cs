using QuizApp.ViewModels;

namespace QuizApp.Pages;

public partial class CreateQuizPage : ContentPage
{
	public CreateQuizPage()
	{
		InitializeComponent();
		BindingContext = new CreateQuizViewModel();
	}
}