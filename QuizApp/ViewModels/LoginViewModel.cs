using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using QuizApp.Pages;

namespace QuizApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _login = "";
        private string _password = "";
        private bool _isBlokcSendButton = false;
        private ObservableCollection<string> _messangeErrors = new();

        public string Login
        {
            get => _login;
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsBlokcSendButton
        {
            get => _isBlokcSendButton;

            set
            {
                if (_isBlokcSendButton != value)
                {
                    _isBlokcSendButton = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> MessangeErrors
        {
            get => _messangeErrors;

            set
            {
                if (_messangeErrors != value)
                {
                    _messangeErrors = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AuthorizeCommand { get; set; }
        public ICommand GoToRegistrationPageCommand { get; set; }

        public LoginViewModel()
        {
            AuthorizeCommand = new Command(async () =>
            {
                IsBlokcSendButton = true;

                if (CheckCorrectnessOfData())
                {
                    if(await Authorize())
                    {
                        await Shell.Current.GoToAsync("///MainPage");
                    }
                }

                IsBlokcSendButton = false;
            });

            GoToRegistrationPageCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("RegistrationPage");
            });

        }

        private bool CheckCorrectnessOfData()
        {
            MessangeErrors.Clear();

            if (_login.Length < 3 || _login.Length > 16)
            {
                MessangeErrors.Add("Минимальная длина логина 3 символа, а максимальная 16");
            }

            if (_password.Length < 8 || _password.Length > 16)
            {
                MessangeErrors.Add("Минимальная длина пароля 8 символа, а максимальная 16");
            }

            if (MessangeErrors.Count > 0)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> Authorize()
        {
            //Shell.Current.GoToAsync("");
            //GrpcChannel grpcChannel = GrpcChannel.ForAddress("adrress");
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
