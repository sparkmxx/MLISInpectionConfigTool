using System;
using System.Collections.Generic;
using DapperExtensions.Mapper;

namespace RedNoble.Inspection.Integration.Specimen.Entity
{
    public class SpecimenIntegrationDto
    {

        public Guid Id { get; set; }

        /// <summary>
        /// 条形码号
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 病人信息
        /// </summary>

        public  PatientIntegrationDto Patient { get; set; }

        /// <summary>
        ///     病人类型编码
        /// </summary>
        public string PatientTypeCode { get; set; }

        /// <summary>
        ///     病人类型名称
        /// </summary>
        public string PatientTypeName { get; set; }
        /// <summary>
        /// 科室编码
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     科室名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 病区编码
        /// </summary>
        public string InpatientAreaCode { get; set; }

        /// <summary>
        ///     病区名称
        /// </summary>
        public string InpatientAreaName { get; set; }

        /// <summary>
        ///     床位号
        /// </summary>
        public string BedNo { get; set; }

        /// <summary>
        /// 医生编号
        /// </summary>
        public string DoctorCode { get; set; }
        /// <summary>
        ///     医生姓名
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        ///     标本类型编码
        /// </summary>
        public string SpecimenTypeCode { get; set; }

        /// <summary>
        ///     标本类型名称
        /// </summary>
        public string SpecimenTypeName { get; set; }

        /// <summary>
        ///     申请人账号
        /// </summary>
        public string ApplicantAccount { get; set; }

        /// <summary>
        ///     申请人姓名
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        ///     申请时间
        /// </summary>
        public DateTime? ApplyDate { get; set; }

        /// <summary>
        ///     采集时间
        /// </summary>
        public DateTime? CollectDate { get; set; }

        /// <summary>
        /// 采集人
        /// </summary>
        public string CollectAccount { get; set; }

        /// <summary>
        ///     收费类型CODE
        /// </summary>
        public string ChargeTypeCode { get; set; }

        /// <summary>
        ///     收费类型名称
        /// </summary>
        public string ChargeTypeName { get; set; }

        /// <summary>
        ///     诊断
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     标本状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 是否质控
        /// </summary>
        public bool IsQC { get; set; }

        /// <summary>
        /// 医嘱id
        /// </summary>
        public string DoctorAdviceId { get; set; }


        public List<SpecimenInspectionItemIntegrtionDto> SpecimenInspectionItems { get; set; }


        #region 标本增加字段


        #endregion
    }

    public class PatientIntegrationDto
    {

        public Guid SpecimenId { get; set; }

        /// <summary>
        /// 病人编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        public string MedicalRecordNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 年龄单位
        /// </summary>
        public string AgeUnit { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
    }


    public class SpecimenInspectionItemIntegrtionDto
    {
        public Guid? SpecimenId { get; set; }

        /// <summary>
        /// 检验项目编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 检验项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     检验项的生成状态
        /// </summary>
        public bool IsGenerate { get; set; }

        /// <summary>
        /// 签收时间
        /// </summary>
        public DateTime? SignDate { get; set; }


        #region 收费信息

        /// <summary>
        /// 收费项目Id
        /// </summary>

        public string ChargeItemId { get; set; }
        /// <summary>
        /// 收费项目编码
        /// </summary>

        public string ChargeItemCode { get; set; }
        /// <summary>
        /// 收费项目名称
        /// </summary>

        public string ChargeItemName { get; set; }

        /// <summary>
        /// 收费次数
        /// </summary>

        public int ChargeNumber { get; set; }

        /// <summary>
        /// 收费时间
        /// </summary>
        public DateTime? ChargeDate { get; set; }

        /// <summary>
        /// 收费人账号
        /// </summary>

        public string ChargeAccount { get; set; }

        #endregion
    }

   
}