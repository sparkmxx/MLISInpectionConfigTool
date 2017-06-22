using System;
using System.Collections.Generic;

namespace RedNoble.Inspection.Integration.Report.Entity
{
    public class ReportIntegrationDto:BaseDto<Guid>
    {
        /// <summary>
        /// 记录单聚合引用
        /// </summary>
        public Guid? RecordId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SampleNo { get; set; }
        /// <summary>
        /// 报告日期
        /// </summary>
        public DateTime? ReportDate { get; set; }
        /// <summary>
        /// 报告类型
        /// </summary>
        public int ReportType { get; set; }
        /// <summary>
        /// 是否打印
        /// </summary>     
        public bool IsPrint { get; set; }
        /// <summary>
        /// 打印用户名
        /// </summary>
        public string PrintAccount { get; set; }
        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? PrintDate { get; set; }


        /// <summary>
        /// 报告结果类型
        /// </summary>
        public int ReportResultType { get; set; }


        public List<ReportIdentifyResultIntegrationDto> ReportIdentifyResults { get; set; }

        public ReportPatientIntegrationDto ReportPatient { get; set; }


    }


    public class ReportIdentifyResultIntegrationDto:BaseDto<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid? ReportId { get; set; }


        /// <summary>
        /// 项目CODE
        /// </summary>
        public string BacteriaCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string BacteriaName { get; set; }
        /// <summary>
        /// 培养皿
        /// </summary>
        public string PetriDish { get; set; }
        /// <summary>
        /// 培养时间
        /// </summary>
        public string CultureTime { get; set; }
        /// <summary>
        /// 发现方式
        /// </summary>
        public string FindMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TestValueCode { get; set; }

        /// <summary>
        /// 项目值
        /// </summary>
        public string TestValue { get; set; }
        /// <summary>
        /// 项目值描述
        /// </summary>
        public string TestValueDescription { get; set; }

        /// <summary>
        /// 参考范围
        /// </summary>

        public string TestValueRange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ResultTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ResultTypeName { get; set; }

        /// <summary>
        /// 仪器标识
        /// </summary>
        public string YQFlag { get; set; }
        /// <summary>
        /// 细菌序号
        /// </summary>
        public int BacteriaSerial { get; set; }
        /// <summary>
        /// 试验板序号
        /// </summary>
        public int TestBoard { get; set; }
        /// <summary>
        /// 试验板名称
        /// </summary>
        public string TestBoardName { get; set; }

        /// <summary>
        /// 是否细菌
        /// </summary>
        public bool IsBacteria { get; set; }


        public List<ReportAntibioticResultIntegrationDto> Antibiotics { get; set; }
    }


    public class ReportAntibioticResultIntegrationDto:BaseDto<int>
    {
        /// <summary>
        /// 药敏CODE
        /// </summary>
        public string AntibioticCode { get; set; }

        /// <summary>
        /// 药敏名称
        /// </summary>
        public string AntibioticName { get; set; }

        /// <summary>
        /// 药敏值
        /// </summary>
        public string TestValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MIC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// 细菌序号
        /// </summary>
        public int BacteriaSerial { get; set; }
        /// <summary>
        /// 试验板序号
        /// </summary>
        public int TestBoard { get; set; }
        /// <summary>
        /// 试验板名称
        /// </summary>
        public int OutOrder { get; set; }

        /// <summary>
        /// 折点范围
        /// </summary>
        public string BreakPointRange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AntibioticType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int? ReportIdentifyResultId { get; set; }
    }


    public class ReportPatientIntegrationDto
    {
        public Guid ReportId { get; set; }


        /// <summary>
        ///     检测日期，日期类型
        /// </summary>
        public DateTime? TestDate { get; set; }

        /// <summary>
        ///     病人类型CODE
        /// </summary>
        public string PatientTypeCode { get; set; }

        public string PatientTypeName { get; set; }

        /// <summary>
        ///     病人编号
        /// </summary>
        public string PatientCode { get; set; }

        /// <summary>
        ///     病人名称
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        ///     病人性别
        /// </summary>
        public string PatientSex { get; set; }

        /// <summary>
        ///     病人年龄
        /// </summary>
        public string PatientAge { get; set; }

        /// <summary>
        ///     病人
        /// </summary>
        public string DoctorCode { get; set; }

        public string DoctorName { get; set; }

        /// <summary>
        ///     发送标识
        /// </summary>
        public string SendFlag { get; set; }

        /// <summary>
        ///     报告人账号
        /// </summary>
        public string ReporterAccount { get; set; }

        /// <summary>
        ///     采集人账号
        /// </summary>
        public string CollectAccount { get; set; }

        /// <summary>
        ///     费用
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        ///     收费标识
        /// </summary>
        public string CostFlag { get; set; }

        /// <summary>
        ///     打印标识
        /// </summary>
        public string PrintFlag { get; set; }

        /// <summary>
        ///     打印时间
        /// </summary>
        public DateTime? PrintDate { get; set; }

        /// <summary>
        ///     诊断
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        ///     床位号
        /// </summary>
        public string BedNo { get; set; }

        /// <summary>
        ///     科室代码
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        ///     科室名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        ///     病区代码
        /// </summary>
        public string InpatientAreaCode { get; set; }
        /// <summary>
        ///     病区名称
        /// </summary>
        public string InpatientAreaName { get; set; }

        /// <summary>
        ///     申请时间
        /// </summary>
        public DateTime? ApplyDate { get; set; }

        /// <summary>
        ///     采集时间
        /// </summary>
        public DateTime? CollectDate { get; set; }



        /// <summary>
        ///     备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     标本类型CODE
        /// </summary>
        public string SpecimenTypeCode { get; set; }

        /// <summary>
        ///     标本类型名称
        /// </summary>
        public string SpecimenTypeName { get; set; }

        /// <summary>
        ///     费用类型CODE
        /// </summary>
        public string ChargeTypeCode { get; set; }

        /// <summary>
        ///     费用类型
        /// </summary>
        public string ChargeTypeName { get; set; }

        /// <summary>
        ///     年龄单位
        /// </summary>
        public string AgeUnit { get; set; }

        /// <summary>
        ///     校核标识
        /// </summary>
        public string CheckFlag { get; set; }

        /// <summary>
        ///     危急值
        /// </summary>
        public string DangerousFlag { get; set; }

        /// <summary>
        ///     样本号前缀
        /// </summary>
        public string SampleNoPrefix { get; set; }

        /// <summary>
        ///     条形码号
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        ///     检验项目以，分开
        /// </summary>
        public string InspectItem { get; set; }

        /// <summary>
        ///     检验项目以，分开
        /// </summary>
        public string InspectItemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MedicalRecordNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SignDate { get; set; }
    }
}