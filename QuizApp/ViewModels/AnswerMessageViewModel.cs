using QuizLibrary.Protos;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuizApp.ViewModels
{
    public class AnswerMessageViewModel : INotifyPropertyChanged
    {
        private PassingQuizViewModel _passingQuizViewModel;
        private AnswerMessage _answer;
        private bool _isChecked = false;

        public string Text
        {
            get => _answer.Text;
        }

        public bool IsRight
        {
            get => _answer.IsRight;
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if(_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }
        }

        public AnswerMessageViewModel(PassingQuizViewModel passingQuizViewModel,
            AnswerMessage answer)
        {
            _passingQuizViewModel = passingQuizViewModel;
            _answer = answer;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}