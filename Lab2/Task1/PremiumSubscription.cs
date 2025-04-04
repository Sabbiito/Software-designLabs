using System.Collections.Generic;

namespace Subscriptions
{
    public class PremiumSubscription : Subscription
    {
        public override string Name => "Преміум підписка";
        public override decimal MonthlyFee => 149.99m;
        public override int MinMonths => 1;
        public override List<string> Channels => new List<string> { "HBO", "Netflix", "Prime Video", "TV1000" };
    }
}
