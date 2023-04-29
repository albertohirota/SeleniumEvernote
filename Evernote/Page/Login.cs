using OpenQA.Selenium;

namespace EvernoteLibrary.Page
{
    public class Login : CommonAction
    {
        public static readonly string pw = "V!deoSlots1";
        public static readonly By UserName = By.Id("username");
        public static readonly By Password = By.Id("password");
        public static readonly By ButtonLogin = By.XPath("//input[@id='loginButton']");
        public static readonly By ButtonSignIn = By.XPath("//input[@id='loginButton']");
        public static readonly By ButtonMenuHome = By.XPath("//*[@id='qa-NAV_HOME']");
        public static readonly By UserInvalid = By.XPath("//div[@id='responseMessage'][contains(text(),'There is no account for the username or email you entered.')]");
        public static readonly By MenuUserName = By.XPath("//div[@class='mjp8WyYQODySClV2byHt']"); //[contains(text(),'alberto.hirota@gmail.com')]
        public static readonly By MenuButtonSignOut = By.XPath("//span[contains(text(),'Sign out ')]");
        public static readonly By MessageLogOut = By.XPath("//h1[contains(text(),'You have logged out of Evernote')]");
        public static readonly By LoginObject = By.XPath("//*[contains(text(),'Log In')]");

        public static void RunLogin(string userName)
        {
            CommonAction.SendKey(UserName, userName);
            CommonAction.Click(ButtonLogin);
            CommonAction.WaitSeconds(1);
            CommonAction.SendKey(Password, pw);
            CommonAction.Click(ButtonSignIn);
        }
    }
}
