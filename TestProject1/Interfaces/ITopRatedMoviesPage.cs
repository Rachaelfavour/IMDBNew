using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Interfaces
{
    public interface ITopRatedMoviesPage :IBasePage
    {
        void EnterSearchText(string text);
        void ClickOnSearchButton();
        void SortBy(string sortName);
    }
}
