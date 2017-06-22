using System;
using RedNoble.Inspection.Integration.Report.Entity;

namespace RedNoble.Inspection.Integration.Report
{
    public interface IReportIntegrationService
    {
        bool SendReport(SendReportInput input);
    }


    public class SendReportInput
    {
        public ReportIntegrationDto Report { get; set; }
    }
}