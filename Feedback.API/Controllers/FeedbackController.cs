using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Feedback.Shared.Models;

namespace Feedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpPost]
        [Route("AddFeedback")]
        public async Task<IActionResult> AddUser([FromBody] FeedbackMessage newUser)
        {
            return Ok();
        }
    }
}
