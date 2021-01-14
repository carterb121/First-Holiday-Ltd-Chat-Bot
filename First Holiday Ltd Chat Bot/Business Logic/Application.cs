using System;
using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic
{
    class Application : IApplicationStart
    {
        private readonly IHolidayType _holidayType;
        private readonly IShared _shared;
        private readonly IPartyNumberPage _partyNumberPage;
        private readonly IBudgetPage _budgetPage;
        private readonly IDestinationFilter _destinationFilter;
        private readonly IResultsPage _resultsPage;

        public Application(IHolidayType holidayType,
            IShared shared,
            IPartyNumberPage partyNumberPage,
            IBudgetPage budgetPage,
            IDestinationFilter destinationFilter,
            IResultsPage resultsPage)
        {
            _holidayType = holidayType;
            _shared = shared;
            _partyNumberPage = partyNumberPage;
            _budgetPage = budgetPage;
            _destinationFilter = destinationFilter;
            _resultsPage = resultsPage;
        }


        public void StartApplication()
        {
            // Begin Application
            Application_StartApplication();

            // Get list of destinations
            List<Destination> destinations = Application_GetDestinationByHolidayType();

            // Get party size
            int partySize = Application_GetPartySizeFromUser();

            // Get min and max budgets
            Console.WriteLine("Now, we need to talk money!");
            Console.WriteLine("\n");
            Budget userBudget = Application_GetBudgetFromUser();

            // Determine which holidays are suitable!
            List<Destination> filteredDestinations = Application_FilterDestinations(destinations, partySize, userBudget);

            // Display results!
            Application_DisplayResults(filteredDestinations, destinations);

            //Return to start of application
            StartApplication();
        }

        private void Application_StartApplication()
        {
            _shared.Shared_StartSearchOrQuit();

            _shared.Shared_Divider();
        }

        private List<Destination> Application_GetDestinationByHolidayType()
        {
            Console.Clear();
            List<Destination> destinations = _holidayType.HolidayType_ReturnDestinations();

            _shared.Shared_Divider();

            return destinations;
        }

        private int Application_GetPartySizeFromUser()
        {
            int partySize = _partyNumberPage.PartyNumber_ReturnPartyNumber();

            _shared.Shared_Divider();

            return partySize;
        }

        private Budget Application_GetBudgetFromUser()
        {
            Budget userBudget = new Budget();

            userBudget.StringMinimumBudget = _budgetPage.Budget_FindBudget("minimum");
            Application_ValidateUserInput(userBudget.StringMinimumBudget);
            userBudget.MinimumBudget = _budgetPage.Budget_ConvertValueToInt(userBudget.StringMinimumBudget);

            _shared.Shared_Divider();

            userBudget.StringMaximumBudget = _budgetPage.Budget_FindBudget("maximum");
            Application_ValidateUserInput(userBudget.StringMaximumBudget);
            userBudget.MaximumBudget = _budgetPage.Budget_ConvertValueToInt(userBudget.StringMaximumBudget);

            try
            { 
                _budgetPage.Budget_CheckMinAmountLessThanMaxAmount(userBudget);
            }
            catch
            {
                Application_GetBudgetFromUser();
            }

            return userBudget;
        }

        private void Application_ValidateUserInput(string userInput)
        {
            bool isInputValid = _budgetPage.Budget_ValidateUserInput(userInput);
            if (isInputValid == false)
            {
                Application_GetBudgetFromUser();
            }
        }

        private List<Destination> Application_FilterDestinations(List<Destination> destinations, int partySize,
            Budget budget)
        {
            List<Destination> filteredDestinations = _destinationFilter.DestinationFilter_FilterBySuitability(destinations, partySize, budget);
            _shared.Shared_Divider();

            return filteredDestinations;
        }

        private void Application_DisplayResults(List<Destination> filteredDestinations, List<Destination> originalDestinations)
        {
            var resultsReturned = _resultsPage.ResultsPage_CheckResultsList(filteredDestinations);
            if (resultsReturned == true)
            {
                _resultsPage.ResultsPage_DisplayResults(filteredDestinations);
            }
            else
            {
                _resultsPage.ResultsPage_NoMatch(originalDestinations);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Thank you for using the chat bot!");
            Console.WriteLine("\n");
        }
    }
}
