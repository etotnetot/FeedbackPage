using System.ComponentModel.DataAnnotations;

namespace Feedback.Shared.Models
{
    public class FeedbackMessageInputModel
    {
        [Key]
        public int FeedbackMessageID { get; set; }

        [Required(ErrorMessage = "ContactName is required.")]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        [RegularExpression(@"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$", ErrorMessage = "This field must be a phone number.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "TopicID is required.")]
        public int? TopicID { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        public string? Message { get; set; }
    }
}