using First_Holiday_Ltd_Chat_Bot.Business_Logic;
using First_Holiday_Ltd_Chat_Bot.Business_Logic.Pages;
using First_Holiday_Ltd_Chat_Bot.Interfaces;
using First_Holiday_Ltd_Chat_Bot.Repository;


namespace First_Holiday_Ltd_Chat_Bot
{
    public class AppStart
    {
        public static void Main()
        {
            IShared shared = new Shared();
            IDestinationRepository destinationRepository = new DestinationRepositoryLogic();
            IWelcomePage welcome = new WelcomePage();
            IHolidayType holidayType = new HolidayTypePage(destinationRepository, shared);
            IPartyNumberPage partyNumber = new PartyNumberPage(shared);
            IBudgetPage budgetPage = new BudgetPage(shared);
            IDestinationFilter destinationFilter = new DestinationFilter();
            IResultsPage resultsPage = new ResultsPage(shared);

            Application applicationStart = new Application(holidayType, shared, partyNumber, budgetPage, destinationFilter, resultsPage);

            welcome.OpeningGreeting();
            applicationStart.StartApplication();
        }
    }
}