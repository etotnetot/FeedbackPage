using Feedback.Shared.Models;

namespace Feedback.DAL.Services
{
    public interface IFeedbackRepository
    {
        public Task<Contact> AddContact(string name, string email, string phoneNumber);

        public Task<FeedbackMessageModel> AddFeedback(FeedbackMessageInputModel feedbackMessage);

        public Task<Contact> GetContact(string phoneNumber, string email);

        public Task<IEnumerable<Contact>> GetContacts();

        public Task<IEnumerable<FeedbackMessageModel>> GetFeedbacks();

        public Task<IEnumerable<Topic>> GetTopics();
    }
}