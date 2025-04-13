using System;
using System.Collections.Generic;
using System.Text;

enum DisplayType { Block, Inline }
enum ClosingType { Single, Pair }

abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
}

class LightTextNode : LightNode
{
    public string TextContent { get; set; }

    public LightTextNode(string text)
    {
        TextContent = text;
    }

    public override string OuterHTML => TextContent;
    public override string InnerHTML => TextContent;
}

class LightHTMLElementType
{
    public string TagName { get; }
    public DisplayType Display { get; }
    public ClosingType Closing { get; }

    public LightHTMLElementType(string tagName, DisplayType display, ClosingType closing)
    {
        TagName = tagName;
        Display = display;
        Closing = closing;
    }
}

class LightHTMLElementFactory
{
    private Dictionary<string, LightHTMLElementType> elements = new();

    public LightHTMLElementType GetElementType(string tagName, DisplayType display, ClosingType closing)
    {
        string key = $"{tagName}-{display}-{closing}";
        if (!elements.ContainsKey(key))
        {
            elements[key] = new LightHTMLElementType(tagName, display, closing);
        }
        return elements[key];
    }

    public int Count => elements.Count;
}

class LightElementNode : LightNode
{
    public LightHTMLElementType ElementType { get; set; }
    public List<string> CssClasses { get; set; } = new();
    public List<LightNode> Children { get; set; } = new();

    public LightElementNode(LightHTMLElementType elementType)
    {
        ElementType = elementType;
    }

    public override string InnerHTML
    {
        get
        {
            var sb = new StringBuilder();
            foreach (var child in Children)
                sb.AppendLine(child.OuterHTML); // Додаємо перенесення рядків
            return sb.ToString();
        }
    }

    public override string OuterHTML
    {
        get
        {
            string classes = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
            if (ElementType.Closing == ClosingType.Single)
                return $"<{ElementType.TagName}{classes} />";
            else
                return $"<{ElementType.TagName}{classes}>\n{InnerHTML}</{ElementType.TagName}>";
        }
    }

    public void AddChild(LightNode node)
    {
        Children.Add(node);
    }
}

class LightHTMLBuilder
{
    private LightHTMLElementFactory factory = new();

    public LightElementNode BuildFromLines(string[] lines)
    {
        var root = new LightElementNode(factory.GetElementType("div", DisplayType.Block, ClosingType.Pair));

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            LightHTMLElementType type;

            if (i == 0)
            {
                type = factory.GetElementType("h1", DisplayType.Block, ClosingType.Pair);
            }
            else if (line.StartsWith(" "))
            {
                type = factory.GetElementType("blockquote", DisplayType.Block, ClosingType.Pair);
            }
            else if (line.Length < 20)
            {
                type = factory.GetElementType("h2", DisplayType.Block, ClosingType.Pair);
            }
            else
            {
                type = factory.GetElementType("p", DisplayType.Block, ClosingType.Pair);
            }

            var element = new LightElementNode(type);
            element.AddChild(new LightTextNode(line));
            root.AddChild(element);
        }

        return root;
    }

    public int GetFlyweightCount()
    {
        return factory.Count;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        string[] lines = new[]
        {
            "ACT V",
            "Scene I. Mantua. A Street.",
            "Scene II. Friar Lawrence’s Cell.",
            "Scene III. A churchyard; in it a Monument belonging to the Capulets.",
            "",
            "  Dramatis Personæ",
            "ESCALUS, Prince of Verona.",
            "MERCUTIO, kinsman to the Prince, and friend to Romeo.",
            "PARIS, a young Nobleman, kinsman to the Prince.",
            "Page to Paris."
        };

        var builder = new LightHTMLBuilder();
        var root = builder.BuildFromLines(lines);

        Console.WriteLine("~~~Згенерований HTML~~~\n");
        Console.WriteLine(root.OuterHTML);

        Console.WriteLine($"\nКількість унікальних типів тегів (Flyweights): {builder.GetFlyweightCount()}");
        Console.WriteLine($"Кількість вузлів у дереві: {CountNodes(root)}");
    }

    static int CountNodes(LightNode node)
    {
        if (node is LightTextNode)
            return 1;

        if (node is LightElementNode el)
        {
            int count = 1;
            foreach (var child in el.Children)
                count += CountNodes(child);
            return count;
        }

        return 0;
    }
}
