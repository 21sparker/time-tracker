
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerV2
{
    public class TaskHistoryItem
    {
        /// <summary>
        /// UID of TaskHistoryItem
        /// </summary>
        public int TaskHistoryItemId { get; set; }

        /// <summary>
        /// Time being charged
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// Short text 
        /// </summary>
        public string ShortText { get; set; }

        /// <summary>
        /// Start time of task
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// End time of task
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Foreign Key to Task
        /// </summary>
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }

        /// <summary>
        /// Foreign key to Project
        /// </summary>
        public int ProjectId { get; set; }

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
