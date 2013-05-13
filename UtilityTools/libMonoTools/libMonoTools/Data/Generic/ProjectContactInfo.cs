using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libMonoTools.Data.Generic
{
    public class ProjectContactInfo
    {
        /// <summary>
        /// Gets or sets the name of the project contact.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address for the project contact.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Home page of the project contact person, not nessicarily the same as project home page,
        /// however can be project home page if the project contact doesn't want his/her person site used.
        /// </summary>
        public string HomePage { get; set; }
        public string ProjectSiteURL { get; set; }
        public string BugTrackingURL { get; set; }
    }
}
