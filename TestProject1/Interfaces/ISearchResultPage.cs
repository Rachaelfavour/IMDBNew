using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Interfaces
{
    public interface ISearchResultPage :IBasePage
    {
        List<string> GetListOfSearchResults();
    }
}
