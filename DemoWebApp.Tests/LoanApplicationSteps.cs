using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace DemoWebApp.Tests
{
    [Binding]
    public class LoanApplicationSteps
    {

        private IWebDriver _driver;
   
        private LoanApplicationPage _loanApplicationPage;
        private LoanConfirmationPage _loanConfirmationPage;

        private string _firstName;


        [Given(@"I navigate to Loan page")]
        public void GivenINavigateToLoanPage()
        {
            _driver = new ChromeDriver(@"C:\Users\dowen\AppData\Local\Google\Chrome\Application\");
            _driver.Manage().Window.Maximize();

            _loanApplicationPage = LoanApplicationPage.NavigateTo(_driver);
        }
        
        [Given(@"I fill in firstname (.*)")]
        public void GivenIFillInFirstnameDavid(string name)
        {
            _loanApplicationPage.FirstName = name;
            _firstName = name;
        }
        
        [Given(@"I fill in surname (.*)")]
        public void GivenIFillInSurnameOwen(string name)
        {
            _loanApplicationPage.Surname = name;
        }
        
        [Given(@"I select have loan")]
        public void GivenISelectHaveLoan()
        {
            _loanApplicationPage.SetLoan();
        }
        
        [Given(@"I accept terms conditions")]
        public void GivenIAcceptTermsConditions()
        {
           _loanApplicationPage.AcceptTerms();
        }
        
        [When(@"I submit form")]
        public void WhenISubmitForm()
        {
            _loanConfirmationPage =_loanApplicationPage.Submit();
        }
        
        [Then(@"I go to the loan completed page displaying my name")]
        public void ThenIGoToTheLoanCompletedPageDisplayingMyName()
        {
            Assert.That(_loanConfirmationPage.FirstName,Is.EqualTo(_firstName));
        }

        [Then(@"I get terms error message")]
        public void ThenIGetTermsErrorMessage()
        {
            IWebElement element = _driver.FindElement(By.CssSelector("div.validation-summary-errors"));
            var result = element.Text;
            Assert.That(result, Is.EqualTo("You must accept the terms and conditions"));
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Dispose();
        }

    }
}
