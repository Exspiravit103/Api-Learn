using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class itemsController : ControllerBase
{
    public static List<int> IdQueue = new List<int>();
    public static List<Json> Data = new List<Json>();
    [HttpGet]
    public IActionResult Get()
    {
        return Data.Count > 0 ? Ok(Data) : NotFound("Data not found");
    }
    [HttpPost]
    public IActionResult AddElement([FromBody] string label)
    {
        var Temp = new Json
        {
            Id = IdQueue.Count > 0 ? IdQueue[0] : Data.Count + 1,
            Label = label,
            Status = "todo"
        };
        IdQueue.Remove(Temp.Id);
        Data.Add(Temp);
        return Ok(Data);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteElement(int id)
    {

        if (Data.RemoveAll(x => x.Id == id) == 1)
        {
            IdQueue.Add(id);
        }
        return Ok(Data);
    }
    [HttpPut]
    public IActionResult UpdateElement([FromBody] Json updatedElement)
    {
        var existingElement = Data.FirstOrDefault(x => x.Id == updatedElement.Id);
        if (existingElement == null)
        {
            return NotFound("Element not found");
        }
        existingElement.Label = updatedElement.Label;
        existingElement.Status = updatedElement.Status;
        return Ok(existingElement);

    }
    //    [HttpGet("debug")]
    //public IActionResult Debug()
    //{
    //    return Ok(new { IdQueue, Data });
    //}
    
    public record Json
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? Status { get; set; } // "done" or "todo"

    }

}
