using QuizLibrary.Protos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    [QueryProperty("QuizMessageViewModel", nameof(QuizMessageViewModel))]
    public class PassingQuizViewModel : INotifyPropertyChanged
    {
        private QuizMessageViewModel _quizMessageViewModel;
        private int _indexQuestion;
        private int _questionCount;
        private int _numQuestion;
        private List<AnswerMessageViewModel> _answerMessageVeiwModels;
        private string _questionText = "";
        private int _correctCurrentAnswer;

        public string QuestionText
        {
            get => _questionText;

            set
            {
                if (_questionText != value)
                {
                    _questionText = value;
                    OnPropertyChanged();
                }
            }
        }

        public QuizMessageViewModel QuizMessageViewModel
        {
            get => _quizMessageViewModel;

            set
            {
                if (_quizMessageViewModel != value)
                {
                    _quizMessageViewModel = value;
                    QuestionCount = _quizMessageViewModel.QuizMessage.QuestionMessages.Count;
                    OnPropertyChanged();
                }
            }
        }

        public List<AnswerMessageViewModel> AnswerMessageViewModels
        {
            get => _answerMessageVeiwModels;
            set
            {
                if (_answerMessageVeiwModels != value)
                {
                    _answerMessageVeiwModels = value;
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

        public int NumQuestion
        {
            get => _numQuestion;

            set
            {
                if( _numQuestion != value)
                {
                    _numQuestion = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToAnswerCommand { get; set; }

        public PassingQuizViewModel()
        {
            ToAnswerCommand = new Command(async () => await OnAnswer());
        }

        public async Task NextAnswer()
        {
            if (_indexQuestion < _questionCount)
            {
                QuestionMessage questionMessage = _quizMessageViewModel.QuizMessage.QuestionMessages[_indexQuestion];
                QuestionText = questionMessage.Text;
                List<AnswerMessage> answerMessages = questionMessage.AnswerMessages.ToList();
                AnswerMessageViewModels = answerMessages.Select(a => new AnswerMessageViewModel(this, a)).ToList();
                NumQuestion = _indexQuestion + 1;
                _indexQuestion++;
            }
            else
            {
                await Shell.Current.GoToAsync("EvaluationQuizPage", new Dictionary<string, object>
                {
                    ["IdQuiz"] = _quizMessageViewModel.QuizMessage.Id,
                    ["CorrectCurrentAnswer"] = _correctCurrentAnswer,
                    ["QuestionCount"] = _questionCount
                });
            }
        }

        private async Task OnAnswer()
        {
            if (CheckCorrectnessResponses())
            {
                _correctCurrentAnswer++;
            }
            await NextAnswer();
        }

        private bool CheckCorrectnessResponses()
        {
            return _answerMessageVeiwModels.FindAll(a => a.IsRight == a.IsChecked).Count == _answerMessageVeiwModels.Count;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
