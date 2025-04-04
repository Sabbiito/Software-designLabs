public class Character
{
    public string Name { get; set; }
    public string Height { get; set; }
    public string Build { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Outfit { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();
    public List<string> GoodDeeds { get; set; } = new List<string>();
    public List<string> EvilDeeds { get; set; } = new List<string>();

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Build: {Build}");
        Console.WriteLine($"HairColor: {HairColor}");
        Console.WriteLine($"EyeColor: {EyeColor}");
        Console.WriteLine($"Outfit: {Outfit}");
        Console.WriteLine("Inventory: " + string.Join(", ", Inventory));
        Console.WriteLine("Good Deeds: " + string.Join(", ", GoodDeeds));
        Console.WriteLine("Evil Deeds: " + string.Join(", ", EvilDeeds));
    }
}
