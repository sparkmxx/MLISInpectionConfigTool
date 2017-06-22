using RedNoble.Inspection.Integration.Report;

namespace RedNoble.Inspection.Integration.Oracle.Report
{
    public class SendReportHandler : ISendReportHandler
    {
        public bool Invoke(SendReportInput input)
        {
            return true;
        }
    }
}