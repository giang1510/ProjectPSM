using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// every api controller class should derive from this
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase { }
