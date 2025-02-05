using Microsoft.AspNetCore.Mvc;

namespace RESTORE.Controllers;

[ApiController]
[Route("api/Buggy/")]
public class BaseApiController : ControllerBase
{
    [HttpGet("not-found")]
    public ActionResult GetNotFound()
    {
        return NotFound("Not found");
    }
    
    [HttpGet("bad-request")]
    public ActionResult GetBadRequest()
    {
        return BadRequest(new ProblemDetails {Title = "This is a bad request"});
    }
    
    [HttpGet("unauthorized")] 
    public ActionResult GetUnauthorized()
    {
        return Unauthorized();
    } 
    
    [HttpGet("validation-error")] 
    public ActionResult GetValidationError()
    {
        ModelState.AddModelError( "Problem1", "This is a first validation error");
        ModelState.AddModelError("Problem2", "This is a second validation error");
        return ValidationProblem(); 
    } 
    
    [HttpGet("server-error")] 
    public ActionResult GetServerError ()
    { 
        throw new ApplicationException("This is a server error");
    } 
} 