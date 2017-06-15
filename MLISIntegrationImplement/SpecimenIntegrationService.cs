using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Dapper;


namespace MLISIntegrationImplement
{

    public interface ISpecimenIntegrationService
    {
        void Store(StoreInput input);
    }

    public class StoreInput
    {
        public string Barcode { get; set; }
    }

    public class Specimen
    {
       
        public string Barcode { get; set; }

        public string SpecimenTypeCode { get; set; }

        public string SpecimenTypeName { get; set; }

        public Patient Patient { get; set; }

        public List<SpecimenInspectItem> SpecimenInspectItems { get; set; }
    }

    public class Patient
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }


    public class SpecimenInspectItem
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }

    public class SpecimenIntegrationService : ISpecimenIntegrationService
    {
        private static Dictionary<string, string> dicts = new Dictionary<string, string>()
        {
            {"Specimen.Barcode","T0.Barcode" },
            {"Specimen.Patient.Code","T1.ChargeItemCode" },
            {"Specimen.SpecimenInspectItems.Code","T1.Code" },
        };

        public void Store(StoreInput input)
        {
            List<DataTable> dts = new List<DataTable>();

            IDbConnection conn = new SqlConnection("Data Source=183.194.100.138; Database=RedNobleInspection; User ID=sa; Password=!@#$%qwert12345; MultipleActiveResultSets=True;");
            var query = conn.QueryMultiple("SpecimenStoreIntegration", new { @barcode = input.Barcode }, commandType: CommandType.StoredProcedure);
            while (!query.IsConsumed)
            {
                var dt = query.Read().ToDataTable();
                dts.Add(dt);
            }


            var specimen = new Specimen();

            SetValue(specimen, dts);

        }

        private void SetValue(object value, List<DataTable> dts, int objIndex = 0, string propertyName = "", List<Type> existTypes = null)
        {
            var type = value.GetType();
            if (existTypes == null) existTypes = new List<Type>();
            existTypes.Add(type);
            var properties = type.GetProperties();
            string fullPropertyName;
            foreach (var propertyInfo in properties)
            {
                fullPropertyName = propertyName + $".{propertyInfo.Name}";
                var config = dicts.FirstOrDefault(p => p.Key.Contains(fullPropertyName));
                var propertyType = propertyInfo.PropertyType;
                if (propertyType.IsClass && !IsPrimitiveExtended(propertyType))
                {
                    if (IsAssignableToGenericType(propertyType, typeof(IEnumerable<>)))
                    {
                        var nestedValue = Activator.CreateInstance(propertyType);
                        propertyInfo.SetValue(value, nestedValue);
                        var addMethod = propertyType.GetMethod("Add");
                        var innerType = propertyType.GetGenericArguments()[0];
                        if (!existTypes.Contains(innerType))
                        {
                            if (config.Key != null)
                            {
                                for (int i = 0; i < GetTableCount(dts, config); i++)
                                {
                                    var innerValue = Activator.CreateInstance(innerType);
                                    SetValue(innerValue, dts, i, propertyInfo.Name, existTypes);
                                    addMethod.Invoke(nestedValue, new[] { innerValue });
                                }
                            }
                        }

                    }
                    else
                    {
                        var nestedValue = Activator.CreateInstance(propertyType);
                        propertyInfo.SetValue(value, nestedValue);
                        if (!existTypes.Contains(propertyType))
                        {
                            SetValue(nestedValue, dts, propertyName: propertyName, existTypes: existTypes);
                        }
                    }
                }
                else
                {
                    if (config.Key != null)
                    {
                        propertyInfo.SetValue(value, GetTableValue(dts, config, objIndex));
                    }
                }
            }
        }

        private object GetTableValue(List<DataTable> dts, KeyValuePair<string, string> config, int rowIndex = 0)
        {
            string str = config.Value;
            const string regexStr = @"\d";
            var r = new Regex(regexStr);
            var m = r.Match(str);
            if (!m.Success) throw new Exception("error");
            var tbIndex = int.Parse(m.Value);
            var result = dts[tbIndex].Rows[rowIndex][str.Substring(str.IndexOf(".", StringComparison.Ordinal) + 1)];
            return result == DBNull.Value ? null : result;
        }

        /// <summary>
        /// 根据配置获取需要的行的数量
        /// </summary>
        /// <param name="dts"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private int GetTableCount(List<DataTable> dts, KeyValuePair<string, string> config)
        {
            string str = config.Value;
            const string regexStr = @"\d";
            var r = new Regex(regexStr);
            var m = r.Match(str);
            if (!m.Success) throw new Exception("error");
            var tbIndex = int.Parse(m.Value);
            return dts[tbIndex].Rows.Count;
        }

        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            foreach (var interfaceType in givenType.GetInterfaces())
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                    return true;

            if (givenType.BaseType == null)
                return false;

            return IsAssignableToGenericType(givenType.BaseType, genericType);
        }
        private static bool IsPrimitiveExtended(Type type)
        {
            if (type.IsPrimitive)
                return true;

            return type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTimeOffset) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid);
        }
    }


    public static class Extentions
    {
        public static DataTable ToDataTable(this IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (!data.Any()) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISpecimenIntegrationService specimenIntegrationService = new SpecimenIntegrationService();
            specimenIntegrationService.Store(new StoreInput() { Barcode = "8900000015" });
        }
    }

}