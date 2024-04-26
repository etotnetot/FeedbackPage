using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Shared.Models
{
    public class FeedbackMessageInputModel
    {
        [Key]
        public int FeedbackMessageID { get; set; }

        public string? ContactName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int? TopicID { get; set; }

        public string? Message { get; set; }
    }
}
