using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject1.Interfaces;

namespace TestProject1.Pages
{
    public class SortResultPage : BasePage, ISortResultPage
    {
        public SortResultPage(IWebDriver driver) : base(driver) { }
        private IList<IWebElement> DateResults=> Driver.FindElements(By.CssSelector("span.secondaryInfo"));

        public List<string> GetListofDateResults() => GetListOfValuesFromWebElement(DateResults);

        public List<string> GetListOfDateResultsSortedDescending()
        {
            return GetListOfValuesFromWebElementSortedInDescOrder(DateResults);
        }


    }
}
