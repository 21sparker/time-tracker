
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerV2
{
    public class Task
    {
        /// <summary>
        /// UID of task
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// The task itself
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The task type (ex: email, meeting, etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Foreign key to Project 
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Project model associated with the task
        /// </summary>
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        /// <summary>
        /// Date entry was added as # of seconds since Unix Epoch
        /// </summary>
        public long? CreatedDate { get; set; }

        /// <summary>
        /// Date entry was last modified as # of seconds since Unix Epoch
        /// </summary>
        public long? LastModifiedDate { get; set; }

        /// <summary>
        /// Date entry was soft-deleted as # of seconds since Unix Epoch
        /// </summary>
        public long? DeletedDate { get; set; }
    }
}
