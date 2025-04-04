class Program
{
    static void Main(string[] args)
    {
        Virus parentVirus = new Virus("VirusA", "TypeX", 1.5, 5);

        Virus child1 = new Virus("VirusB", "TypeY", 0.5, 3);
        Virus child2 = new Virus("VirusC", "TypeZ", 0.6, 2);
        parentVirus.AddChild(child1);
        parentVirus.AddChild(child2);

        Virus grandChild1 = new Virus("VirusD", "TypeW", 0.3, 1);
        Virus grandChild2 = new Virus("VirusE", "TypeV", 0.4, 1);
        child1.AddChild(grandChild1);
        child2.AddChild(grandChild2);

        Console.WriteLine("Original Virus Family:");
        parentVirus.DisplayInfo();

        Virus clonedVirus = (Virus)parentVirus.Clone();

        Console.WriteLine("\nCloned Virus Family:");
        clonedVirus.DisplayInfo();

        clonedVirus.Name = "ClonedVirusA";
        clonedVirus.Children[0].Name = "ClonedVirusB";

        Console.WriteLine("\nOriginal Virus Family after modification in Clone:");
        parentVirus.DisplayInfo();

        Console.WriteLine("\nCloned Virus Family after modification:");
        clonedVirus.DisplayInfo();
    }
}
