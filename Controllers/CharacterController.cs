
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
    public ActionResult CreateCharacter([FromBody] Character newCharacter)
    {
        if(newCharacter is null)
        {
            return BadRequest("data is null");
        }
        
        characters.Add(newCharacter);
        return CreatedAtAction(nameof(getCharacterByName), new {name = newCharacter.Name}, newCharacter);
    }

    [HttpGet("{name}")]
    public ActionResult<Character> getCharacterByName(string name)
    {
        var character = characters.FirstOrDefault(word => word.Name == name);
        if(character is null)
        {
            return NotFound();
        }
        return Ok(character);
    }
    [HttpDelete("{name}")]
    public ActionResult deleteCharacterByName(string name)
    {
        var character = characters.FirstOrDefault(character => character.Name == name);
        if(character is null)
        {
            return NotFound();
        }
        characters.Remove(character);
        return NoContent();
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