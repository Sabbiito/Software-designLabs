using System.Collections.Generic;

namespace Subscriptions
{
    public class EducationalSubscription : Subscription
    {
        public override string Name => "Освітня підписка";
        public override decimal MonthlyFee => 59.99m;
        public override int MinMonths => 6;
        public override List<string> Channels => new List<string> { "Discovery", "History Channel", "Science" };
    }
}
