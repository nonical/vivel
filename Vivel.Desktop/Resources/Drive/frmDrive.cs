using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Extensions;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Drive;

namespace Vivel.Desktop.Resources.Drive
{
    public partial class frmDrive : Form
    {
        private readonly APIService _service;
        private int _currentPage;

        public frmDrive(string accessToken)
        {
            InitializeComponent();
            _service = new APIService("Hospital", accessToken);
        }

        private async void GetDrives(int pageNumber = 1)
        {
            _currentPage = pageNumber;

            var hospitalId = cmbHospitalSelect.SelectedValue.ToString();

            var statuses = new List<string>();

            if (cbDriveOpen.Checked) statuses.Add("Open");
            if (cbDriveClosed.Checked) statuses.Add("Closed");

            var queryString = await new DriveSearchRequest { Status = statuses, Page = pageNumber }.ToQueryString();

            var response = await _service.GetByID<PagedResult<DriveDTO>>(hospitalId + $"/drives?{queryString}");

            dgvDrive.DataSource = response.Results;

            lblDrivePrevious.Enabled = _currentPage != 1;
            lblDriveNext.Enabled = response.CurrentPage < response.PageCount;
        }

        private async void frmDrive_Load(object sender, EventArgs e)
        {
            var response = await _service.Get<PagedResult<HospitalDTO>>(null);

            cmbHospitalSelect.DataSource = response.Results;
            cmbHospitalSelect.DisplayMember = "Name";
            cmbHospitalSelect.ValueMember = "HospitalId";
            cmbHospitalSelect.SelectedIndex = 0;

            GetDrives();

            btnSearchDrive.Enabled = true;
        }

        private void btnSearchDrive_Click(object sender, EventArgs e)
        {
            GetDrives();
        }

        private void lblDriveNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetDrives(_currentPage + 1);
        }

        private void lblDrivePrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetDrives(_currentPage - 1);
        }
    }
}
