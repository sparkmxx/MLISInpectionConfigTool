using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using RedNoble.Inspection.Integration.Specimen;
using RedNoble.Inspection.Integration.Specimen.Entity;

namespace RedNoble.Inspection.Integration.Sql.Specimen
{
    public class StoreQueryHandler :  IStoreQueryHandler
    {

        public SpecimenIntegrationDto Invoke(StoreInput input)
        {
            using (var conn = ConnectionFactory.Create())
            {

                var reader = conn.QueryMultiple(BuildSql(), new { @barcode = input.Barcode });
                var specimen = Map(reader).SingleOrDefault();
                return specimen;
            }
        }

        private static IEnumerable<SpecimenIntegrationDto> Map(SqlMapper.GridReader reader)
        {
            var specimens = reader.Read<SpecimenIntegrationDto>().ToList();
            var patients = reader.Read<PatientIntegrationDto>().ToList();
            var inspectionItems = reader.Read<SpecimenInspectionItemIntegrtionDto>().ToList();
            foreach (var specimenIntegrationDto in specimens)
            {
                specimenIntegrationDto.Patient =
                    patients.SingleOrDefault(p => p.SpecimenId == specimenIntegrationDto.Id);
                specimenIntegrationDto.SpecimenInspectionItems = inspectionItems
                    .Where(p => p.SpecimenId == specimenIntegrationDto.Id).ToList();
            }

            return specimens;
        }

        private static string BuildSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DECLARE @specimenId VARCHAR(50)                                                                 \n");
            sb.Append("SELECT TOP 1 @specimenId =Id  FROM dbo.Specimens WHERE Barcode = @barcode AND IsDeleted =0  \n");
            sb.Append("SELECT * FROM dbo.Specimens WHERE Id = @specimenId                                              \n");
            sb.Append("SELECT * FROM dbo.Patients WHERE SpecimenId = @specimenId                                       \n");
            sb.Append("SELECT * FROM dbo.SpecimenInspectionItems WHERE SpecimenId = @specimenId AND IsDeleted = 0      \n");
            return sb.ToString();
        }

       
    }
}