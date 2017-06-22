using RedNoble.Inspection.Integration.Webservice.LisService;

namespace RedNoble.Inspection.Integration.Webservice
{
    public static class ServiceFactory
    {
        public static LisInfoServiceClient Create()
        {
            return new LisInfoServiceClient();
        }
    }
}