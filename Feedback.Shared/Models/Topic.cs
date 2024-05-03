using System.ComponentModel.DataAnnotations;

namespace Feedback.Shared.Models
{
    /// <summary>
    /// Topic model.
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Id of the topic.
        /// </summary>
        [Key]
        public int TopicID { get; set; }

        /// <summary>
        /// Name of the topic.
        /// </summary>
        public string? TopicName { get; set; }
    }
}