using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestProject1.Interfaces;

namespace TestProject1.Steps
{
    [Binding]
    public class TopRatedMoviesSteps
    {
        public ITopRatedMoviesPage TopRatedMoviesPage;
        public ISearchResultPage SearchresultsPage;

        public TopRatedMoviesSteps(ITopRatedMoviesPage topRatedMoviesPage, ISearchResultPage searchResultPage)
        {
            TopRatedMoviesPage = topRatedMoviesPage;
            SearchresultsPage = searchResultPage;
        }

        [Given(@"I am on the Top rated Movies page")]
        public void GivenIAmOnTheTopRatedMoviesPage()
        {
            TopRatedMoviesPage.NavigateToBaseUrl();
        }

        [When(@"I search for Genre as ""(.*)""")]
        public void WhenISearchForGenreAs(string genreType)
        {
            TopRatedMoviesPage.EnterSearchText(genreType);
            TopRatedMoviesPage.ClickOnSearchButton();
        }

        [Then(@"I should see list of movies that should only contain ""(.*)"", ""(.*)"" or ""(.*)""")]
        public void ThenIShouldSeeListOfMoviesThatShouldOnlyContainOr(string genreType1, string genreType2, string genreType3)
        {
            IList<String> searchResultList = SearchresultsPage.GetListOfSearchResults();
            bool bFlag = true;

            foreach (var value in searchResultList)
            {
                if (!value.ToLower().Contains(genreType1) && !value.ToLower().Contains(genreType2) && !value.ToLower().Contains(genreType3))
                {
                    Console.WriteLine(value + " does not contain comedy, comedic or Comedia");
                    bFlag = false;
                }
            }
            Assert.IsTrue(bFlag);
        }
    }
}
