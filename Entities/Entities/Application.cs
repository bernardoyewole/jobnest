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
    /// Entities for Application
    /// </summary>
    public class Application
    {
        // primary key
        [Key]
        public int ApplicationId { get; set; }

        //[ForeignKey("ApplicationUser")]
        //[ForeignKey("ApplicationUser")]
        //public int UserId { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }

        [MaxLength(100)]
        public string FirstName {  get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public string ApplicationReason {  get; set; }

        public DateTime ApplicationDate { get; set; }

        // lazy loading of entities in EF
        //public virtual User User { get; set; }

        public virtual Job Job { get; set; }
    }
}
