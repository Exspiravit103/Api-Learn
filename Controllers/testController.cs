using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class testController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World, Its Work!");
    }
}
