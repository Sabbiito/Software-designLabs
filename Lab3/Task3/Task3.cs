using System;

interface IRenderer
{
    void Render(string shapeName);
}

class RasterRenderer : IRenderer
{
    public void Render(string shapeName)
    {
        Console.WriteLine($"Drawing {shapeName} as pixels.");
    }
}
class VectorRenderer : IRenderer
{
    public void Render(string shapeName)
    {
        Console.WriteLine($"Drawing {shapeName} as lines.");
    }
}
abstract class Shape
{
    protected IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
}
class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.Render("Circle");
    }
}

class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.Render("Square");
    }
}

class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.Render("Triangle");
    }
}

class Task3
{
    static void Main()
    {
        IRenderer raster = new RasterRenderer();
        IRenderer vector = new VectorRenderer();

        Shape circle = new Circle(raster);
        Shape square = new Square(vector);
        Shape triangle = new Triangle(raster);

        circle.Draw();
        square.Draw();
        triangle.Draw();
    }
}
