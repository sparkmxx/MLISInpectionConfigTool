using DapperExtensions.Mapper;

namespace RedNoble.Inspection.Integration.Specimen.Entity
{
    public sealed class SpecimenIntegrationDtoMapper : ClassMapper<SpecimenIntegrationDto>
    {
        public SpecimenIntegrationDtoMapper()
        {
            Table("Specimens");
            Map(p => p.Patient).Ignore();
            Map(p => p.SpecimenInspectionItems).Ignore();
            AutoMap();
        }
    }

    public sealed class PatientIntegrationDtoMapper : ClassMapper<PatientIntegrationDto>
    {
        public PatientIntegrationDtoMapper()
        {
            Table("Patients");
            AutoMap();
        }
    }

    public sealed class SpecimenInspectionItemIntegrtionDtoMapper : ClassMapper<SpecimenInspectionItemIntegrtionDto>
    {
        public SpecimenInspectionItemIntegrtionDtoMapper()
        {
            Table("SpecimenInspectionItems");
            AutoMap();
        }
    }
}