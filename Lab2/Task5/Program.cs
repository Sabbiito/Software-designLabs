using System.Reflection.Emit;

class Program
{
    static void Main(string[] args)
    {
        var heroBuilder = new HeroBuilder();
        var enemyBuilder = new EnemyBuilder();
        var director = new CharacterDirector();

        var hero = director.CreateHero(heroBuilder);
        Console.WriteLine("Hero Info:");
        hero.DisplayInfo();

        var enemy = director.CreateEnemy(enemyBuilder);
        Console.WriteLine("\nEnemy Info:");
        enemy.DisplayInfo();
    }
}