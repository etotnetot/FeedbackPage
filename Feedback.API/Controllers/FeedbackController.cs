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

        public FeedbackController(IFeedbackService feedbackService) => _feedbackService = feedbackService;

        [HttpPost]
        [Route("SendFeedback")]
        public async Task<IActionResult> SendFeedback([FromBody] FeedbackMessageInputModel feedbackMessage)
        {
            return Ok(await _feedbackService.SendFeedback(feedbackMessage));
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddContact([FromBody] Contact newUser)
        {
            return Ok(await _feedbackService.AddContact(newUser));
        }

        [HttpGet]
        [Route("GetTopics")]
        public async Task<IActionResult> GetTopics()
        {
            return Ok(await _feedbackService.GetTopics());
        }
    }
}