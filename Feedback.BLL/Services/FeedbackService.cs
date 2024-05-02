using Feedback.DAL.Services;
using Feedback.Shared.Models;

namespace Feedback.BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository) => _feedbackRepository = feedbackRepository;

        /// <summary>
        /// Adds new feedback to database.
        /// </summary>
        /// <param name="feedbackMessage">Feedback message to add.</param>
        public async Task<FeedbackMessageModel> SendFeedback(FeedbackMessageInputModel feedbackMessage)
        {
            if (!CheckIfContactExists(feedbackMessage.PhoneNumber, feedbackMessage.Email))
                _feedbackRepository.AddContact(feedbackMessage.ContactName, feedbackMessage.Email, feedbackMessage.PhoneNumber);

            return await _feedbackRepository.AddFeedback(feedbackMessage);
        }

        /// <summary>
        /// Checks if contact already exists in database.
        /// </summary>
        /// <param name="phoneNumber">Contact phone number.</param>
        /// <param name="emailAddress">Contact email.</param>
        public bool CheckIfContactExists(string phoneNumber, string emailAddress)
        {
            if (_feedbackRepository.GetContact(phoneNumber, emailAddress).Result != null)
                return true;

            return false;
        }

        /// <summary>
        /// Adds new contact to database.
        /// </summary>
        /// <param name="contact">Contact to add.</param>
        public async Task<Contact> AddContact(Contact contact)
        {
            return await _feedbackRepository.AddContact(contact.ContactName, contact.Email, contact.PhoneNumber);
        }

        /// <summary>
        /// Retrieves all topics from database.
        /// </summary>
        public async Task<IEnumerable<Topic>> GetTopics()
        {
            return await _feedbackRepository.GetTopics();
        }

        public async Task<IEnumerable<FeedbackMessageModel>> GetFeedbacks()
        {
            return await _feedbackRepository.GetFeedbacks();
        }
    }
}