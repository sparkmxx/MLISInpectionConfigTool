using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using RedNoble.Inspection.Integration.Specimen.Entity;

namespace RedNoble.Inspection.Integration.Specimen
{
    public class StoreQueryHandler :  IStoreQueryHandler
    {

        public virtual SpecimenIntegrationDto Invoke(StoreInput input)
        {
            return null;
        }

        

       
    }
}