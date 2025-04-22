using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaNCS.Pages
{
    public class PizzaNCSHomePage : BaseTests
    {
        private IWebDriver _driver;

        public PizzaNCSHomePage(IWebDriver driver)
        {
            _driver = driver;
        }


        private IWebElement _loginSignUpLink => _driver.FindElement(By.XPath("(//span[@class='v-btn__content'])[5]"));
        private IWebElement _signUpLink => _driver.FindElement(By.XPath("(//div[@class='v-card__text pt-4']/p/a)[1]"));

        private IWebElement _signUpBtn => _driver.FindElement(By.XPath("(//span[@class='v-btn__content'])[16]"));

        /*Error messages on the username/password empty*/
        private IWebElement _usernameError => _driver.FindElement(By.Id("username-err"));
        private IWebElement _passwordError => _driver.FindElement(By.Id("password-err"));
        private IWebElement _confrmPasswordErr => _driver.FindElement(By.Id("confirm-err"));

        /*UserName / Password / Confirm Password fields*/
        private IWebElement _usernameField => _driver.FindElement(By.Id("input-91"));
        private IWebElement _passwordField => _driver.FindElement(By.Id("input-94"));
        private IWebElement _confrmPasswordField => _driver.FindElement(By.Id("input-97"));

        private IWebElement _loginSuccessMessage => _driver.FindElement(By.CssSelector(".snackbar.popup-message"));


        public void OpenSignUpWindow()
        {
            _loginSignUpLink.Click();
            Thread.Sleep(2000);
            _signUpLink.Click();
        }

        public void ClickOnSignUpBtn()
        {
            _signUpBtn.Click();
        }

        public bool VerifyUserNameErrMsg() => _usernameError.Displayed;
        public string GetUserNameErrorMessage() => _usernameError.Text;

        
        public bool VerifyPasswordErrMsg() => _passwordError.Displayed;
        public string GetPasswordErrorMessage() => _passwordError.Text;

        public bool VerifyConfirmPasswordErrMsg() => _confrmPasswordErr.Displayed;
        public string GetConfirmPasswordErrorMessage() => _confrmPasswordErr.Text;


        /*Enter the Credentials*/
        public void EnterCredentials(string userName, string password, string confrmPassword)
        {
            _usernameField.SendKeys(userName);
            _passwordField.SendKeys(password);
            _confrmPasswordField.SendKeys(confrmPassword);
            ClickOnSignUpBtn();
        }


        /*Verify the Success Message*/
        public string VerifySuccessfulLogin()
        {
            return _loginSuccessMessage.Text;
        }



    }
}
