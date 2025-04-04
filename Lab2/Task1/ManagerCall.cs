using System;
using Subscriptions;

namespace Creators
{
    public class ManagerCall : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine("[ManagerCall] Оператор створює підписку...");
            return type switch
            {
                "Domestic" => new DomesticSubscription(),
                "Educational" => new EducationalSubscription(),
                "Premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Невідомий тип підписки")
            };
        }
    }
}
