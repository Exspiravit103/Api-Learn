using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    public static List<int> idQueue = new List<int>();
    public static List<Json> data = new List<Json>();
    [HttpGet]
    public IActionResult Get()
    {
        return data.Count > 0 ? Ok(data) : NotFound("Data not found");
    }
    [HttpPost]
    public IActionResult AddElement([FromBody] string label)
    {
        var temp = new Json
        {
            id = idQueue.Count > 0 ? idQueue[0] : data.Count + 1,
            label = label,
            status = "todo"
        };
        idQueue.Remove(temp.id);
        data.Add(temp);
        return Ok(data);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteElement(int id)
    {

        if (data.RemoveAll(x => x.id == id) == 1)
        {
            idQueue.Add(id);
        }
        return Ok(data);
    }
    [HttpPut]
    public IActionResult UpdateElement([FromBody] Json updatedElement)
    {
        var existingElement = data.FirstOrDefault(x => x.id == updatedElement.id);
        if (existingElement == null)
        {
            return NotFound("Element not found");
        }
        existingElement.label = updatedElement.label;
        existingElement.status = updatedElement.status;
        return Ok(existingElement);

    }
    //    [HttpGet("debug")]
    //public IActionResult Debug()
    //{
    //    return Ok(new { IdQueue, Data });
    //}
    
    public record Json
    {
        public int id { get; set; }
        public string? label { get; set; }
        public string? status { get; set; } // "done" or "todo"

    }

}
