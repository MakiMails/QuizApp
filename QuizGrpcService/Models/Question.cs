using QuizLibrary.Protos;

namespace QuizGrpcService.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; }

        public QuestionMessage ToQuestionMessage()
        {
            QuestionMessage questionReply = new QuestionMessage()
            {
                Id = Id,
                Text = Text,
            };

            questionReply.AnswerMessages.AddRange(Answers.Select(a => a.ToAnswerMessage()));

            return questionReply;
        }
    }
}