using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;

namespace First_Holiday_Ltd_Chat_Bot.Interfaces
{
    public interface IResultsPage
    {
        public void ResultsPage_DisplayResults(List<Destination> destinations);

        public bool ResultsPage_CheckResultsList(List<Destination> destinations);

        public void ResultsPage_NoMatch(List<Destination> destinations);
    }
}
