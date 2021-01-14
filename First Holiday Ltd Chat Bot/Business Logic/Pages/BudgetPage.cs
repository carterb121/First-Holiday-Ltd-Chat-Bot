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

        public string Budget_FindBudget(string type)
        {
            string spendAmount = Budget_StartScript(type);
            return spendAmount;
        }

        public int Budget_ConvertValueToInt(string userInput)
        {
            int returnValue = Convert.ToInt32(userInput);
            return returnValue;
        }

        public bool Budget_ValidateUserInput(string input)
        {
            bool isInputValid = true;
            input = input.ToLower().Trim();

            if (input == "x")
            {
                Console.Clear();
                AppStart.Main();
            }
            else
            {
                try
                {
                    int testValue = Budget_ConvertValueToInt(input);
                    if (testValue <= 0)
                    {
                        _shared.Shared_Divider();
                        Console.WriteLine("I'm sorry, I don't understand your response!");
                        Console.WriteLine("\n");
                        Budget_DisplayErrorMessage();
                        isInputValid = false;
                    }
                }
                catch
                {
                    _shared.Shared_Divider();
                    Console.WriteLine("I'm sorry, I don't understand your response!");
                    Console.WriteLine("\n");
                    Budget_DisplayErrorMessage();
                    isInputValid = false;
                }
            }

            return isInputValid;
        }

        public bool Budget_CheckMinAmountLessThanMaxAmount(Budget budget)
        {
            bool validInput;
            if (budget.MinimumBudget < budget.MaximumBudget)
            {
                validInput = true;
            }
            else
            {
                _shared.Shared_Divider();
                Console.WriteLine("The maximum value needs to be larger than the minimum value");
                Console.WriteLine("\n");
                Budget_DisplayErrorMessage();
                validInput = false;
            }

            return validInput;
        }

        private string Budget_StartScript(string amountType)
        {
            amountType = amountType.ToUpper();
            Console.WriteLine($"What is the {amountType} amount you would like to spend per person?");
            Console.WriteLine("\n");
            Console.WriteLine("Or, if you would like to start the application again, press x ...");
            Console.WriteLine("\n");

            string userInput = Console.ReadLine();

            return userInput;
        }

        private void Budget_DisplayErrorMessage()
        {
            Console.WriteLine("Please re enter your minimum and maximum budget");
            Console.WriteLine("\n");
            Console.WriteLine("Please enter a whole number greater than 0");
            _shared.Shared_Divider();
        }
    }
}
