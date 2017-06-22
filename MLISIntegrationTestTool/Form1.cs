using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedNoble.Inspection.Integration;
using RedNoble.Inspection.Integration.Specimen;
using RedNoble.Inspection.Integration.Specimen.Entity;

namespace MLISIntegrationTestTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnSpecimenStoreTest_Click(object sender, EventArgs e)
        {
            var barcode = txtBarcode.Text.Trim();
            if (!string.IsNullOrWhiteSpace(barcode))
            {
                StoreQueryHandler storeQueryHandler = new StoreQueryHandler();
                var dto = storeQueryHandler.Invoke(new StoreInput(){Barcode = barcode});
                BindSpecimen(dto);
            }
        }


        private void BindSpecimen(SpecimenIntegrationDto specimen)
        {
            if (specimen == null)
            {
                throw new ArgumentNullException(nameof(specimen));
            }
            lblBarcode.Text = specimen.Barcode;
            lblPatientTypeName.Text = specimen.PatientTypeName;
            lblDepartmentName.Text = specimen.DepartmentName;
            lblInpatientAreaName.Text = specimen.InpatientAreaName;
            lblBedNo.Text = specimen.BedNo;
            lblDoctorName.Text = specimen.DoctorName;
            lblSpecimenTypeName.Text = specimen.SpecimenTypeName;
            lblApplyAccount.Text = specimen.ApplicantName;
            lblApplyTime.Text = specimen.ApplyDate?.ToString(ToolConstant.DateTimeFormatt);
            lblCollectAccount.Text = specimen.CollectAccount;
            lblCollectTime.Text = specimen.CollectDate?.ToString(ToolConstant.DateTimeFormatt);
            lblChargeTypeName.Text = specimen.ChargeTypeName;
            lblDiagnosis.Text = specimen.Diagnosis;
            lblRemark.Text = specimen.Remark;
            //Patient
            lblPatientCode.Text = specimen.Patient.Code;
            lblPatientName.Text = specimen.Patient.Name;
            lblMedicalRecordNo.Text = specimen.Patient.MedicalRecordNo;
            lblPatientAge.Text = specimen.Patient.Age;
            lblAgeUnit.Text = specimen.Patient.AgeUnit;
            lblPatientSex.Text = specimen.Patient.Sex;
            lblIdentityCard.Text = specimen.Patient.IdCard;
            lblPhoneNo.Text = specimen.Patient.Phone;
            lblAddress.Text = specimen.Patient.Address;

            var n = 0;
            foreach (var specimenInspectionItemIntegrtionDto in specimen.SpecimenInspectionItems)
            {
                var uc = new UcSpecimenInspetionItem(specimenInspectionItemIntegrtionDto)
                {
                    Location = new Point(0, 76 * n)
                };
                pnlInspectionItems.Controls.Add(uc);
                n++;
            }

        }
    }
}
