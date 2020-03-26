
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TimeTrackerV2
{
    public class WBS
    {
        [Key]
        /// <summary>
        /// UID of WBS Code
        /// </summary>
        public int WBSId { get; set; }

        /// <summary>
        /// WBS Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// WBS Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// WBS Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Tax Area the WBS Code belongs to
        /// </summary>
        public string TaxArea { get; set; }

        /// <summary>
        /// List of Projects tied to this WBS Code
        /// </summary>
        public List<Project> Projects { get; set; }

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
