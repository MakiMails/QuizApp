using QuizApp.Pages;

namespace QuizApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("RegistrationPage", typeof(RegistrationPage));
		Routing.RegisterRoute("ChangePasswordPage", typeof(ChangePasswordPage));
		Routing.RegisterRoute("CreateQuestionPage", typeof(CreateQuestionPage));
		Routing.RegisterRoute("EvaluationQuizPage", typeof(EvaluationQuizPage));
		Routing.RegisterRoute("PassingQuizPage", typeof(PassingQuizPage));
		Routing.RegisterRoute("QuizPage", typeof(QuizPage));
	}
}
