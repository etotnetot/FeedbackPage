using System.ComponentModel.DataAnnotations;

namespace Feedback.Shared.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        public string? ContactName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}