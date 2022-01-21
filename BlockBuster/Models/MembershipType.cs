namespace BlockBuster.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRatePercent { get; set; }
    }
}
