using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("action")]
public class ActionController : ControllerBase
{
    private readonly ILogger<ActionController> _logger;
    private readonly IMeterGatherService _meterGatherService;

    public ActionController(ILogger<ActionController> logger,
                            IMeterGatherService meterGatherService)
    {
        _logger = logger;
        _meterGatherService = meterGatherService;
    }

    [HttpPost("create-user")]
    public long UserCreation()
    {
        _meterGatherService.UserCreated();
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
