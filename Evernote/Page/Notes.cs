using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteLibrary.Page
{
    public class Notes: CommonAction
    {
        public static readonly By CreateNewNotes = By.XPath("//div[@id='qa-HOME_NOTE_WIDGET_CREATE_NOTE']");
        public static readonly By TextTitle = By.XPath("//textarea[@placeholder='Title']"); 
        public static readonly By TextBody = By.XPath("//*[@id='en-note']");
        public static readonly By IframeSharing = By.XPath("//iframe[@id='qa-COMMON_EDITOR_IFRAME']");
        public static readonly By NoteAction = By.XPath("//*[@id='qa-NOTE_ACTIONS']");
        public static readonly By MenuButtonMoveToTrash = By.XPath("//*[contains(text(),'Move to Trash')]");

        public static By ElementByText(string item) => By.XPath
            ("//*[contains(text(),'" + item + "')]");

        public static void CleanUpNotes()
        {
            Login.RunLogin("alberto.hirota@gmail.com");
            WaitSeconds(2);
            Click(Login.ButtonMenuHome);
            var elements = FindElements(ElementByText("Video Slots"));
            if (elements.Count != 0)
            {
                foreach (var element in elements)
                {
                    element.Click();
                    break;
                }
            }
                
            while (FindElements(NoteAction).Count > 0)
            {
                DeleteNote();
            }
        }

        public static void DeleteNote()
        {
            Click(NoteAction);
            WaitSeconds(1);
            Click(MenuButtonMoveToTrash);
            WaitSeconds(1);
        }
    }
}
