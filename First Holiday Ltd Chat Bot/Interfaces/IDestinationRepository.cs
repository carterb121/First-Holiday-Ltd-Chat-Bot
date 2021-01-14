using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;

namespace First_Holiday_Ltd_Chat_Bot.Interfaces
{
    public interface IDestinationRepository
    {
        public List<Destination> RetrieveDestinationsByType(List<Destination> list, string type);
    }
}
