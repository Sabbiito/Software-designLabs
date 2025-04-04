using System;
using System.Collections.Generic;

namespace Subscriptions
{
    public abstract class Subscription
    {
        public abstract string Name { get; }
        public abstract decimal MonthlyFee { get; }
        public abstract int MinMonths { get; }
        public abstract List<string> Channels { get; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Тип підписки: {Name}");
            Console.WriteLine($"Місячна плата: {MonthlyFee} грн");
            Console.WriteLine($"Мінімальний період: {MinMonths} місяців");
            Console.WriteLine($"Канали: {string.Join(", ", Channels)}\n");
        }
    }
}
