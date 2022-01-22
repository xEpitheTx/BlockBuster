namespace BlockBuster.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }

        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRatePercent { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
