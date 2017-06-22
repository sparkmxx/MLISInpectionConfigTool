using RedNoble.Inspection.Integration.Specimen.Entity;

namespace RedNoble.Inspection.Integration.Specimen
{
    public interface IStoreQueryHandler
    {
        SpecimenIntegrationDto Invoke(StoreInput input);
    }
}