namespace RedNoble.Inspection.Integration.Report
{
    public interface ISendReportHandler
    {
        bool Invoke(SendReportInput input);
    }
}