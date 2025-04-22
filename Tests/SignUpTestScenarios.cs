using NUnit.Framework;
using OpenQA.Selenium;
using PizzaNCS.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaNCS.Tests
{
    public class SignUpTestScenarios : BaseTests
    {

        private PizzaNCSHomePage homePage;
        private string validPassword = "letmein2019";

        [SetUp]
        public void SetUp()
        {
            //base.OneTimeSetUp();
            homePage = new PizzaNCSHomePage(driver);
        }


        [Test]
        public void PizzaNCSAppBlankLoginTest()
        {
            LaunchPizzaNCSSite();
            homePage.OpenSignUpWindow();
            homePage.ClickOnSignUpBtn();
            Assert.IsTrue(homePage.VerifyUserNameErrMsg());
            Assert.AreEqual("Username is required", homePage.GetUserNameErrorMessage());
            Console.WriteLine(homePage.GetUserNameErrorMessage());

            Assert.IsTrue(homePage.VerifyPasswordErrMsg());
            Assert.AreEqual("Password is required", homePage.GetPasswordErrorMessage());
            Console.WriteLine(homePage.GetPasswordErrorMessage());

            Assert.IsTrue(homePage.VerifyConfirmPasswordErrMsg());
            Assert.AreEqual("Please confirm your password", homePage.GetConfirmPasswordErrorMessage());
            Console.WriteLine(homePage.GetConfirmPasswordErrorMessage());
        }

        [Test]
        public void PizzaNCSAppCredentialsLengthTest()
        {
            LaunchPizzaNCSSite();
            homePage.OpenSignUpWindow();
            homePage.ClickOnSignUpBtn();
            homePage.EnterCredentials("abc","abc","def");
            Assert.IsTrue(homePage.VerifyUserNameErrMsg());
            Assert.AreEqual("Username must be minimum of 6 characters", homePage.GetUserNameErrorMessage());
            Console.WriteLine(homePage.GetUserNameErrorMessage());

            Assert.IsTrue(homePage.VerifyPasswordErrMsg());
            Assert.AreEqual("Password must be minimum of 8 characters", homePage.GetPasswordErrorMessage());
            Console.WriteLine(homePage.GetPasswordErrorMessage());

            Assert.IsTrue(homePage.VerifyConfirmPasswordErrMsg());
            Assert.AreEqual("Your passwords do not match", homePage.GetConfirmPasswordErrorMessage());
            Console.WriteLine(homePage.GetConfirmPasswordErrorMessage());
        }


        [Test]
        public void PizzaNCSAppUserAlreadyExistTest()
        {
            LaunchPizzaNCSSite();
            homePage.OpenSignUpWindow();
            homePage.ClickOnSignUpBtn();
            homePage.EnterCredentials("donald", validPassword, validPassword);
            Assert.IsTrue(homePage.VerifyUserNameErrMsg());
            Assert.AreEqual("Username already exists", homePage.GetUserNameErrorMessage());
            Console.WriteLine(homePage.GetUserNameErrorMessage());

        }

        [Test]
        public void PizzaNCSAppUserValidUserTest()
        {
            string user = "robinhood";
            LaunchPizzaNCSSite();
            homePage.OpenSignUpWindow();
            homePage.ClickOnSignUpBtn();
            homePage.EnterCredentials(user, validPassword, validPassword);
            Assert.AreEqual("Thanks " + user + ", you can now login.", homePage.VerifySuccessfulLogin());
            Console.WriteLine("Thanks " + user + ", you can now login.");
        }
    }
}
