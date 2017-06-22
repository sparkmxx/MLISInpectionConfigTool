using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using DapperExtensions;
using DapperExtensions.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToolTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var conn = GetConn())
            {
                var specimen = new Specimen()
                {
                    Id = Guid.NewGuid(),
                    Barcode = "1200358989--11"
                };


                var item = new SpecimenInspetItem()
                {
                    Code = "xx",
                    Name = "xxxxxx",
                    SpecimenId = Guid.Parse("B9320F23-49C6-416F-92CA-9227D8603B44")
                };
                //var i = conn.Get<Specimen>(Guid.Parse("B9320F23-49C6-416F-92CA-9227D8603B44"));
                //var i = conn.Insert(specimen);

                var group = new PredicateGroup
                {
                    Operator = GroupOperator.And,
                    Predicates = new List<IPredicate>()
               
                };

                group.Predicates.Add(Predicates.Field<Specimen>(p => p.Barcode, Operator.Eq, "1200358989--11"));
                group.Predicates.Add(Predicates.Field<Specimen>(p => p.Id, Operator.Eq, Guid.Parse("F3319EBD-2639-4B89-A013-A5BC818C96F9")));
                //                    Predicates.Field<Specimen>(p => p.Barcode, Operator.Eq, "1200358989--11"),
                //                    Predicates.Field<Specimen>(p => p.Id, Operator.Eq, Guid.Parse("F3319EBD-2639-4B89-A013-A5BC818C96F9"))


                var j = conn.Count<Specimen>(group);
            }
        }

        private IDbConnection GetConn()
        {
            var conn = new SqlConnection("Data Source=183.194.100.138; Database=abp_test; User ID=sa; Password=!@#$%qwert12345; MultipleActiveResultSets=True");
            conn.Open();
            return conn;
        }
    }


    public sealed class SpecimenMapper : ClassMapper<Specimen>
    {
        public SpecimenMapper()
        {
            Table("Specimen");
            Map(p => p.Patient).Ignore();
            Map(p => p.SpecimenInspetItems).Ignore();
            AutoMap();

            
        }
    }


    public class Specimen
    {

        public Guid Id { get; set; }

        public string Barcode { get; set; }


        public Patient Patient { get; set; }

        public List<SpecimenInspetItem> SpecimenInspetItems { get; set; }
    }

    public class Patient
    {
        public Guid SpecimenId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }


    public class SpecimenInspetItem
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid? SpecimenId { get; set; }
    }
}
