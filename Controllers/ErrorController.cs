using Microsoft.AspNetCore.Mvc;

namespace SimpleBreakfast.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    [NonAction]
    public IActionResult OnError()
    {
        return Problem();
    }
}