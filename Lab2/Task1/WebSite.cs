using System;
using Subscriptions;

namespace Creators
{
    public class WebSite : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine("[WebSite] Створює підписку...");
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
