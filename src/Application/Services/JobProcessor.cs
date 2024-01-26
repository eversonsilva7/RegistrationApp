using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JobProcessor : IJobProcessor
    {
        private readonly ILogger<JobProcessor> _logger;
        private readonly IIntegrationService _integrationService;

        public JobProcessor(ILogger<JobProcessor> logger, IIntegrationService integrationService) 
        {
            _logger = logger;
            _integrationService = integrationService;
        }

        public async Task RecurringJobForClientIntegration()
        {
            _logger.LogInformation("Recurring job is starting.", nameof(JobProcessor));

            try
            {
                var pendingIntegrations = await _integrationService.GetAllIntegrationsPending();

                foreach (var integration in pendingIntegrations)
                {
                    await _integrationService.ProcessIntegration(integration.Id);
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(exception: ex, ex.Message);
                throw;
            }

            _logger.LogInformation("Recurring job is ended.", nameof(JobProcessor));
        }
    }
}
