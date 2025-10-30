using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Coffee.Services;

namespace Coffee.Controllers;

/// <summary>
/// A lightweight base controller that provides common helpers and DI for derived controllers.
/// Keeps controller concerns small (SRP) and depends on abstractions (DIP).
/// </summary>
public abstract class BaseController : Controller
{
    protected readonly ILogger _logger;
    protected readonly ISiteProvider _siteProvider;

    protected BaseController(ILogger logger, ISiteProvider siteProvider)
    {
        _logger = logger;
        _siteProvider = siteProvider;
    }

    protected IActionResult ApiOk(object? value = null)
        => Ok(new { success = true, data = value });

    protected IActionResult ApiError(string message, int statusCode = 500)
    {
        Response.StatusCode = statusCode;
        return new JsonResult(new { success = false, error = message });
    }
}
