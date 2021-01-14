
using First_Holiday_Ltd_Chat_Bot.dto;

namespace First_Holiday_Ltd_Chat_Bot.Interfaces
{
    public interface IBudgetPage
    {
        public string Budget_FindBudget(string type);

        public int Budget_ConvertValueToInt(string userInput);

        public bool Budget_CheckMinAmountLessThanMaxAmount(Budget budget);

        public bool Budget_ValidateUserInput(string input);

    }
}
