using System;
using System.Collections.Generic;
using DapperExtensions.Mapper;

namespace RedNoble.Inspection.Integration.Specimen.Entity
{
    public class SpecimenIntegrationDto
    {

        public Guid Id { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// ������Ϣ
        /// </summary>

        public  PatientIntegrationDto Patient { get; set; }

        /// <summary>
        ///     �������ͱ���
        /// </summary>
        public string PatientTypeCode { get; set; }

        /// <summary>
        ///     ������������
        /// </summary>
        public string PatientTypeName { get; set; }
        /// <summary>
        /// ���ұ���
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     ��������
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string InpatientAreaCode { get; set; }

        /// <summary>
        ///     ��������
        /// </summary>
        public string InpatientAreaName { get; set; }

        /// <summary>
        ///     ��λ��
        /// </summary>
        public string BedNo { get; set; }

        /// <summary>
        /// ҽ�����
        /// </summary>
        public string DoctorCode { get; set; }
        /// <summary>
        ///     ҽ������
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        ///     �걾���ͱ���
        /// </summary>
        public string SpecimenTypeCode { get; set; }

        /// <summary>
        ///     �걾��������
        /// </summary>
        public string SpecimenTypeName { get; set; }

        /// <summary>
        ///     �������˺�
        /// </summary>
        public string ApplicantAccount { get; set; }

        /// <summary>
        ///     ����������
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        ///     ����ʱ��
        /// </summary>
        public DateTime? ApplyDate { get; set; }

        /// <summary>
        ///     �ɼ�ʱ��
        /// </summary>
        public DateTime? CollectDate { get; set; }

        /// <summary>
        /// �ɼ���
        /// </summary>
        public string CollectAccount { get; set; }

        /// <summary>
        ///     �շ�����CODE
        /// </summary>
        public string ChargeTypeCode { get; set; }

        /// <summary>
        ///     �շ���������
        /// </summary>
        public string ChargeTypeName { get; set; }

        /// <summary>
        ///     ���
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        ///     ��ע
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///     �걾״̬
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// �Ƿ��ʿ�
        /// </summary>
        public bool IsQC { get; set; }

        /// <summary>
        /// ҽ��id
        /// </summary>
        public string DoctorAdviceId { get; set; }


        public List<SpecimenInspectionItemIntegrtionDto> SpecimenInspectionItems { get; set; }


        #region �걾�����ֶ�


        #endregion
    }

    public class PatientIntegrationDto
    {

        public Guid SpecimenId { get; set; }

        /// <summary>
        /// ���˱��
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string MedicalRecordNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// ���䵥λ
        /// </summary>
        public string AgeUnit { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// �ֻ���
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string Address { get; set; }
    }


    public class SpecimenInspectionItemIntegrtionDto
    {
        public Guid? SpecimenId { get; set; }

        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     �����������״̬
        /// </summary>
        public bool IsGenerate { get; set; }

        /// <summary>
        /// ǩ��ʱ��
        /// </summary>
        public DateTime? SignDate { get; set; }


        #region �շ���Ϣ

        /// <summary>
        /// �շ���ĿId
        /// </summary>

        public string ChargeItemId { get; set; }
        /// <summary>
        /// �շ���Ŀ����
        /// </summary>

        public string ChargeItemCode { get; set; }
        /// <summary>
        /// �շ���Ŀ����
        /// </summary>

        public string ChargeItemName { get; set; }

        /// <summary>
        /// �շѴ���
        /// </summary>

        public int ChargeNumber { get; set; }

        /// <summary>
        /// �շ�ʱ��
        /// </summary>
        public DateTime? ChargeDate { get; set; }

        /// <summary>
        /// �շ����˺�
        /// </summary>

        public string ChargeAccount { get; set; }

        #endregion
    }

   
}