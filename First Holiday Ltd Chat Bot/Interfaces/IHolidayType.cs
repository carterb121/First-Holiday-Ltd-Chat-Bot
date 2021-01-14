using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;

namespace First_Holiday_Ltd_Chat_Bot.Interfaces
{
    public interface IHolidayType
    {
        public List<Destination> HolidayType_ReturnDestinations();
    }
}
