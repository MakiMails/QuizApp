using QuizLibrary.Protos;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using QuizApp.Enums;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _textForSearch = "";
        private ObservableCollection<QuizMessageViewModel> _quizMessageViewModels = new();
        private CatalogType _catalogType = CatalogType.Internet;

        public string TextForSearch
        {
            get => _textForSearch;

            set
            {
                if(_textForSearch != value)
                {
                    _textForSearch = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<QuizMessageViewModel> QuizMessages
        {
            get => _quizMessageViewModels;

            set
            {
                if(_quizMessageViewModels != value)
                {
                    _quizMessageViewModels = value;
                    OnPropertyChanged();
                }
            }
        }

        public CatalogType CatalogType
        {
            get => _catalogType;

            set
            {
                if (_catalogType != value)
                {
                    _catalogType = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SwitchCatalogCommang { get; set; }

        public MainViewModel()
        {
            FillMochtData();
            InitCommands();
        }

        private void InitCommands()
        {
            SwitchCatalogCommang = new Command<string>(async (string catalogTypeStr) =>
            {
                await OnSwitchCatalog(catalogTypeStr);
            });
        }

        private void FillMochtData()
        {
            QuizMessages.Clear();
            QuizMessage quizReply = new QuizMessage()
            {
                Name = "Тест",
                Topic = "Тема тест",
                Estimation = 5f,
                Author = new UserMessage()
                {
                    Login = "TestLogin"
                }
            };

            QuestionMessage questionReply = new QuestionMessage()
            {
                Text = "Вопрос 1"
            };

            List<AnswerMessage> answerReplies = new List<AnswerMessage>()
            {
                new AnswerMessage()
                {
                    Text = "Ответ 1(Правильный)",
                    IsRight = true,
                },
                new AnswerMessage()
                {
                    Text = "Ответ 2",
                    IsRight = false,
                },
                new AnswerMessage()
                {
                    Text = "Ответ 3",
                    IsRight = false,
                },
            };

            quizReply.QuestionMessages.Add(questionReply);
            QuizMessages.Add(new QuizMessageViewModel(quizReply));
        }

        private void FillMochtDataForUser()
        {
            QuizMessages.Clear();
            QuizMessage quizReply = new QuizMessage()
            {
                Name = "Мой Тест",
                Topic = "Тема тест",
                Estimation = 5f,
                Author = new UserMessage()
                {
                    Login = "TestLogin"
                }
            };

            QuestionMessage questionReply = new QuestionMessage()
            {
                Text = "Вопрос 1"
            };

            List<AnswerMessage> answerReplies = new List<AnswerMessage>()
            {
                new AnswerMessage()
                {
                    Text = "Ответ 1(Правильный)",
                    IsRight = true,
                },
                new AnswerMessage()
                {
                    Text = "Ответ 2",
                    IsRight = false,
                },
                new AnswerMessage()
                {
                    Text = "Ответ 3",
                    IsRight = false,
                },
            };

            quizReply.QuestionMessages.Add(questionReply);
            QuizMessages.Add(new QuizMessageViewModel(quizReply));
        }

        private async Task OnSwitchCatalog(string catalogTypeStr)
        {
            if (Enum.IsDefined(typeof(CatalogType), catalogTypeStr))
            {
                CatalogType = Enum.Parse<CatalogType>(catalogTypeStr);

                if (CatalogType == CatalogType.Internet)
                {
                    FillMochtData();
                }
                else
                {
                    FillMochtDataForUser();
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
