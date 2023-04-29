using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace EvernoteLibrary
{
    public class CommonAction
    {
        /// <summary>
        /// Thread wait
        /// </summary>
        /// <param name="seconds"></param>
        public static void WaitSeconds(int seconds)
        {
            Thread.Sleep(seconds *1000);
        }

        /// <summary>
        /// Find element method
        /// </summary>
        /// <param name="by">Need the XPath to look the element</param>
        /// <param name="timeOut">Default timeout 5 seconds, can be manually defined</param>
        /// <returns>return the IWebElement of the element</returns>
        public static IWebElement FindElement(By by, int timeOut = 10)
        {
            _ = WaitElementBePresent(by, timeOut);
            return Driver.Instance!.FindElement(by);
        }

        /// <summary>
        /// Find all elements according to the XPath argument
        /// </summary>
        /// <param name="by">Need the XPath argument</param>
        /// <returns>Return a collection of IWebelements</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            ReadOnlyCollection<IWebElement>? findElements = null;
            try
            {
                findElements = Driver.Instance!.FindElements(by);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return findElements!;
        }

        /// <summary>
        /// Click element method
        /// </summary>
        /// <param name="by">Need the XPath to look the element</param>
        public static void Click(By by)
        {
            try
            {
                _ = WaitElementBePresent(by);
                Actions builder = new(Driver.Instance);
                builder.MoveToElement(Driver.Instance!.FindElement(by)).Click().Perform();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Send the keyboard keys to the element. This method uses the Action class to send keys
        /// </summary>
        /// <param name="by">XPath element</param>
        /// <param name="text">enter the text</param>
        public static void SendKey(By by, string text)
        {
            WaitElementBePresent(by);
            try
            {
                Actions builder = new(Driver.Instance);
                builder.MoveToElement(Driver.Instance!.FindElement(by)).Click().SendKeys(text).Perform();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Go to Page
        /// </summary>
        /// <param name="url">Enter the URL page</param>
        public static void GoToPage(string url)
        {
            Driver.Instance!.Navigate().GoToUrl(url);
            Driver.Instance.Manage().Window.Maximize();
        }

        /// <summary>
        /// Wait element be present, the default time is 5 seconds.
        /// </summary>
        /// <param name="by">Enter XPath of the element</param>
        /// <param name="iTimeout">Enter seconds you wish to wait</param>
        /// <returns>Return boolean if it was successful</returns>
        public static bool WaitElementBePresent(By by, int timeOut = 10)
        {
            bool exists = false;
            if (timeOut > 0)
            {
                try
                {
                    WebDriverWait w = new(Driver.Instance, TimeSpan.FromSeconds(timeOut));
                    exists = w.Until(drv => drv.FindElement(by).Displayed);
                } catch (NoSuchElementException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return false;
                }
                
            }
            return exists; 
        }

        /// <summary>
        /// Check if the element exist
        /// </summary>
        /// <param name="element">Enter the XPath element</param>
        /// <returns>Return boolean</returns>
        public static bool DoesElementExist(By element, int seconds = 8)
        {
            bool exists = WaitElementBePresent(element, seconds);
            return exists;
        }

        /// <summary>
        /// Get text of an item
        /// </summary>
        /// <param name="by">Element name</param>
        /// <returns></returns>
        public static string GetTextOfElement(By by)
        {
            var element = FindElement(by);
            return element.Text;
        }

        /// <summary>
        /// Switch frames
        /// </summary>
        /// <param name="by">Enter the XPath iFrame</param>
        public static void SwitchFrame(By by)
        {
            Driver.Instance!.SwitchTo().DefaultContent();
            Driver.Instance.SwitchTo().Frame(Driver.Instance.FindElement(by));
        }

        /// <summary>
        /// Go to default frame
        /// </summary>
        public static void GoToDefaultFrame()
        {
            Driver.Instance!.SwitchTo().DefaultContent();
        }
    }
}
