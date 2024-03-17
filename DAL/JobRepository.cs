using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Context;
using Entities.Entities;

namespace DAL
{
    public class JobRepository
    {
        public List<Job> GetJobs()
        {
            JobNestDbContext context = new JobNestDbContext();
            List<Job> jobs = new List<Job>();

            foreach (Job job in context.Jobs)
            {
                jobs.Add(job);
            }

            return jobs;
        }
    }
}
