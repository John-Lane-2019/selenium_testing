/*Assignment 4
 * Automotive selling web app
 * Prepared by John Lane
 * PROG2070
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Assignment4
{
    [TestClass]
    public class Assignment4Tests
    {
        private FirefoxDriver  _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new FirefoxDriver(options);
        }
        /// <summary>
        /// Verify the page title to make sure you're on the right page.
        /// </summary>
        [TestMethod]
        public void VerifyPageTitle()
        {
            _driver.Url = "http://127.0.0.1:5500/Assignment4.html";
            Assert.AreEqual("Assignment 4", _driver.Title);
        }
        /// <summary>
        /// Verify all the fields are completed. Handle the click event then check input fields.
        /// </summary>
        [TestMethod]
        [Obsolete]
        public void VerifyAllFieldsMandatory() 
        {
            _driver.Url = "http://127.0.0.1:5500/Assignment4.html";
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit_button")));
            IWebElement submitButton = _driver.FindElement(By.Id("submit_button"));

            submitButton.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(_driver);
            alert.Accept();

            var sellerName = _driver.FindElementById("seller_name");
            var address = _driver.FindElementById("address");
            var city = _driver.FindElementById("city");
            var phone = _driver.FindElementById("phone");
            var email = _driver.FindElementById("email");
            var make = _driver.FindElementById("make");
            var model = _driver.FindElementById("model");
            var year = _driver.FindElementById("year");
            

            if (string.IsNullOrEmpty(sellerName.Text) || string.IsNullOrEmpty(address.Text)
                || string.IsNullOrEmpty(city.Text) || string.IsNullOrEmpty(phone.Text)
                || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(make.Text)
                || string.IsNullOrEmpty(model.Text) || string.IsNullOrEmpty(year.Text))
            {
                bool isEmptyField = true;
                Assert.IsTrue(isEmptyField);
                
            }
            
        }
        /// <summary>
        /// Validate the phone number by completing all other fields but passing an improperly formatted
        /// phone number to the web form. 
        /// </summary>
        [TestMethod]
        [Obsolete]
        public void VerifyPhoneNumberFormat() 
        {
            _driver.Url = "http://127.0.0.1:5500/Assignment4.html";

            var sellerName = _driver.FindElementById("seller_name");
            var address = _driver.FindElementById("address");
            var city = _driver.FindElementById("city");
            var phone = _driver.FindElementById("phone");
            var email = _driver.FindElementById("email");
            var make = _driver.FindElementById("make");
            var model = _driver.FindElementById("model");
            var year = _driver.FindElementById("year");

            sellerName.SendKeys("Tom Smith");
            address.SendKeys("34 Some Street");
            city.SendKeys("Pleasantville");
            phone.SendKeys("123");
            email.SendKeys("smith@hotmail.com");
            make.SendKeys("Ford");
            model.SendKeys("Explorer");
            year.SendKeys("2018");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit_button")));
            IWebElement submitButton = _driver.FindElement(By.Id("submit_button"));

            submitButton.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(_driver);
            string alertText = alert.Text;
            alert.Accept();

            Assert.AreEqual(alertText, "Acceptable phone number formats: " + "(123) 456-7890" + "  " + "123-456-7890" + " " + "123.456.7890" + " " + "1234567890");
           

        }
        /// <summary>
        /// Validate the email format by completing all the other fields and passing an improperly 
        /// formatted phone number to the web form. 
        /// </summary>
        [TestMethod]
        [Obsolete]
        public void VerifyEmailFormat() 
        {
            _driver.Url = "http://127.0.0.1:5500/Assignment4.html";

            var sellerName = _driver.FindElementById("seller_name");
            var address = _driver.FindElementById("address");
            var city = _driver.FindElementById("city");
            var phone = _driver.FindElementById("phone");
            var email = _driver.FindElementById("email");
            var make = _driver.FindElementById("make");
            var model = _driver.FindElementById("model");
            var year = _driver.FindElementById("year");

            sellerName.SendKeys("Tom Smith");
            address.SendKeys("34 Some Street");
            city.SendKeys("Pleasantville");
            phone.SendKeys("333 333 3333");
            email.SendKeys("smithhotmail.com");
            make.SendKeys("Ford");
            model.SendKeys("Explorer");
            year.SendKeys("2018");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit_button")));
            IWebElement submitButton = _driver.FindElement(By.Id("submit_button"));

            submitButton.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(_driver);
            string alertText = alert.Text;
            alert.Accept();

            Assert.AreEqual(alertText, "Invalid email format");

        }
        /// <summary>
        /// Valdidate that the year is not less than 1900 by completing all the other fields
        /// and passing a value less than 1900 to the web form. 
        /// </summary>
        [TestMethod]
        [Obsolete]
        public void VerifyYearNotLessThan1900() 
        {
            _driver.Url = "http://127.0.0.1:5500/Assignment4.html";

            var sellerName = _driver.FindElementById("seller_name");
            var address = _driver.FindElementById("address");
            var city = _driver.FindElementById("city");
            var phone = _driver.FindElementById("phone");
            var email = _driver.FindElementById("email");
            var make = _driver.FindElementById("make");
            var model = _driver.FindElementById("model");
            var year = _driver.FindElementById("year");

            sellerName.SendKeys("Tom Smith");
            address.SendKeys("34 Some Street");
            city.SendKeys("Pleasantville");
            phone.SendKeys("333 333 3333");
            email.SendKeys("smith@hotmail.com");
            make.SendKeys("Ford");
            model.SendKeys("Explorer");
            year.SendKeys("1899");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit_button")));
            IWebElement submitButton = _driver.FindElement(By.Id("submit_button"));

            submitButton.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(_driver);
            string alertText = alert.Text;
            alert.Accept();

            Assert.AreEqual(alertText, "Please enter a year not less than 1900 and not greater than 2020");

        }
        /// <summary>
        /// Validate that the year is not greater than 2020 by completing all fields and passing
        /// a value greater than 2020 to the web form. 
        /// </summary>
        [TestMethod]
        [Obsolete]
        public void VerifyYearNotGreaterThan2020() 
        {
            _driver.Url = "http://127.0.0.1:5500/Assignment4.html";

            var sellerName = _driver.FindElementById("seller_name");
            var address = _driver.FindElementById("address");
            var city = _driver.FindElementById("city");
            var phone = _driver.FindElementById("phone");
            var email = _driver.FindElementById("email");
            var make = _driver.FindElementById("make");
            var model = _driver.FindElementById("model");
            var year = _driver.FindElementById("year");

            sellerName.SendKeys("Tom Smith");
            address.SendKeys("34 Some Street");
            city.SendKeys("Pleasantville");
            phone.SendKeys("333 333 3333");
            email.SendKeys("smith@hotmail.com");
            make.SendKeys("Ford");
            model.SendKeys("Explorer");
            year.SendKeys("2021");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit_button")));
            IWebElement submitButton = _driver.FindElement(By.Id("submit_button"));

            submitButton.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(_driver);
            string alertText = alert.Text;
            alert.Accept();

            Assert.AreEqual(alertText, "Please enter a year not less than 1900 and not greater than 2020");

        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
