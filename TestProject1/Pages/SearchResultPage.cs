using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Interfaces;

namespace TestProject1.Pages
{
    public class SearchResultPage : BasePage, ISearchResultPage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) { }

        private IList<IWebElement> SearchResults => Driver.FindElements(By.CssSelector(".result_text"));

        public List<string> GetListOfSearchResults()
        {
            return GetListOfValuesFromWebElement(SearchResults);
        }   
        
    }
}
