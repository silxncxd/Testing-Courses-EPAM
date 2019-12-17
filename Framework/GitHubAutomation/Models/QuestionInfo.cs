
namespace LdzTravelAutomation.Models
{
    public class QuestionInfo
    {
        public string Name { get; }
        public string Theme { get; }
        public string Email { get; }
        public string YourQuestion { get; }

        public QuestionInfo(string name, string theme, string email, string yourQuestion)
        {
            Name = name;
            Theme = theme;
            Email = email;
            YourQuestion = yourQuestion;
        }
    }
}
