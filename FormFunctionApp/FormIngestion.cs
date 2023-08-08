using System;
using FormFunctionApp.Services.FormsIngestionService;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FormFunctionApp
{
    public class FormIngestion
    {
        private readonly IFormsIngestionService _formsIngestionService;
        public FormIngestion(IFormsIngestionService formsIngestionService)
        {
            _formsIngestionService = formsIngestionService;
        }
        [FunctionName("FormIngestion")]
        public async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            await _formsIngestionService.StartFormIngestion(log);
        }
    }
}
