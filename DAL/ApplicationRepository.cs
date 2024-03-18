using Entities.Context;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class ApplicationRepository
    {
        JobRepository jobRepository = new JobRepository();
        JobNestDbContext context = new JobNestDbContext();

        public List<Entities.Entities.Application> GetApplicationsRepo()
        {
            return context.Applications.ToList();
        }

        public string AddApplicationRepo(Entities.Entities.Application applicationFormData)
        {
            if (applicationFormData != null)
            {
                context.Applications.Add(applicationFormData);
                //context.SaveChanges();
                Job job = context.Jobs.Include(j => j.Applications).SingleOrDefault(j => j.JobId == applicationFormData.JobId);
                if (job != null)
                {
                    job.Applications.Add(applicationFormData); // Add the new application to the collection
                    context.SaveChanges(); // Commit changes to update the job's Applications collection
                }
                return "success";

            }
            return "error";
        }

        public bool DeleteApplicationRepo(int applicationId)
        {
            var applicationToBeDeleted = context.Applications.Where(x => x.ApplicationId == applicationId).FirstOrDefault();

            if (applicationToBeDeleted != null)
            {
                context.Applications.Remove(applicationToBeDeleted);

                // update the applied property of the job
                //var jobInvolved = context.Jobs.Where(x => x.JobId == applicationToBeDeleted.JobId).FirstOrDefault();
                //if (jobInvolved != null)
                //{
                //    jobInvolved.Applied = false;
                //    context.SaveChanges();
                //    return true;
                //}
            }
            return false;
        }
    }
}
