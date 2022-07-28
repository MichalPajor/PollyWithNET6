using System.Net;
using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public RequestController( IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    //GET api/v1/Request
    [HttpGet]
    public async Task<ActionResult> MakeRequest()
    {
        var client = _clientFactory.CreateClient("HttpClient");
       
        var response = await client.GetAsync("https://localhost:7139/api/v1/response/30");
        //var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(() => client.GetAsync("https://localhost:7139/api/v1/response/35"));

        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine("<-- Response service returned Success");
            return Ok();
        }
        System.Console.WriteLine("<-- Response service returned Failure");
        return StatusCode(StatusCodes.Status500InternalServerError);

    }
}