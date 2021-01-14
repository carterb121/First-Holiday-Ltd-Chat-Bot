using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;

namespace First_Holiday_Ltd_Chat_Bot.Interfaces
{
    public interface IDestinationFilter
    {
        public List<Destination> DestinationFilter_FilterBySuitability(List<Destination> destinations, int partySize,
            Budget budget);
    }
}
