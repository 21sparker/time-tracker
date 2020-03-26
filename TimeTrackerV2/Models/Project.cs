
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerV2
{
    public class Project
    {
        [Key]
        /// <summary>
        /// UID of WBS Code
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Name of project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// High-level type of project (build, event, etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>   
        /// 1 if the Project is Active and 0 if not, default is 1
        /// </summary>
        public int Active { get; set; }

        /// <summary>
        /// WBS Code associated with the Project
        /// </summary>
        public int WBSId { get; set; }

        /// <summary>
        /// WBS Code model associate with the Project
        /// </summary>
        [ForeignKey("WBSId")]
        public WBS WBS { get; set; }
        
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
