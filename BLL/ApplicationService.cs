using DAL;
using Entities.Context;
using Entities.Entities;

namespace BLL
{
    public class ApplicationService
    {
        ApplicationRepository applicationRepository = new ApplicationRepository();
        public List<Application> GetApplicationsService() 
        {
            return applicationRepository.GetApplicationsRepo();
        }

        public string AddApplicationService(Application application)
        {
            return applicationRepository.AddApplicationRepo(application);
        }

        public bool DeleteApplicationService(int applicationId)
        {
            return applicationRepository.DeleteApplicationRepo(applicationId);
        }
    }
}
