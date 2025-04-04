public class CharacterDirector
{
    public Character CreateHero(ICharacterBuilder builder)
    {
        return builder.SetName("Maksim")
                      .SetHeight("6'2\"")
                      .SetBuild("Athletic")
                      .SetHairColor("Blonde")
                      .SetEyeColor("Blue")
                      .SetOutfit("Armor")
                      .AddInventoryItem("Sword")
                      .AddInventoryItem("Shield")
                      .AddGoodDeed("Rescue villagers")
                      .AddGoodDeed("Defeat dragon")
                      .Build();
    }

    public Character CreateEnemy(ICharacterBuilder builder)
    {
        return builder.SetName("Bohdan")
                      .SetHeight("6'0\"")
                      .SetBuild("Muscular")
                      .SetHairColor("Black")
                      .SetEyeColor("Red")
                      .SetOutfit("Dark robe")
                      .AddInventoryItem("Dark magic wand")
                      .AddEvilDeed("Destroy village")
                      .AddEvilDeed("Summon monsters")
                      .Build();
    }
}
