using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Interfaces
{
    public interface ISortResultPage : IBasePage
    {
        List<string> GetListofDateResults();

        List<string> GetListOfDateResultsSortedDescending();
    }
}
