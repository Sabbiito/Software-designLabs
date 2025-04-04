using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        ThreadStart action = () =>
        {
            var instance = Authenticator.Instance;
            Console.WriteLine($"Instance hash: {instance.GetHashCode()}");
        };

        Thread t1 = new Thread(action);
        Thread t2 = new Thread(action);
        Thread t3 = new Thread(action);
        Thread t4 = new Thread(action);
        Thread t5 = new Thread(action);

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();
        t5.Join();
    }
}
