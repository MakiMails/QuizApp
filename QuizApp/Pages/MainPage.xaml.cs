namespace QuizApp.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        test.Clicked += Test_Clicked;
    }

    private async void Test_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("CreateQuestionPage");
    }
}

