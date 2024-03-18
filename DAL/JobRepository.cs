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
        JobNestDbContext jobNestContext = new JobNestDbContext();
        public List<Job> GetJobs()
        {
            return jobNestContext.Jobs.Include(j => j.Applications).ToList();
        }

        public string AddJob(Job jobFormData)
        {
            if (jobFormData != null)
            {
                jobNestContext.Jobs.Add(jobFormData);
                jobNestContext.SaveChanges();
                return "success";
            }
            return "error";
        }

        public Job GetJobByIdRepo(int id)
        {
            return jobNestContext.Jobs.FirstOrDefault(x => x.JobId == id);
        }

        public bool UpdateJob(Job job)
        {
            Job jobTOBeUpdated = jobNestContext.Jobs.FirstOrDefault(x => x.JobId == job.JobId);

            if (jobTOBeUpdated != null)
            {
                // Direct property assignment for debugging
                jobTOBeUpdated.CompanyName = job.CompanyName;
                jobTOBeUpdated.Position = job.Position;
                jobTOBeUpdated.Salary = job.Salary;
                jobTOBeUpdated.Location = job.Location;
                jobTOBeUpdated.StartingDate = job.StartingDate;

                try
                {
                    jobNestContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception during SaveChanges: {ex.Message}");
                    return false;
                }
            }
            return false;
        }

        public bool DeleteJobRepo(int jobId)
        {

            var job = jobNestContext.Jobs.Where(x => x.JobId == jobId).FirstOrDefault();
            if (job != null)
            {
                jobNestContext.Jobs.Remove(job);
                jobNestContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
