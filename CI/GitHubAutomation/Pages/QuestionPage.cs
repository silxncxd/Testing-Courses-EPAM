using LdzTravelAutomation.Models;
using LdzTravelAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace LdzTravelAutomation.Pages
{
    public class QuestionPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement Name;

        [FindsBy(How = How.Id, Using = "subject")]
        private IWebElement Theme;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement Message;

        [FindsBy(How = How.ClassName, Using = "recaptcha-checkbox-border")]
        private IWebElement AgreeButton;

        [FindsBy(How = How.ClassName, Using = "button.with-large-spacer")]
        private IWebElement SendButton;

        [FindsBy(How = How.Id, Using = "msg_placeholder")]
        public IWebElement MessageTooltip;

        public QuestionPage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(webDriver, this);
            Logger.Log.Info("Question page initialized");
        }

        public QuestionPage InputQuestion(QuestionInfo question)
        {
            Name.SendKeys(question.Name);
            Theme.SendKeys(question.Theme);
            Email.SendKeys(question.Email);
            Message.SendKeys(question.YourQuestion);
            AgreeButton.Click();
            Logger.Log.Info("Question input: " + question.Name + "/" + question.Theme + "/" + question.Email + "/" + question.YourQuestion);
            return this;
        }

        public QuestionPage ClickSendQuestionButton()
        {
            SendButton.Click();
            Logger.Log.Info("Send question button clicked");
            return this;
        }
    }

}
