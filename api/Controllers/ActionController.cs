using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("action")]
public class ActionController : ControllerBase
{
    private readonly ILogger<ActionController> _logger;

    public ActionController(ILogger<ActionController> logger)
    {
        _logger = logger;
    }

    [HttpPost("create-user")]
    public long UserCreation()
    {
        var rnd = new Random();
        return rnd.Next();
    }

    [HttpPost("create-product")]
    public long productCreation()
    {
        var rnd = new Random();
        return rnd.Next();
    }

    [HttpPost("make-order")]
    public long OrderCreation()
    {
        var rnd = new Random();
        return rnd.Next();
    }
}
