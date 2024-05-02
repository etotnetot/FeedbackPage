using Feedback.Shared.Models;
using System.Data;
using Dapper;

namespace Feedback.DAL.Services
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DataContext _dataContext;

        public FeedbackRepository(DataContext dataContext) => _dataContext = dataContext;

        /// <summary>
        /// Adds new contact to database.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="email">Email of the user.</param>
        /// <param name="phoneNumber">Phone number of the user.</param>
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

        /// <summary>
        /// Adds new feedback to database.
        /// </summary>
        /// <param name="feedbackMessage">Input data.</param>
        /// <returns></returns>
        public async Task<FeedbackMessageModel> AddFeedback(FeedbackMessageInputModel feedbackMessage)
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

                var createdFeedback = new FeedbackMessageModel
                {
                    FeedbackMessageID = id,
                    Contact = GetContact(feedbackMessage.PhoneNumber, feedbackMessage.Email).Result,
                    Topic = GetTopics().Result.FirstOrDefault(topic => topic.TopicID == feedbackMessage.TopicID),
                    FeedbackMessage = feedbackMessage.Message
                };

                return createdFeedback;
            }
        }

        /// <summary>
        /// Retrieves the contact from database.
        /// </summary>
        /// <param name="phoneNumber">Phone number of the contact.</param>
        /// <param name="email">Email of the contact.</param></param>
        public async Task<Contact> GetContact(string phoneNumber, string email)
        {
            string query = @"SELECT * FROM contacts WHERE PhoneNumber = @phoneNumber AND Email = @email";

            using (var connection = _dataContext.CreateConnection())
            {
                var contact = await connection.QuerySingleOrDefaultAsync<Contact>(query, new { phoneNumber = phoneNumber, email = email });

                return contact;
            }
        }

        /// <summary>
        /// Retrieves all contacts from database.
        /// </summary>
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            string query = "SELECT * FROM Contacts";

            using (var connection = _dataContext.CreateConnection())
            {
                var contacts = await connection.QueryAsync<Contact>(query);

                return contacts.ToList();   
            }
        }

        /// <summary>
        /// Retrieves all feedbacks from database.
        /// </summary>
        public async Task<IEnumerable<FeedbackMessageModel>> GetFeedbacks()
        {
            var query = @"SELECT f.FeedbackMessageID, f.ContactID, f.TopicID, f.FeedbackMessage, c.ContactID, c.ContactName,
                            c.Email, c.PhoneNumber, t.TopicID, t.TopicName
                            FROM feedback_messages f 
                            INNER JOIN contacts c ON f.ContactID = c.ContactID
                            INNER JOIN topics t ON f.TopicID = t.TopicID";

            using (var connection = _dataContext.CreateConnection())
            {
                var feedbackMessages = connection.QueryAsync<FeedbackMessageModel, Contact, Topic, FeedbackMessageModel>(query, (feedbackMessage, contact, topic) => {
                    feedbackMessage.Contact = contact;
                    feedbackMessage.Topic = topic;

                    return feedbackMessage;
                }, splitOn: "ContactID, TopicID");     

                return feedbackMessages.Result;
            }
        }

        /// <summary>
        /// Retrieves all topics from database.
        /// </summary>
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