using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestProject1.CommonSettings;
using TestProject1.Interfaces;
using System.Linq;

namespace TestProject1.Pages
{
    public abstract class BasePage : IBasePage

    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToBaseUrl()
        {
            var baseUrl = LoadAppData.GetBaseWebUrl();
            Driver.Navigate().GoToUrl(baseUrl);
            Thread.Sleep(5000);
            WaitForPageLoad();
        }
        protected void WaitForPageLoad()
        {
            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        protected List<string> GetListOfValuesFromWebElement(IList<IWebElement> elements)
        {
            List<string> x = new List<string>();
            foreach (IWebElement element in elements)
            {
                x.Add(GetText(element));
                //x.Add(GetText(element).Replace("(","").Replace(")",""));
            }
            return x;
        }
        public string GetText(IWebElement inputElement)
        {
            WaitForElement(inputElement);
            return inputElement.Text;
        }
        private void WaitForElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            wait.Until(drv => element);
        }

        protected void SelectFromValueListDropDown(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        protected List<string> GetListOfValuesFromWebElementSorted(IList<IWebElement> elements)
        {
            List<string> x = new List<string>();
            List<string> z = new List<string>();
            foreach (IWebElement element in elements)
            {
                x.Add(GetText(element));
            }
            var after_sort = from y in x orderby y ascending select y;
            foreach (var y in after_sort)
            {
                z.Add(y);
            }
            return z;
        }

        protected List<string> GetListOfValuesFromWebElementSortedInDescOrder(IList<IWebElement> elements)
        {
            List<string> x = new List<string>();
            List<string> z = new List<string>();
            foreach (IWebElement element in elements)
            {
                x.Add(GetText(element));
            }
            var after_sort = from y in x orderby y descending select y;
            foreach (var y in after_sort)
            {
                z.Add(y);
            }
            return z;
        }
    }
}
