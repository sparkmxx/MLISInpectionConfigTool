using RedNoble.Inspection.Integration.Specimen.Entity;

namespace RedNoble.Inspection.Integration.Specimen
{
    public interface ISpecimenIntegrationService
    {
        /// <summary>
        /// »Îø‚≤È—Ø
        /// </summary>
        /// <param name="input"></param>
        SpecimenIntegrationDto StoreQuery(StoreInput input);

        
    }
}