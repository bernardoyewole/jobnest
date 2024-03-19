using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class ApplicantJobVM
    {
        public string ApplicantName { get; set; }
        public List<Application> AppliedJobs { get; set; }
    }
}
