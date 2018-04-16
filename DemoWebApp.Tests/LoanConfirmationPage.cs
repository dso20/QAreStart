using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoWebApp.Tests
{
    class LoanConfirmationPage
    {
        private readonly IWebDriver _driver;

        public LoanConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string FirstName
        {
            get { return _driver.FindElement(By.Id("firstName")).Text; }
        }
    }
}
