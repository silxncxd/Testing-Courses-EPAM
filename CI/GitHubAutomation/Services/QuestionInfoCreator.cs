using LdzTravelAutomation.Models;

namespace LdzTravelAutomation.Services
{
    public class QuestionInfoCreator
    {
        public static QuestionInfo SetInvalidInfo()
        {
            return new QuestionInfo(InvalidTestDataReader.GetData("QuestionName"), InvalidTestDataReader.GetData("QuestionTheme"),
                InvalidTestDataReader.GetData("QuestionEmail"), InvalidTestDataReader.GetData("Question"));
        }
        public static QuestionInfo SetNormalInfo()
        {
            return new QuestionInfo(NormalTestDataReader.GetData("QuestionName"), NormalTestDataReader.GetData("QuestionTheme"),
                 NormalTestDataReader.GetData("QuestionEmail"), NormalTestDataReader.GetData("Question"));
        }
    }
}
