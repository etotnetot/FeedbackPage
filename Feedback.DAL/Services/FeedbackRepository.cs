using Feedback.Shared.Models;
using System.Data;
using Dapper;

namespace Feedback.DAL.Services
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DataContext _dataContext;

        public FeedbackRepository(DataContext dataContext) => _dataContext = dataContext;

        public async Task<Contact> AddContact(string name, string email, string phoneNumber)
        {
            string query = "INSERT INTO contacts (ContactName, Email, PhoneNumber) " +
                "VALUES (@ContactName, @Email, @PhoneNumber)" + "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var parameters = new DynamicParameters();

            parameters.Add("ContactName", name, DbType.String);
            parameters.Add("Email", email, DbType.String);
            parameters.Add("PhoneNumber", phoneNumber, DbType.String);

            using (var connection = _dataContext.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdContact = new Contact
                {
                    ContactID = id,
                    ContactName = name,
                    PhoneNumber = phoneNumber,
                    Email = email
                };

                return createdContact;
            }
        }

        public async Task<FeedbackMessage> AddFeedback(FeedbackMessageInputModel feedbackMessage)
        {
            string query = "INSERT INTO feedback_messages (ContactID, TopicID, FeedbackMessage) " +
                "VALUES (@ContactID, @TopicID, @FeedbackMessage)" + "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var parameters = new DynamicParameters();

            parameters.Add("ContactID", GetContact(feedbackMessage.PhoneNumber, feedbackMessage.Email).Result.ContactID, DbType.Int32);
            parameters.Add("TopicID", feedbackMessage.TopicID, DbType.Int32);
            parameters.Add("FeedbackMessage", feedbackMessage.Message, DbType.String);

            using (var connection = _dataContext.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdFeedback = new FeedbackMessage
                {
                    FeedbackMessageID = id,
                    Topic = Convert.ToString(feedbackMessage.TopicID),
                    Email = feedbackMessage.Email,
                    PhoneNumber = feedbackMessage.PhoneNumber,
                    Message = feedbackMessage.Message
                };

                return createdFeedback;
            }
        }

        public async Task<Contact> GetContact(string phoneNumber, string email)
        {
            string query = @"SELECT * FROM contacts WHERE PhoneNumber = @phoneNumber AND Email = @email";

            using (var connection = _dataContext.CreateConnection())
            {
                var contact = await connection.QuerySingleOrDefaultAsync<Contact>(query, new { phoneNumber = phoneNumber, email = email });

                return (Contact)contact;
            }
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            string query = "SELECT * FROM Contacts";

            using (var connection = _dataContext.CreateConnection())
            {
                var contacts = await connection.QueryAsync<Contact>(query);

                return contacts.ToList();   
            }
        }

        public async Task<IEnumerable<FeedbackMessage>> GetFeedbacks()
        {
            string query = "SELECT * FROM feedback_messages";

            using (var connection = _dataContext.CreateConnection())
            {
                var feedbackMessages = await connection.QueryAsync<FeedbackMessage>(query);

                return feedbackMessages.ToList();
            }
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            string query = "SELECT * FROM Topics";

            using (var connection = _dataContext.CreateConnection())
            {
                var topics = await connection.QueryAsync<Topic>(query);

                return topics.ToList();
            }
        }
    }
}