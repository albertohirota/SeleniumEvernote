using EvernoteLibrary.Page;
using EvernoteLibrary;
using TechTalk.SpecFlow;

namespace SeleniumEvernote.StepDefinitions
{
    [Binding]
    public class NotesStepsDefinitions: Notes
    {
        [When(@"Click new Note")]
        public void WhenClickNewNote()
        {
            WaitSeconds(6);
            Click(Notes.CreateNewNotes);
        }

        [When(@"Write a note '([^']*)'")]
        public void WhenWriteANote(string title)
        {
            WaitSeconds(3);
            CommonAction.SwitchFrame(Notes.IframeSharing);
            SendKey(Notes.TextTitle, title);
            SendKey(Notes.TextBody, "Body text");
            CommonAction.GoToDefaultFrame();
        }

        [Then(@"Validate notes exists '([^']*)'")]
        public void ThenValidateNotesExists(string title)
        {
            CommonAction.WaitSeconds(10);
            Click(Login.ButtonMenuHome);
            var exists = CommonAction.DoesElementExist(Notes.ElementByText(title));
            Assert.IsTrue(exists);
        }

        [When(@"Login again '([^']*)'")]
        public void WhenLoginAgain(string userName)
        {
            var elements = CommonAction.FindElements(Login.LoginObject);
            foreach (var element in elements)
            {
                if (element.Displayed)
                {
                    element.Click();
                    break;
                }
            }
            CommonAction.WaitSeconds(2);
            Login.RunLogin(userName);
        }
    }
}
