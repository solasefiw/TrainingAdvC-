using System.ComponentModel.DataAnnotations;

namespace LINQ.Model
{
    public class Subscriptions
    {
        [Key]
        public int Id { get; set; }
        public int ShareholderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime SubscriptionDate { get; set; }
    }
}
