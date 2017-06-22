using RedNoble.Inspection.Integration.Report;
using RedNoble.Inspection.Integration.Webservice.LisService;

namespace RedNoble.Inspection.Integration.Webservice.Report
{
    public class SendReportHandler : ISendReportHandler
    {
        public bool Invoke(SendReportInput input)
        {

            var service = ServiceFactory.Create();

            var report = new report();

            //report 根据input进行组装

            var result = service.saveTestResult(report);

            return true;
        }
    }
}