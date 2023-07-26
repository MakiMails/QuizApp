using QuizLibrary.Protos;

namespace QuizGrpcService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;

        public UserMessage ToUserMessage()
        {
            return new UserMessage { Id = Id, Login = Login };
        }
    }
}