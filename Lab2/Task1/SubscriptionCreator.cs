using Subscriptions;

namespace Creators
{
    public abstract class SubscriptionCreator
    {
        public abstract Subscription CreateSubscription(string type);
    }
}
