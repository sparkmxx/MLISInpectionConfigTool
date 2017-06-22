using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedNoble.Inspection.Integration;
using RedNoble.Inspection.Integration.Specimen.Entity;

namespace MLISIntegrationTestTool
{
    public partial class UcSpecimenInspetionItem : UserControl
    {


        public UcSpecimenInspetionItem()
        {
            InitializeComponent();
        }

        public UcSpecimenInspetionItem(SpecimenInspectionItemIntegrtionDto dto):this()
        {
            if (dto==null)
            {
                throw new ArgumentNullException();
            }
            lblInspectionItemName.Text = dto.Name;
            lblSignedTime.Text = dto.SignDate?.ToString(ToolConstant.DateTimeFormatt);
            lblChargeItemId.Text = dto.ChargeItemId;
            lblChargeItemCode.Text = dto.ChargeItemCode;
            lblChargeItemName.Text = dto.ChargeItemName;
            lblChargeItemNumber.Text = dto.ChargeNumber.ToString();
            lblChargeAccount.Text = dto.ChargeAccount;
            lblChargeItemTime.Text = dto.ChargeDate?.ToString(ToolConstant.DateTimeFormatt);

        }
    }
}
