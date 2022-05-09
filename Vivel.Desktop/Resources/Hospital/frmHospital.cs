using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vivel;
using Vivel.Desktop.Helpers;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Hospital;

namespace Vivel.Desktop.Hospital
{
    public partial class frmHospital : Form
    {
        private readonly APIService _service;

        private int _currentPage;

        public frmHospital(string accessToken)
        {
            InitializeComponent();
            _service = new APIService("Hospital", accessToken);
        }

        private async void GetHospitals(int pageNumber = 1)
        {
            _currentPage = pageNumber;

            var request = new HospitalSearchRequest { Name = txtHospitalNameSearch.Text, Page = pageNumber };

            var response = await _service.Get<PagedResult<HospitalDTO>>(request);

            dgvHospital.DataSource = response.Results;

            lblHospitalPrevious.Enabled = _currentPage != 1;
            lblHospitalNext.Enabled = response.CurrentPage < response.PageCount;
        }

        private void btnSearchHospital_Click(object sender, EventArgs e)
        {
            GetHospitals();
        }

        private void frmHospital_Load(object sender, EventArgs e)
        {
            GetHospitals();
        }

        private void dgvHospital_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var hospital = dgvHospital.SelectedRows[0].DataBoundItem as HospitalDTO;

            txtHospitalIdUpsert.Text = hospital.HospitalId;
            txtHospitalNameUpsert.Text = hospital.Name;
            txtHospitalLatitudeUpsert.Text = hospital.Latitude.ToString();
            txtHospitalLongitudeUpsert.Text = hospital.Longitude.ToString();
        }

        private void lblHospitalClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearForm();
        }

        private async void btnHospitalSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                var request = new HospitalUpsertRequest
                {
                    Name = txtHospitalNameUpsert.Text,
                    Latitude = decimal.Parse(txtHospitalLatitudeUpsert.Text.Replace(",", ".")),
                    Longitude = decimal.Parse(txtHospitalLongitudeUpsert.Text.Replace(",", ".")),
                };

                if (string.IsNullOrWhiteSpace(txtHospitalIdUpsert.Text))
                {
                    await _service.Insert<HospitalDTO>(request);
                }
                else
                {
                    var id = txtHospitalIdUpsert.Text;
                    await _service.Update<HospitalDTO>(id, request);
                }
                GetHospitals();
                clearForm();
            }

        }

        private void lblHospitalNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetHospitals(_currentPage + 1);
        }

        private void lblHospitalPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetHospitals(_currentPage - 1);
        }

        private void clearForm()
        {
            txtHospitalIdUpsert.Text = "";
            txtHospitalNameUpsert.Text = "";
            txtHospitalLatitudeUpsert.Text = "";
            txtHospitalLongitudeUpsert.Text = "";
        }

        private bool validateForm()
        {
            return FormValidator.validateTextField(errorProvider1, txtHospitalNameUpsert, "Required field") &&
            FormValidator.validateTextField(errorProvider1, txtHospitalLatitudeUpsert, "Required field") &&
            FormValidator.validateTextField(errorProvider1, txtHospitalLongitudeUpsert, "Required field") &&
            FormValidator.validateGeolocation(errorProvider1, txtHospitalLatitudeUpsert, txtHospitalLongitudeUpsert);
        }
    }
}
