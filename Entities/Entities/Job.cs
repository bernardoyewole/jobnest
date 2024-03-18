using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    /// <summary>
    /// Entities for Job
    /// </summary>
    public class Job
    {
        // JobId, Title, Description, Location
        [Key]
        public int JobId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public string Position {  get; set; }
        public string CompanyName { get; set; }
        public int Salary { get; set; }
        public DateTime StartingDate { get; set; }
        public string Location { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}
