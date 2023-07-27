using QuizLibrary.Protos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    [QueryProperty("QuizMessageViewModel", nameof(QuizMessageViewModel))]
    public class QuizViewModel : INotifyPropertyChanged
    {
        private QuizMessageViewModel _quizMessageViewModel;
        private List<AnswerMessageViewModel> _answerMessageVeiwModels;

        public QuizMessageViewModel QuizMessageViewModel
        {
            get => _quizMessageViewModel;

            set
            {
                if (_quizMessageViewModel != value)
                {
                    _quizMessageViewModel = value;
                    OnPropertyChanged();
                }
            }
        }


        public List<AnswerMessageViewModel> AnswerMessageViewModels
        {
            get => _answerMessageVeiwModels;
            set
            {
                if(_answerMessageVeiwModels != value)
                {
                    _answerMessageVeiwModels = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand StartQuizCommand { get; set; }

        public QuizViewModel()
        {
            StartQuizCommand = new Command(async () => await OnStartQuiz());
        }

        private async Task OnStartQuiz()
        {
            await Shell.Current.GoToAsync("PassingQuizPage", new Dictionary<string, object>()
            {
                ["QuizMessageViewModel"] = _quizMessageViewModel
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
