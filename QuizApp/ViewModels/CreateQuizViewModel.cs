using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    public class CreateQuizViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _topic;
        private ObservableCollection<QuestionMessageViewModel> _questions = new();

        public string Name
        {
            get => _name;

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Topic
        {
            get => _topic;

            set
            {
                if (_topic != value)
                {
                    _topic = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<QuestionMessageViewModel> Questions
        {
            get => _questions; 
            
            set
            {
                if (_questions != value)
                {
                    _questions = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public CreateQuizViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            Questions.Add(new QuestionMessageViewModel(Questions.Count + 1));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
