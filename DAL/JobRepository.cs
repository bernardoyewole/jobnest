using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class JobRepository
    {
        public List<Job> GetJobs()
        {
            JobNestDbContext context = new JobNestDbContext();
            return context.Jobs.Include(j => j.Applications).ToList();
        }
    }
}
