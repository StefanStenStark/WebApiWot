
using Microsoft.AspNetCore.Mvc;
using WebApiWOT.Services;
namespace WebApiWOT.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    CharacterService _characterService;
    public CharacterController(CharacterService characterService){
        _characterService = characterService;
    }

    [HttpGet]
    public List<Character> GetCharacters()
    {
        return _characterService.GetListOfCharacters();
    }

    [HttpPost]
    public ActionResult CreateCharacter([FromBody] Character newCharacter)
    {
        if(newCharacter is null)
        {
            return BadRequest("data is null");
        } 
        Character createdCharacter = _characterService.CreateCharacter(newCharacter);
        return CreatedAtAction(nameof(getCharacterByName), new {name = newCharacter.Name}, createdCharacter);
    }

    [HttpGet("{name}")]
    public ActionResult<Character> getCharacterByName(string name)
    {
        var character = _characterService.GetCharacterByName(name);
        if(character is null)
        {
            return NotFound();
        }
        return Ok(character);
    }
    [HttpDelete("{name}")]
    public ActionResult DeleteCharacterByName(string name)
    {
        var character = _characterService.GetCharacterByName(name);
        if(character is null)
        {
            return NotFound();
        }
        _characterService.DeleteCharacter(character);
        return NoContent();
    }
    [HttpPatch("{name}")]
    public ActionResult UppdateCharacterByName(string name, [FromBody] Character character)
    {
        var characterToUpdate = _characterService.GetCharacterByName(name);
        if(characterToUpdate is null)
        {
            return NotFound();
        }
        if(character is null){
            return BadRequest("character data is null");
        }
        _characterService.UppdateCharacter(characterToUpdate, character);
        
        return NoContent();
    }

}