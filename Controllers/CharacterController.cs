
using Microsoft.AspNetCore.Mvc;
using WebApiWOT;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private static List<Character> characters =
    [
    new Character { Name = "Rand al'Thor", Age = 22, MagicUser = true, Weapon = "sword", HomeTown = "Emond's Field" },
    new Character { Name = "Egwene al'Vere", Age = 21, MagicUser = true, Weapon = "Saidar", HomeTown = "Emond's Field" }
];

    [HttpGet]
    public List<Character> GetCharacters()
    {
        return characters;
    }

    [HttpPost]
    public void CreateCharacter([FromBody] Character newCharacter)
    {
        characters.Add(newCharacter);
    }

    [HttpGet("{name}")]
    public Character getCharacterByName(string name)
    {
        return characters.FirstOrDefault(word => word.Name == name);
    }
    [HttpDelete("{name}")]
    public void deleteCharacterByName(string name)
    {
        var character = characters.FirstOrDefault(character => character.Name == name);

        characters.Remove(character);
    }
    [HttpPatch("{name}")]
    public void UppdateCharacterByName(string name, [FromBody] Character character)
    {
        var characterToUpdate = characters.FirstOrDefault(character => character.Name == name);

        characterToUpdate.Age = character.Age;
        characterToUpdate.Name = character.Name;
        characterToUpdate.Weapon = character.Weapon;
        characterToUpdate.MagicUser = character.MagicUser;
        characterToUpdate.HomeTown = character.HomeTown;
    }

}