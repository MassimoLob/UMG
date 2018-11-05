using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace TechTestUMG
{

    public class BookingPage
    {
        IWebDriver driver = new ChromeDriver();
        IWebElement SignUpLink => driver.FindElement(By.XPath("//*[contains(text(),'Sign up')]"));
        IWebElement SignUpPageAssert => driver.FindElement(By.XPath("//*[contains(text(),'Have an account?')]"));
        IWebElement UserNameFld => driver.FindElement(By.CssSelector("[placeholder='Username']"));
        IWebElement EmailFld => driver.FindElement(By.CssSelector("[placeholder='Email']"));
        IWebElement PasswordFld => driver.FindElement(By.CssSelector("[placeholder='Password']"));
        IWebElement SignUpBtn => driver.FindElement(By.CssSelector("[type='submit']"));
        IWebElement HomePageTitle => driver.FindElement(By.XPath("//*[contains(text(),'A place to share your knowledge.')]"));
        IWebElement SignInLink => driver.FindElement(By.XPath("//*[contains(text(),'Sign in')]"));

        private string randomUsername = null;

        public void GoToHomepage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://angularjs.realworld.io/");
        }

        public void AssertPageTitle()
        {
            Assert.That(HomePageTitle.Text, Contains.Substring("A place to share your knowledge."), "Error message");
        }

        public void VerifyNotLoggedIn()
        {
            if (SignInLink.Displayed)
            {
                Console.WriteLine("User is not logged in");
            }
            else
            {
                Console.WriteLine("User is logged in.");
                driver.Quit();
            }
        }

        public void SignUp()
        {
            Random rnd = new Random();
            int randNumb = rnd.Next(1, 999999);
            randomUsername = "Username" + randNumb;
            SignUpLink.Click();
            Assert.That(SignUpPageAssert.Text, Contains.Substring("Have an account?"), "Error message");
            UserNameFld.SendKeys(randomUsername);
            EmailFld.SendKeys(randNumb + "mail@testmail.com");
            PasswordFld.SendKeys("Password123");
            SignUpBtn.Click();
            Thread.Sleep(2000);
        }

        public void AssertUsernameDisplayed()
        {
            var UsernameVerify = driver.FindElement(By.CssSelector("[href='#/@" + randomUsername + "']"));
            if (UsernameVerify.Displayed)
            {
                Console.WriteLine("The username " + randomUsername + " has been verified");
            }
            else
            {
                Console.WriteLine("The username " + randomUsername + " has NOT been verified");
                driver.Quit();
            }
        }
    }
}

