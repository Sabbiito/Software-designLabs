public interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetHeight(string height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder SetOutfit(string outfit);
    ICharacterBuilder AddInventoryItem(string item);
    ICharacterBuilder AddGoodDeed(string deed);
    ICharacterBuilder AddEvilDeed(string deed);
    Character Build();
}
