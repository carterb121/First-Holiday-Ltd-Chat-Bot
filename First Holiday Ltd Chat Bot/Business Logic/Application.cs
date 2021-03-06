﻿using System;
using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic
{
    class Application
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

        // Declare variables
        private List<Destination> destinations = new List<Destination>();
        private int partySize;

        public void StartApplication()
        {
            // Begin Application
            Application_StartApplication();

            // Get list of destinations
            destinations = Application_GetDestinationByHolidayType();
            while (destinations.Count == 0)
            {
                destinations = Application_GetDestinationByHolidayType();
            }

            // Get party size
            Console.WriteLine("Thank you!");
            Console.WriteLine("\n");

            partySize = Application_GetPartySizeFromUser();
            while (partySize == 0)
            {
                partySize = Application_GetPartySizeFromUser();
            }

            // Get min and max budgets
            Budget userBudget = Application_GetBudgetFromUser();

            // Determine which holidays are suitable!
            List<Destination> filteredDestinations = Application_FilterDestinations(destinations, partySize, userBudget);

            // Display results!
            Application_DisplayResults(filteredDestinations, destinations, userBudget);

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
            Console.WriteLine("First things first, what kind of holiday are you looking for?");
            Console.WriteLine("\n");

            List<Destination> destinations = _holidayType.HolidayType_ReturnDestinations();

            _shared.Shared_Divider();

            return destinations;
        }

        private int Application_GetPartySizeFromUser()
        {
            int userInput = _partyNumberPage.PartyNumber_ReturnPartyNumber();

            //_shared.Shared_Divider();

            return userInput;
        }

        private Budget Application_GetBudgetFromUser()
        {
            _shared.Shared_Divider();
            Console.WriteLine("Now, we need to talk money!");
            Console.WriteLine("\n");

            Budget newBudget = _budgetPage.GetBudgetFromUser();
            return newBudget;
        }

        private List<Destination> Application_FilterDestinations(List<Destination> destinations, int partySize,
            Budget budget)
        {
            List<Destination> filteredDestinations = _destinationFilter.DestinationFilter_FilterBySuitability(destinations, partySize, budget);
            _shared.Shared_Divider();

            return filteredDestinations;
        }

        private void Application_DisplayResults(List<Destination> filteredDestinations, List<Destination> originalDestinations, Budget budget)
        {
            var resultsReturned = _resultsPage.ResultsPage_CheckResultsList(filteredDestinations);
            if (resultsReturned && (budget.MinimumBudget != 0 && budget.MaximumBudget != 0))
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
