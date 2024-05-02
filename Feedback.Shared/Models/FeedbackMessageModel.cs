using System.ComponentModel.DataAnnotations;

namespace Feedback.Shared.Models
{
    /// <summary>
    /// Feedback message model
    /// </summary>
    public class FeedbackMessageModel
    {
        /// <summary>
        /// Id of the feedback message.
        /// </summary>
        [Key]
        public int FeedbackMessageID { get; set; }

        /// <summary>
        /// Author of the message.
        /// </summary>
        public Contact? Contact { get; set; }

        /// <summary>
        /// Topic of the message.
        /// </summary>
        public Topic? Topic { get; set; }

        /// <summary>
        /// Message text.
        /// </summary>
        public string? FeedbackMessage { get; set; }
    }
}