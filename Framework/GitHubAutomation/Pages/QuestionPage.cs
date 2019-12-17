using LdzTravelAutomation.Models;
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
        }

        public QuestionPage InputQuestion(QuestionInfo question)
        {
            Name.SendKeys(question.Name);
            Theme.SendKeys(question.Theme);
            Email.SendKeys(question.Email);
            Message.SendKeys(question.YourQuestion);
            AgreeButton.Click();
            return this;
        }

        public QuestionPage ClickSendQuestionButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("recaptcha-checkbox-checkmark")));
            SendButton.Click();
            return this;
        }
    }

}
