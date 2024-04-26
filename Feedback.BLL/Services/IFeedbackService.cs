using Feedback.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.BLL.Services
{
    public interface IFeedbackService
    {
        public Task<FeedbackMessage> SendFeedback(FeedbackMessageInputModel feedbackMessage);

        public Task<Contact> AddContact(Contact contact);

        public bool CheckIfContactExists(string phoneNumber, string emailAddress);
    }
}