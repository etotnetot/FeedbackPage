using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Feedback.Shared.Models;
using Feedback.BLL.Services;

namespace Feedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        [Route("SendFeedback")]
        public async Task<IActionResult> SendFeedback([FromBody] FeedbackMessage newUser)
        {
            return Ok(_feedbackService.SendFeedback);
        }
    }
}
