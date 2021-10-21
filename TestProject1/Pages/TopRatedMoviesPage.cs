using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Interfaces;

namespace TestProject1.Pages
{
    public class TopRatedMoviesPage : BasePage, ITopRatedMoviesPage
    {
        public TopRatedMoviesPage(IWebDriver driver) : base(driver) { }
        private IWebElement SearchField => Driver.FindElement(By.CssSelector("input[name='q']"));
        private IWebElement SearchButton => Driver.FindElement(By.Id("suggestion-search-button"));
        private IWebElement Sortby => Driver.FindElement(By.CssSelector("select[name='sort']"));
        

        public void EnterSearchText(string text)
        {
            SearchField.SendKeys(text);
        }

        public void ClickOnSearchButton()
        {
            SearchButton.Click();
        }

        public void SortBy(string sortName)
        {
            SelectFromValueListDropDown(Sortby, sortName);
        }

    }
}
