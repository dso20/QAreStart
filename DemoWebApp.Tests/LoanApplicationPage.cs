using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;


namespace DemoWebApp.Tests
{
    class LoanApplicationPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"http://localhost:40077/Home/StartLoanApplication";


        public LoanApplicationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public static LoanApplicationPage NavigateTo(IWebDriver driver)
        {

            driver.Navigate().GoToUrl(PageUri);

            return new LoanApplicationPage(driver);
        }

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement _firstName;
        public string FirstName
        {
            set => _firstName.SendKeys(value);
        }

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement _lastName;
        public string Surname
        {
            set => _lastName.SendKeys(value);

        }


        public void SetLoan()
        {
            _driver.FindElement(By.Id("Loan")).Click();
        }

        public void AcceptTerms()
        {
            _driver.FindElement(By.Name("TermsAcceptance")).Click();

        }

        public LoanConfirmationPage Submit()
        {
            _driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            return new LoanConfirmationPage(_driver);
        }

    }
}
