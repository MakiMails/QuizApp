﻿using QuizLibrary.Protos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    public class QuizMessageViewModel : INotifyPropertyChanged
    {
        private QuizMessage _quiz;

        public string Name
        {
            get => _quiz.Name;
        }

        public string Topic
        {
            get => _quiz.Topic;
        }

        public float Estimation
        {
            get => _quiz.Estimation;
        }

        public string AuthorLogin
        {
            get => _quiz.Author.Login;
        }

        private int _count = 0;

        public int Count
        {
            get => _count;

            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand Test { get; set; }
        public ICommand GoToPageDetails { get; set; }

        public QuizMessageViewModel(QuizMessage quizReply)
        {
            _quiz = quizReply;
            Test = new Command(() => { Count++; });
            GoToPageDetails = new Command(async () => await OnClick());
        }

        private async Task OnClick()
        {
            await Shell.Current.GoToAsync("QuizPage", new Dictionary<string, object>
            {
                ["QuizMessageViewModel"] = this
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
