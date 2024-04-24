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
        private readonly IDataService _dataService;

        public FeedbackService(IDataService dataService) { 
            _dataService = dataService;
        }

        public async Task<FeedbackMessage> SendFeedback(FeedbackMessage feedbackMessage)
        {
            if (!CheckIfContactExists(feedbackMessage.PhoneNumber, feedbackMessage.Email))
                _dataService.AddContact(feedbackMessage.Name, feedbackMessage.Email, feedbackMessage.PhoneNumber);

            return await _dataService.AddFeedback(feedbackMessage); 
        }

        //Если совокупный набор данных(Email + Телефон) совпадают, то новый контакт в таблицу не добавлять.
        public bool CheckIfContactExists(string phoneNumber, string emailAddress)
        {
            if (_dataService.GetContact(phoneNumber).Email == emailAddress)
                return true;

            return false;
        }
    }
}
