using System;

namespace RPGDecorator
{
    public interface IHero
    {
        string GetDescription();
        int GetPower();
    }

    public class Warrior : IHero
    {
        public string GetDescription() => "Warrior";
        public int GetPower() => 10;
    }

    public class Mage : IHero
    {
        public string GetDescription() => "Mage";
        public int GetPower() => 8;
    }

    public class Palladin : IHero
    {
        public string GetDescription() => "Palladin";
        public int GetPower() => 9;
    }

    public abstract class HeroDecorator : IHero
    {
        protected IHero _hero;

        public HeroDecorator(IHero hero)
        {
            _hero = hero;
        }

        public virtual string GetDescription()
        {
            return _hero.GetDescription();
        }

        public virtual int GetPower()
        {
            return _hero.GetPower();
        }
    }

    public class Sword : HeroDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override string GetDescription()
        {
            return _hero.GetDescription() + ", with Sword";
        }

        public override int GetPower()
        {
            return _hero.GetPower() + 5;
        }
    }

    public class Armor : HeroDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override string GetDescription()
        {
            return _hero.GetDescription() + ", wearing Armor";
        }

        public override int GetPower()
        {
            return _hero.GetPower() + 3;
        }
    }

    public class MagicRing : HeroDecorator
    {
        public MagicRing(IHero hero) : base(hero) { }

        public override string GetDescription()
        {
            return _hero.GetDescription() + ", with Magic Ring";
        }

        public override int GetPower()
        {
            return _hero.GetPower() + 7;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IHero warrior = new Warrior();
            warrior = new Sword(warrior);
            warrior = new Armor(warrior);

            Console.WriteLine($"Hero: {warrior.GetDescription()}");
            Console.WriteLine($"Total Power: {warrior.GetPower()}");

            Console.WriteLine();

            IHero mage = new Mage();
            mage = new MagicRing(mage);
            mage = new Armor(mage);

            Console.WriteLine($"Hero: {mage.GetDescription()}");
            Console.WriteLine($"Total Power: {mage.GetPower()}");

            Console.WriteLine();

            IHero palladin = new Palladin();
            palladin = new Sword(palladin);
            palladin = new Armor(palladin);
            palladin = new MagicRing(palladin);

            Console.WriteLine($"Hero: {palladin.GetDescription()}");
            Console.WriteLine($"Total Power: {palladin.GetPower()}");
        }
    }
}
