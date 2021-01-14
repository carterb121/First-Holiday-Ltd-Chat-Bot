using System;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic.Pages
{
    public class BudgetPage : IBudgetPage
    {
        public Budget GetBudgetFromUser()
        {
            Budget queryBudget = new Budget();
            queryBudget.MinimumBudget = Budget_ParseStringToInt("minimum");
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

            Console.WriteLine($"What is the {budgetType} amount you are willing to spend on a holiday?");
            Console.WriteLine("\n");

            string userInput = Console.ReadLine();
            Console.WriteLine("\n");

            var canBeParsed = Budget_CheckValueCanBeParsed(userInput);

            if (!canBeParsed)
            {
                return 0;
            }

            return Convert.ToInt32(userInput);
        }

        private bool Budget_CheckValueCanBeParsed(string value)
        {
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
