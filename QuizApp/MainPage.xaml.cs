using Grpc.Net.Client;
using QuizLibrary.Protos.Greet;
using static QuizLibrary.Protos.Greet.Greeter;

namespace QuizApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		InitEvent();

    }

	public void InitEvent()
	{
        sendBnt.Clicked += SendBnt_Clicked;
	}

    private void SendBnt_Clicked(object sender, EventArgs e)
    {
		GrpcChannel channel = GrpcChannel.ForAddress("http://10.0.2.2:5245");
		GreeterClient greeterClient = new GreeterClient(channel);

		string name = nameUserEntry.Text;

		HelloReply helloReply = greeterClient.SayHello( new HelloRequest() { Name = name});
		messLabel.Text = $"Собщение: {helloReply.Message}";

	}
}

