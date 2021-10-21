using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestProject1.Interfaces;

namespace TestProject1.Steps
{
    [Binding]
    public class TopRatedMoviesSortingSteps
    {
        public ISortResultPage SortResultPage;
        public ITopRatedMoviesPage TopRatedMoviesPage;

        public TopRatedMoviesSortingSteps(ISortResultPage sortResultPage, ITopRatedMoviesPage topRatedMoviesPage)
        {
            SortResultPage = sortResultPage;
            TopRatedMoviesPage = topRatedMoviesPage;
        }

        [When(@"I sort by ""(.*)""")]
        public void WhenISortBy(string sortType)
        {
            TopRatedMoviesPage.SortBy(sortType);
        }

        [Then(@"I should see the list of movies should be displayed in order of release date")]
        public void ThenIShouldSeeTheListOfMoviesShouldBeDisplayedInOrderOfReleaseDate()
        {
            Assert.AreEqual(SortResultPage.GetListofDateResults(), SortResultPage.GetListOfDateResultsSortedDescending());
        }

    }
}
