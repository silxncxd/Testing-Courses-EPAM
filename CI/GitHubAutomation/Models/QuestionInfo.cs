
namespace LdzTravelAutomation.Models
{
    public class QuestionInfo
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Email { get; set; }
        public string YourQuestion { get; set; }

        public QuestionInfo(string name, string theme, string email, string yourQuestion)
        {
            Name = name;
            Theme = theme;
            Email = email;
            YourQuestion = yourQuestion;
        }
    }
}
