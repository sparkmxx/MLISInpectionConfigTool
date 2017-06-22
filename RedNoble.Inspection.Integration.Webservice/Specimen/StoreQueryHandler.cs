using RedNoble.Inspection.Integration.Specimen;
using RedNoble.Inspection.Integration.Specimen.Entity;
using RedNoble.Inspection.Integration.Webservice.LisService;

namespace RedNoble.Inspection.Integration.Webservice.Specimen
{
    public class StoreQueryHandler :  IStoreQueryHandler
    {

        public SpecimenIntegrationDto Invoke(StoreInput input)
        {
            var service = ServiceFactory.Create();
            var result = service.getTestInfo(input.Barcode);

            //对result进行解析组装dto
            return null;

        }

    }
}