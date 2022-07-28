using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class ResponseController : ControllerBase
{
    //GET /api/v1/Response/50
    [Route("{id:int}")]
    [HttpGet]
    public ActionResult GetResponse(int id)
    {
        Random rng = new Random();
        var rngInt = rng.Next(1,101);
        if(rngInt > id){
            System.Console.WriteLine("--> Failure - Generate 500");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        System.Console.WriteLine("--> Success - Generate 200");
        return Ok();
    }
}