namespace RedNoble.Inspection.Integration.Report
{
    public class ReportIntegrationService : IReportIntegrationService
    {
        private readonly ISendReportHandler _sendReportHandler;

        public ReportIntegrationService(ISendReportHandler sendReportHandler)
        {
            _sendReportHandler = sendReportHandler;
        }

        public bool SendReport(SendReportInput input)
        {
            return _sendReportHandler.Invoke(input);
        }

    }
}