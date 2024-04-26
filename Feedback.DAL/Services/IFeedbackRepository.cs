using Feedback.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.DAL.Services
{
    public interface IFeedbackRepository
    {
        public Task<Contact> AddContact(string name, string email, string phoneNumber);

        public Task<FeedbackMessage> AddFeedback(FeedbackMessageInputModel feedbackMessage);

        public Task<Contact> GetContact(string phoneNumber);

        public Task<IEnumerable<Contact>> GetContacts();

        public Task<IEnumerable<FeedbackMessage>> GetFeedbacks();
    }
}
