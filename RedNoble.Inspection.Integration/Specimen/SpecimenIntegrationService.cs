using System;
using RedNoble.Inspection.Integration.Specimen.Entity;

namespace RedNoble.Inspection.Integration.Specimen
{
    public class SpecimenIntegrationService : ISpecimenIntegrationService
    {
        private readonly IStoreQueryHandler _storeQueryHandler;

        public SpecimenIntegrationService(IStoreQueryHandler storeQueryHandler)
        {
            _storeQueryHandler = storeQueryHandler;
        }

        public SpecimenIntegrationDto StoreQuery(StoreInput input)
        {
            return _storeQueryHandler.Invoke(input);
        }

       
    }
}