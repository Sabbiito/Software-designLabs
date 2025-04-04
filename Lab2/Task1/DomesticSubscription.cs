using System.Collections.Generic;

namespace Subscriptions
{
    public class DomesticSubscription : Subscription
    {
        public override string Name => "Домашня підписка";
        public override decimal MonthlyFee => 99.99m;
        public override int MinMonths => 3;
        public override List<string> Channels => new List<string> { "TV1000", "Discovery", "National Geographic" };
    }
}
