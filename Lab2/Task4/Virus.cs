using System;
using System.Collections.Generic;
public class Virus : ICloneable
{
    public string Name { get; set; }
    public string Species { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(string name, string species, double weight, int age)
    {
        Name = name;
        Species = species;
        Weight = weight;
        Age = age;
        Children = new List<Virus>();
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public object Clone()
    {
        Virus clone = (Virus)this.MemberwiseClone();

        clone.Children = new List<Virus>();
        foreach (var child in Children)
        {
            clone.Children.Add((Virus)child.Clone());
        }
        return clone;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Species: {Species}, Weight: {Weight}, Age: {Age}");
        foreach (var child in Children)
        {
            Console.WriteLine($"  Child -> Name: {child.Name}, Species: {child.Species}");
        }
    }
}
