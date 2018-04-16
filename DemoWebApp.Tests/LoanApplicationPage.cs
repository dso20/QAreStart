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
        private IWebDriver _driver;
        private const string PageUri = @"http://localhost:40077/Home/StartLoanApplication";


        public LoanApplicationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static LoanApplicationPage NavigateTo(IWebDriver driver)
        {

            driver.Navigate().GoToUrl(PageUri);

            return new LoanApplicationPage(driver);
        }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public string FirstName
        {
            get
            {
                return _driver.FindElement(By.Id("FirstName")).Text;
            }
            set 
            {
                _driver.FindElement(By.Id("FirstName")).SendKeys(value);
            }
        }

        public string Surname
        {
            get
            {
                return _driver.FindElement(By.Id("LastName")).Text;
            }
            set
            {
                _driver.FindElement(By.Id("LastName")).SendKeys(value);
            }
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
