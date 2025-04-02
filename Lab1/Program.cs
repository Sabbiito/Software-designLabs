using System;
using System.Text;

class Money
{
    private int wholePart;
    private int cents;

    public Money(int wholePart, int cents)
    {
        SetMoney(wholePart, cents);
    }

    public void SetMoney(int wholePart, int cents)
    {
        if (wholePart < 0 || cents < 0)
        {
            throw new ArgumentException("Сума не може бути від'ємною.");
        }

        this.wholePart = wholePart + cents / 100;
        this.cents = cents % 100;
    }

    public void Display()
    {
        Console.WriteLine($"Сума: {wholePart}.{cents:D2}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("~~~~Тестування класу Money~~~~");

        Console.Write("Введіть цілу частину грошей: ");
        int whole = int.Parse(Console.ReadLine());

        Console.Write("Введіть копійки: ");
        int cents = int.Parse(Console.ReadLine());

        Money userMoney = new Money(whole, cents);
        Console.Write("Введена вами сума: ");
        userMoney.Display();

        //тест 2:
        Money testMoney = new Money(10, 110);
        Console.Write("Автоматично створена сума: ");
        testMoney.Display();

        //тест 3:
        testMoney.SetMoney(23, 45);
        Console.Write("Після зміни значень: ");
        testMoney.Display();
    }
}