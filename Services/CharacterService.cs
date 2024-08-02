
namespace WebApiWOT.Services;
public class CharacterService{

    private static List<Character> characters =
    [
    new Character { Name = "Rand al'Thor", Age = 22, MagicUser = true, Weapon = "sword", HomeTown = "Emond's Field" },
    new Character { Name = "Egwene al'Vere", Age = 21, MagicUser = true, Weapon = "Saidar", HomeTown = "Emond's Field" }
    ];

    public List<Character> GetListOfCharacters()
    {
        return characters;
    }

    public Character CreateCharacter(Character newCharacter)
    {
        characters.Add(newCharacter);
        return newCharacter;
    }
    public Character GetCharacterByName(string name)
    {
        return characters.FirstOrDefault(find => find.Name == name);
    }
    public void DeleteCharacter(Character character)
    {
        characters.Remove(character);
    }

    internal void UppdateCharacter(Character characterToUpdate, Character character)
    {
        
        characterToUpdate.Age = character.Age;
        characterToUpdate.Name = character.Name;
        characterToUpdate.Weapon = character.Weapon;
        characterToUpdate.MagicUser = character.MagicUser;
        characterToUpdate.HomeTown = character.HomeTown;
    }
}