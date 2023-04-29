using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteLibrary
{
    public class Driver
    {
        public enum Browsers
        {
            Firefox,
            Chrome,
            Edge
        }

        public static IWebDriver? Instance { get; set; }

        /// <summary>
        /// Initialize a browser instance
        /// </summary>
        /// <param name="browser"></param>
        public static void Initialize(Browsers browser)
        {
            Instance?.Quit();

            switch (browser)
            {
                case Browsers.Firefox:
                    FirefoxOptions fOptions = new()
                    {
                        AcceptInsecureCertificates = true
                    };
                    Instance = new FirefoxDriver(fOptions);
                    break;

                case Browsers.Chrome:
                    ChromeOptions cOptions = new();
                    Instance = new ChromeDriver(cOptions);
                    break;

                case Browsers.Edge:
                    EdgeOptions eOptions = new();
                    Instance = new EdgeDriver(eOptions);
                    break;
            }
            Instance!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
        }

        /// <summary>
        /// Close Browser
        /// </summary>
        public static void StartDriver()
        {
            Initialize(Driver.Browsers.Chrome);
            CommonAction.GoToPage("https://www.evernote.com/Login.action");
        }

        /// <summary>
        /// Close browser instance
        /// </summary>
        public static void InstanceClose()
        {
            if (Driver.Instance != null)
            {
                Instance!.Quit();
            }
        }
    }
}
