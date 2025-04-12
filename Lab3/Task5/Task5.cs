using System;
using System.Collections.Generic;
using System.Text;

//відображення елементу
enum DisplayType
{
    Block,
    Inline
}

//закриття тега
enum ClosingType
{
    Pair,       // <tag>...</tag>
    Single      // <tag/>
}

//абстракт вузл
abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
}

//текст вузл
class LightTextNode : LightNode
{
    private string text;

    public LightTextNode(string text)
    {
        this.text = text;
    }

    public override string OuterHTML => text;
    public override string InnerHTML => text;
}

//елемент вузл
class LightElementNode : LightNode
{
    public string TagName { get; set; }
    public DisplayType Display { get; set; }
    public ClosingType Closing { get; set; }
    public List<string> CssClasses { get; set; } = new List<string>();
    public List<LightNode> Children { get; set; } = new List<LightNode>();

    public LightElementNode(string tagName, DisplayType display, ClosingType closing)
    {
        TagName = tagName;
        Display = display;
        Closing = closing;
    }

    public override string InnerHTML
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in Children)
            {
                sb.Append(child.OuterHTML);
            }
            return sb.ToString();
        }
    }

    public override string OuterHTML
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            string classes = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";

            if (Closing == ClosingType.Single)
            {
                sb.Append($"<{TagName}{classes} />");
            }
            else
            {
                sb.Append($"<{TagName}{classes}>");
                sb.Append(InnerHTML);
                sb.Append($"</{TagName}>");
            }

            return sb.ToString();
        }
    }

    public void AddChild(LightNode child)
    {
        Children.Add(child);
    }
}
