using QuizLibrary.Protos;

namespace QuizGrpcService.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsRight { get; set; }

        public AnswerMessage ToAnswerMessage()
        {
            return new AnswerMessage()
            {
                Id = Id,
                Text = Text,
                IsRight = IsRight
            };
        }
    }
}