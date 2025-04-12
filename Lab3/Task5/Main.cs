class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // <ul class="menu">
        //   <li>Пункт 1</li>
        //   <li>Пункт 2</li>
        // </ul>

        var ul = new LightElementNode("ul", DisplayType.Block, ClosingType.Pair);
        ul.CssClasses.Add("menu");

        var li1 = new LightElementNode("li", DisplayType.Block, ClosingType.Pair);
        li1.AddChild(new LightTextNode("Пункт 1"));

        var li2 = new LightElementNode("li", DisplayType.Block, ClosingType.Pair);
        li2.AddChild(new LightTextNode("Пункт 2"));

        ul.AddChild(li1);
        ul.AddChild(li2);

        Console.WriteLine("=== Outer HTML ===");
        Console.WriteLine(ul.OuterHTML);

        Console.WriteLine("\n=== Inner HTML ===");
        Console.WriteLine(ul.InnerHTML);
    }
}
