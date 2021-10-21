using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TestProject1.CommonSettings;

namespace TestProject1.Utilities
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress => LoadAppData.GetBaseWebUrl();
        public static void Initialize()
        {
            var browser = LoadAppData.GetTestData("browser");
            switch (browser)
            {
                case "firefox":
//Todo
                    break;
                case "chrome":
                    ChromeOptions chOptions = new ChromeOptions
                    {
                        AcceptInsecureCertificates = true
                    };

                    if ((LoadAppData.GetTestData("headless") == "true"))
                    {
                        chOptions.AddArguments("headless");
                    }

                    var service = ChromeDriverService.CreateDefaultService(@GetDriverPath());
                    Instance = new ChromeDriver(service, chOptions, TimeSpan.FromSeconds(120));
                    Instance.Manage().Window.Maximize();
                    break;
            }

            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }


        public static void Close()
        {
            Instance.Close();
        }


        private static string GetDriverPath()
        {

            var requiredPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(requiredPath);
            return requiredPath;
        }

        private static void WaitForPageLoad()
        {
            IWait<IWebDriver> wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(30.00));
            wait.Until(driver => ((IJavaScriptExecutor)Instance).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
