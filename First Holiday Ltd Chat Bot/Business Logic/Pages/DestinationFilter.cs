using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic.Pages
{
    class DestinationFilter : IDestinationFilter
    {
        public List<Destination> DestinationFilter_FilterBySuitability(List<Destination> destinations, int partySize, Budget budget)
        {
            List<Destination> filteredBySizeDestinations = DestinationFilter_FilterByPartySize(partySize, destinations);
            List<Destination> finalFilteredList =
                DestinationFilter_FilterListByCost(filteredBySizeDestinations, budget.MinimumBudget, budget.MaximumBudget);

            return finalFilteredList;
        }

        private List<Destination> DestinationFilter_FilterByPartySize(int partySize, List<Destination> destinations)
        {
            List<Destination> returnList = new List<Destination>();

            foreach (var destination in destinations)
            {
                if((partySize == 1 && destination.SuitableForSolo)
                    || (partySize > 1 && partySize < 3 && destination.SuitableForCouple)
                    || (partySize > 2 && partySize < 7 && destination.SuitableForFamily)
                    || (partySize >= 8 && destination.SuitableForLargeParty)) 
                {
                    returnList.Add(destination);
                }
            }

            return returnList;
        }

        private List<Destination> DestinationFilter_FilterListByCost(List<Destination> destinations, int minimumSpend, int maximumSpend)
        {
            List<Destination> returnedList = new List<Destination>();

            foreach (var destination in destinations)
            {
                if (destination.Cost >= minimumSpend && destination.Cost <= maximumSpend)
                {
                    returnedList.Add(destination);
                }
            }

            return returnedList;
        }
    }
}
