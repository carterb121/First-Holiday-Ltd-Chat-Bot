using System;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic.Pages
{
    public class BudgetPage : IBudgetPage
    {
        private readonly IShared _shared;

        public BudgetPage(IShared shared)
        {
            _shared = shared;
        }

        public Budget GetBudgetFromUser()
        {
            Budget queryBudget = new Budget();
            queryBudget.MinimumBudget = Budget_ParseStringToInt("minimum");

            _shared.Shared_Divider();

            queryBudget.MaximumBudget = Budget_ParseStringToInt("maximum");

            if (queryBudget.MinimumBudget > queryBudget.MaximumBudget)
            {
                queryBudget.MinimumBudget = 0;
                queryBudget.MaximumBudget = 0;
            }

            return queryBudget;
        }

        private int Budget_ParseStringToInt(string budgetType)
        {
            budgetType = budgetType.ToUpper();

            Console.WriteLine($"What is the {budgetType} amount you would like to spend per person?");
            Console.WriteLine("\n");

            Console.WriteLine("Or, if you would like to start the application again, press x ...");
            Console.WriteLine("\n");

            string userInput = Console.ReadLine();

            var canBeParsed = Budget_CheckValueCanBeParsed(userInput);

            if (!canBeParsed)
            {
                return 0;
            }

            return Convert.ToInt32(userInput);
        }

        private bool Budget_CheckValueCanBeParsed(string value)
        {
            value = value.ToLower().Trim();

            if (value == "x")
            {
                Console.Clear();
                AppStart.Main();
            }

            try
            {
                int testValue = Convert.ToInt32(value);

                if (testValue < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
