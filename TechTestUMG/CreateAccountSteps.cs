using System;
using TechTalk.SpecFlow;

namespace TechTestUMG
{
    [Binding]
    public class CreateAccountSteps
    {
        BookingPage bookingPage = new BookingPage();

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            bookingPage.GoToHomepage();
            bookingPage.AssertPageTitle();
            bookingPage.VerifyNotLoggedIn();
        }

        [When(@"I complete the sign up form")]
        public void WhenICompleteTheSignUpForm()
        {
            bookingPage.SignUp();
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"my username is displayed")]
        public void ThenMyUsernameIsDisplayed()
        {
            bookingPage.AssertUsernameDisplayed();
        }

    }
}
