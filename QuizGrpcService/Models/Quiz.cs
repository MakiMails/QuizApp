using QuizLibrary.Protos;

namespace QuizGrpcService.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public float Estimation { get; set; }
        public List<Question> Questions { get; set;}
        public User User { get; set; }

        public QuizMessage ToQuizMessage()
        {
            QuizMessage quizReply = new QuizMessage()
            {
                Id = Id,
                Name = Name,
                Topic = Topic,
                Estimation = Estimation,
                Author = User.ToUserMessage(),
            };

            quizReply.QuestionMessages.AddRange(Questions.Select(q => q.ToQuestionMessage()));

            return quizReply;
        }
    }
}
