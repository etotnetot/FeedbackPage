using Feedback.Shared.Models;

namespace Feedback.BLL.Services
{
    public interface IFeedbackService
    {
        public Task<FeedbackMessageModel> SendFeedback(FeedbackMessageInputModel feedbackMessage);

        public Task<Contact> AddContact(Contact contact);

        public bool CheckIfContactExists(string phoneNumber, string emailAddress);

        public Task<IEnumerable<Topic>> GetTopics();

        public Task<IEnumerable<FeedbackMessageModel>> GetFeedbacks();
    }
}