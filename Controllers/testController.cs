using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class testController : ControllerBase
{
    public static List<string> testList = new List<string>();
    [HttpGet]
    public IActionResult Get()
    {
        return testList.Count > 0 ? Ok(testList) : NotFound("List is empty");
    }
    [HttpPost]
    public IActionResult AddElement([FromBody] string value)
    {
        testList.Add(value);
        return Ok(testList);
    }
    [HttpDelete("{index}")]
    public IActionResult DeleteElement(int index)
    {
        if (index < 0 || index >= testList.Count)
        {
            return NotFound("Index out of range");
        }
        testList.RemoveAt(index);
        return Ok(testList);
    }
    [HttpPut("{index}")]
    public IActionResult UpdateElement(int index, [FromBody] string value)
    {
        if (index < 0 || index >= testList.Count)
        {
            return NotFound("Index out of range");
        }
        testList[index] = value;
        return Ok(testList);
    }

}
