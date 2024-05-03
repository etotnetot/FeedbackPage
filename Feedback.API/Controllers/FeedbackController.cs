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

        /// <summary>
        /// Adds new feedback to database.
        /// </summary>
        /// <param name="feedbackMessage">Feedback message to add.</param>
        [HttpPost]
        [Route("SendFeedback")]
        public async Task<IActionResult> SendFeedback([FromBody] FeedbackMessageInputModel feedbackMessage)
        {
            return Ok(await _feedbackService.SendFeedback(feedbackMessage));
        }

        /// <summary>
        /// Adds new contact to database.
        /// </summary>
        /// <param name="newContact">Contact to add.</param>
        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddContact([FromBody] Contact newContact)
        {
            return Ok(await _feedbackService.AddContact(newContact));
        }

        /// <summary>
        /// Retrieves all topics from database.
        /// </summary>
        [HttpGet]
        [Route("GetTopics")]
        public async Task<IActionResult> GetTopics()
        {
            return Ok(await _feedbackService.GetTopics());
        }

        /// <summary>
        /// Retrieves all feedbacks from database.
        /// </summary>
        [HttpGet]
        [Route("GetFeedbacks")]
        public async Task<IActionResult> GetFeedbacks()
        {
            return Ok(await _feedbackService.GetFeedbacks());
        }
    }
}