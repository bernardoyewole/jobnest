using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class EmployerJobsVM
    {
        public string UserId { get; set; }
        public string EmployerName { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
