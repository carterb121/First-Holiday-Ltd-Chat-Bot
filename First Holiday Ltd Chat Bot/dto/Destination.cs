namespace First_Holiday_Ltd_Chat_Bot.dto
{
    public class Destination
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string HolidayType { get; set; }

        public string Country { get; set; }

        public decimal Cost { get; set; }

        public bool SuitableForSolo { get; set; }

        public bool SuitableForCouple { get; set; }

        public bool SuitableForFamily { get; set; }

        public bool SuitableForLargeParty { get; set; }

        public decimal Rating { get; set; }
    }
}
