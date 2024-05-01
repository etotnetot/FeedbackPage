using Feedback.Shared.Models;

namespace Feedback.DAL.Services
{
    public interface IFeedbackRepository
    {
        public Task<Contact> AddContact(string name, string email, string phoneNumber);

        public Task<FeedbackMessage> AddFeedback(FeedbackMessageInputModel feedbackMessage);

        public Task<Contact> GetContact(string phoneNumber, string email);

        public Task<IEnumerable<Contact>> GetContacts();

        public Task<IEnumerable<FeedbackMessage>> GetFeedbacks();

        public Task<IEnumerable<Topic>> GetTopics();
    }
}