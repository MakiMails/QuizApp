using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuizApp.ViewModels
{
    public class QuestionMessageViewModel : INotifyPropertyChanged
    {
        private int _num;
        private string _text;
        private ObservableCollection<AnswerMessageViewModel> _answers;

        public int Num
        {
            get => _num;
            
            set
            {
                if (_num != value)
                {
                    _num = value;
                    OnPropertyChanged();
                }    
            }
        }

        public string Text
        {
            get => _text;

            set
            {
                if(_text != value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<AnswerMessageViewModel> Answers
        {
            get => _answers;

            set
            {
                if(_answers != value)
                {
                    _answers = value;
                    OnPropertyChanged();
                }
            }
        }

        public QuestionMessageViewModel(int num)
        {
            Num = num;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}