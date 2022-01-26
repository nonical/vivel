using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Extensions;
using Vivel.Model.Requests.Drive;

namespace Vivel.Desktop.Resources.Drive
{
    public partial class frmDrive : Form
    {
        APIService _driveService = new APIService("Drive");
        APIService _hospitalService = new APIService("Hospital");
        public frmDrive()
        {
            InitializeComponent();
        }

        private async void frmDrive_Load(object sender, EventArgs e)
        {
            dgvDrive.DataSource = await _driveService.Get<List<DriveDTO>>(null);

            cmbHospitalSelect.DataSource = await _hospitalService.Get<List<HospitalDTO>>(null);
            cmbHospitalSelect.DisplayMember = "Name";
            cmbHospitalSelect.ValueMember = "HospitalId";
        }

        private async void btnSearchDrive_Click(object sender, EventArgs e)
        {
            var hospitalId = cmbHospitalSelect.SelectedValue.ToString();

            dgvDrive.DataSource = await _hospitalService.GetByID<List<DriveDTO>>(hospitalId + "/drives");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            StatusSearch("Open");
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            StatusSearch("Closed");
        }

        private async void StatusSearch(string status)
        {
            var hospitalId = cmbHospitalSelect.SelectedValue.ToString();

            var request = new DriveSearchRequest
            {
                Status = new List<string> { status }
            };

            var queryString = await request?.ToQueryString();
            dgvDrive.DataSource = await _hospitalService.GetByID<List<DriveDTO>>(hospitalId + $"/drives?{queryString}");
        }
    }
}
