using Feedback.DAL.Services;
using Feedback.Shared.Models;

namespace Feedback.BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository) => _feedbackRepository = feedbackRepository;

        public async Task<FeedbackMessage> SendFeedback(FeedbackMessageInputModel feedbackMessage)
        {
            if (!CheckIfContactExists(feedbackMessage.PhoneNumber, feedbackMessage.Email))
                _feedbackRepository.AddContact(feedbackMessage.ContactName, feedbackMessage.Email, feedbackMessage.PhoneNumber);

            return await _feedbackRepository.AddFeedback(feedbackMessage);
        }

        //Если совокупный набор данных(Email + Телефон) совпадают, то новый контакт в таблицу не добавлять.
        public bool CheckIfContactExists(string phoneNumber, string emailAddress)
        {
            if (_feedbackRepository.GetContact(phoneNumber, emailAddress).Result != null)
                return true;

            return false;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            return await _feedbackRepository.AddContact(contact.ContactName, contact.Email, contact.PhoneNumber);
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            return await _feedbackRepository.GetTopics();
        }
    }
}