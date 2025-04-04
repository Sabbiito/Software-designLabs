using System;

public sealed class Authenticator
{
    private static readonly Lazy<Authenticator> _instance =
        new Lazy<Authenticator>(() => new Authenticator());

    private Authenticator()
    {
        Console.WriteLine("Authenticator created");
    }

    public static Authenticator Instance
    {
        get
        {
            return _instance.Value;
        }
    }
}