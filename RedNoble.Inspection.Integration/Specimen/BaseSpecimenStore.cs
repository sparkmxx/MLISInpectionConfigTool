using System;
using System.Collections.Generic;
using DapperExtensions;
using RedNoble.Inspection.Integration.Specimen.Entity;

namespace RedNoble.Inspection.Integration.Specimen
{
    public abstract class BaseSpecimenStore
    {
        public SpecimenIntegrationDto Store(StoreInput input)
        {
            //1.检验我们库是否存在条码(I)
            //2.得到标本实体(O)
            //3.插入数据库(I)

            if (!IsBarcodeExist(input.Barcode))
            {
                throw new Exception("标本已经入库");
            }

            var specimen = GetSpecimen(input.Barcode);
            if (specimen == null)
            {
                throw new Exception("找不到对应条码号");
            }

            StoreSpecimen(specimen);

            return specimen;
        }

        protected virtual bool IsBarcodeExist(string barcode)
        {
            using (var conn = ConnectionFactory.Create())
            {
                var group = new PredicateGroup
                {
                    Operator = GroupOperator.And,
                    Predicates = new List<IPredicate>()

                };
                group.Predicates.Add(Predicates.Field<SpecimenIntegrationDto>(p => p.Barcode, Operator.Eq, barcode));
                group.Predicates.Add(Predicates.Field<SpecimenIntegrationDto>(p => p.IsDeleted, Operator.Eq, false));

                return conn.Count<SpecimenIntegrationDto>(group) == 1;
            }

        }

        protected abstract SpecimenIntegrationDto GetSpecimen(string barcode);

        protected virtual void StoreSpecimen(SpecimenIntegrationDto specimen)
        {
            //插入我们的数据库
            using (var conn = ConnectionFactory.Create())
            {
                var specimenId = Guid.NewGuid();
                specimen.Id = specimenId;
                specimen.Patient.SpecimenId = specimenId;
                specimen.SpecimenInspectionItems.ForEach(p => p.SpecimenId = specimenId);
                specimen.Barcode += "8989";
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        conn.Insert(specimen, transaction);
                        conn.Insert(specimen.Patient, transaction);
                        specimen.SpecimenInspectionItems.ForEach(p => conn.Insert(p, transaction));
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                    }

                }

            }
        }
    }
}