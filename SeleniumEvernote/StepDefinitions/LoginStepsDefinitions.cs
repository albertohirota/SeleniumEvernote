using EvernoteLibrary.Page;
using EvernoteLibrary;
using System;
using TechTalk.SpecFlow;

namespace SeleniumEvernote.StepDefinitions
{
    [Binding]
    public class LoginStepsDefinitions:Login
    {
        [Given(@"Enter '([^']*)'")]
        public void GivenEnter(string userName)
        {
            CommonAction.SendKey(Login.UserName, userName);
            CommonAction.Click(Login.ButtonLogin);
        }

        [Given(@"Enter password")]
        public void GivenEnterPassword()
        {
            CommonAction.WaitSeconds(1);
            CommonAction.SendKey(Login.Password, Login.pw);
        }

        [When(@"ClickSignInButton")]
        public void WhenClickSignInButton()
        {
            CommonAction.Click(Login.ButtonSignIn);
        }

        [Then(@"user performance login page should be less than (.*) seconds")]
        public void ThenUserPerformanceLoginPageShouldBeLessThanSeconds(int expected)
        {
            DateTime clickTime = DateTime.Now;
            CommonAction.Click(Login.ButtonSignIn);
            WaitElementBePresent(Login.ButtonMenuHome, 20);
            DateTime pageLoadTime = DateTime.Now;
            int intResult = pageLoadTime.Second - clickTime.Second;
            Assert.Less(intResult, expected);
        }

        [Then(@"user should be logged")]
        public void ThenUserShouldBeLogged()
        {
            Assert.True(CommonAction.DoesElementExist(Login.ButtonMenuHome,12));
        }

        [When(@"logout")]
        public void WhenLogout()
        {
            CommonAction.WaitSeconds(9);
            CommonAction.Click(Login.MenuUserName);
            CommonAction.Click(Login.MenuButtonSignOut);
        }

        [Then(@"user should be not logged")]
        public void ThenUserShouldBeNotLogged()
        {
            Assert.True(CommonAction.DoesElementExist(Login.MessageLogOut, 20));
        }

        [Then(@"Validate user error message")]
        public void ThenValidateUserErrorMessage()
        {
            Assert.True(CommonAction.DoesElementExist(Login.UserInvalid, 12));
        }

    }
}
