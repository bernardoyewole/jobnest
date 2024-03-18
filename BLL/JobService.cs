using DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class JobService
    {
        JobRepository jobRepository = new JobRepository();
        public List<Job> GetJobs()
        {
            List<Job> job = new List<Job>();
            job = jobRepository.GetJobs();

            return job;
        }

        public string AddJobService(Job jobFormData)
        {
            return jobRepository.AddJob(jobFormData);
        }

        public Job GetJobById(int id)
        {
            return jobRepository.GetJobByIdRepo(id);
        }

        public bool UpdateJob(Job job)
        {
            return jobRepository.UpdateJob(job);
        }

        public bool DeleteJob(int jobId)
        {
            return jobRepository.DeleteJobRepo(jobId);
        }
    }
}
