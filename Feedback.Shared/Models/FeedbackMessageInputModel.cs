using System.ComponentModel.DataAnnotations;

namespace Feedback.Shared.Models
{
    public class FeedbackMessageInputModel
    {
        /// <summary>
        /// Id of the feedback message.
        /// </summary>
        [Key]
        public int FeedbackMessageID { get; set; }

        /// <summary>
        /// Name of author of the message.
        /// </summary>
        [Required(ErrorMessage = "ContactName is required.")]
        public string? ContactName { get; set; }

        /// <summary>
        /// Email of the sender.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        [Required(ErrorMessage = "PhoneNumber is required.")]
        [RegularExpression(@"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$", ErrorMessage = "This field must be a phone number.")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Topic of the message.
        /// </summary>
        [Required(ErrorMessage = "TopicID is required.")]
        public int? TopicID { get; set; }

        /// <summary>
        /// Message text.
        /// </summary>
        [Required(ErrorMessage = "Message is required.")]
        public string? Message { get; set; }
    }
}