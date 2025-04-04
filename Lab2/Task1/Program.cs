using Creators;
using Subscriptions;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        SubscriptionCreator site = new WebSite();
        Subscription sub1 = site.CreateSubscription("Domestic");
        sub1.DisplayInfo();

        SubscriptionCreator app = new MobileApp();
        Subscription sub2 = app.CreateSubscription("Educational");
        sub2.DisplayInfo();

        SubscriptionCreator call = new ManagerCall();
        Subscription sub3 = call.CreateSubscription("Premium");
        sub3.DisplayInfo();

        Console.WriteLine("Усі підписки створено успішно.");
    }
}
