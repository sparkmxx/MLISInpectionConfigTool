using RedNoble.Inspection.Integration.Report;

namespace RedNoble.Inspection.Integration.Sql.Report
{
    public class SendReportHandler : ISendReportHandler
    {
        public bool Invoke(SendReportInput input)
        {
            return true;
        }
    }
}