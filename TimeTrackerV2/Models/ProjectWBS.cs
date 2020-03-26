
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerV2
{
    public class ProjectWBS
    {
        [Key]
        /// <summary>
        /// UID of WBS Code
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Name of project
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Description of project
        /// </summary>
        public string ProjectDescription { get; set; }

        /// <summary>
        /// High-level type of project (build, event, etc.)
        /// </summary>
        public string ProjectType { get; set; }

        /// <summary>
        /// 1 if the Project is Active and 0 if not, default is 1
        /// </summary>
        public int ProjectActive { get; set; }

        /// <summary>
        /// WBS Code associated with the Project
        /// </summary>
        public int WBSId { get; set; }




    }
}
