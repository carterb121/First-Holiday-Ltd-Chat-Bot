using System;
using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;
using System.Linq;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic.Pages
{
    class ResultsPage : IResultsPage
    {
        private readonly IShared _shared;

        public ResultsPage(IShared shared)
        {
            _shared = shared;
        }

        public bool ResultsPage_CheckResultsList(List<Destination> destinations)
        {
            if (destinations.Count > 0)
            {
                return true;
            }

            return false;
        }

        public void ResultsPage_DisplayResults(List<Destination> destinations)
        {
                Console.WriteLine("These holidays match your criteria...");
                Console.WriteLine("\n");

                ResultsPage_ResultsReturned(destinations);
        }

        public void ResultsPage_NoMatch(List<Destination> destinations)
        {
            List<Destination> sortedDestinations = destinations.OrderByDescending(d => d.Rating).ToList();
            string holidayType = sortedDestinations[0].HolidayType;

            Console.WriteLine($"I'm sorry, we can't find any {holidayType} holidays to match your criteria");
            Console.WriteLine("\n");
            Console.WriteLine($"Here are the highest rated {holidayType} destinations..." );
            Console.WriteLine("\n");

            ResultsPage_ShowTopRatedHolidays(sortedDestinations);
        }

        private void ResultsPage_ResultsReturned(List<Destination> destinations)
        {
            foreach (var destination in destinations)
            {
                Console.WriteLine(destination.Name);
                Console.WriteLine(destination.Country);
                Console.WriteLine(destination.Description);
                Console.WriteLine($"Cost: £{destination.Cost} pp");
                Console.WriteLine($"Rating: {destination.Rating} stars");
                _shared.Shared_Divider();
            }
        }

        private void ResultsPage_ShowTopRatedHolidays(List<Destination> destinations)
        {
            for (int i = 0; i < 3 && i < (destinations.Count); i++)
            {
                Console.WriteLine(destinations[i].Name);
                Console.WriteLine(destinations[i].Country);
                Console.WriteLine(destinations[i].Description);
                Console.WriteLine($"Cost: £{destinations[i].Cost} pp");
                Console.WriteLine($"Rating: {destinations[i].Rating} stars");
                _shared.Shared_Divider();
            }
        }
    }
}
