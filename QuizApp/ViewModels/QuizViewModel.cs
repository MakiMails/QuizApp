using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuizApp.ViewModels
{
    [QueryProperty("QuizMessageViewModel",nameof(QuizMessageViewModel))]
    public class QuizViewModel : INotifyPropertyChanged
    {
        private QuizMessageViewModel _replyViewModel;

        public QuizMessageViewModel QuizMessageViewModel
        {
            get => _replyViewModel;

            set
            {
                if (_replyViewModel != value)
                {
                    _replyViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
