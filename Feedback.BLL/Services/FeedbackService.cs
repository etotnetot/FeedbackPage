using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedback.DAL.Services;
using Feedback.Shared.Models;

namespace Feedback.BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _dataService;

        public FeedbackService(IFeedbackRepository dataService) => _dataService = dataService;

        public async Task<FeedbackMessage> SendFeedback(FeedbackMessageInputModel feedbackMessage)
        {
            if (!CheckIfContactExists(feedbackMessage.PhoneNumber, feedbackMessage.Email))
                await _dataService.AddContact(feedbackMessage.ContactName, feedbackMessage.Email, feedbackMessage.PhoneNumber);

            return await _dataService.AddFeedback(feedbackMessage); 
        }

        //Если совокупный набор данных(Email + Телефон) совпадают, то новый контакт в таблицу не добавлять.
        public bool CheckIfContactExists(string phoneNumber, string emailAddress)
        {
            if (_dataService.GetContact(phoneNumber).Result.Email == emailAddress)
                return true;

            return false;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            return await _dataService.AddContact(contact.ContactName, contact.Email, contact.PhoneNumber);
        }
    }
}