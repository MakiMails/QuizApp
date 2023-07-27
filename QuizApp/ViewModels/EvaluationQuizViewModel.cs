using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    [QueryProperty(nameof(IdQuiz), "IdQuiz")]
    [QueryProperty(nameof(CorrectCurrentAnswer), "CorrectCurrentAnswer")]
    [QueryProperty(nameof(QuestionCount), "QuestionCount")]
    public class EvaluationQuizViewModel : INotifyPropertyChanged
    {
        private int _idQuiz;
        private int _correctCurrentAnswer;
        private int _questionCount;

        public int IdQuiz
        {
            get => _idQuiz;

            set
            {
                if (_idQuiz != value)
                {
                    _idQuiz = value;
                    OnPropertyChanged();
                }
            }

        }

        public int CorrectCurrentAnswer
        {
            get => _correctCurrentAnswer;

            set
            {
                if (_correctCurrentAnswer != value)
                {
                    _correctCurrentAnswer = value;
                    OnPropertyChanged();
                }
            }
        }

        public int QuestionCount
        {
            get => _questionCount;

            set
            {
                if (_questionCount != value)
                {
                    _questionCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SendEcaluationCommand { get; set; }
        public ICommand BackMainPageCommand { get; set; }

        public EvaluationQuizViewModel()
        {
            SendEcaluationCommand = new Command(async () => await OnSendEcaluation());
            BackMainPageCommand = new Command(async () => await OnToGoMainPage());
        }

        
        private async Task OnSendEcaluation()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }

        private async Task OnToGoMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
