using System.ComponentModel.DataAnnotations;

namespace Feedback.Shared.Models
{
    /// <summary>
    /// Contact model.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Id of the contact.
        /// </summary>
        [Key]
        public int ContactID { get; set; }

        /// <summary>
        /// Contact name.
        /// </summary>
        public string? ContactName { get; set; }

        /// <summary>
        /// Email of the contact.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Phone number of the contact.
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}