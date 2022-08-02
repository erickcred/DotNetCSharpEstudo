using MaoNaMassa.SharedContext;

namespace MaoNaMassa.SubscriptionContext
{
    public class Plan : Base
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}