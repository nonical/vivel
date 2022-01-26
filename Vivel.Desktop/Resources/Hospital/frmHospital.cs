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
using Vivel.Model.Requests.Hospital;

namespace Vivel.Desktop.Hospital
{
    public partial class frmHospital : Form
    {
        APIService _service = new APIService("Hospital");
        public frmHospital()
        {
            InitializeComponent();
        }

        private async void btnSearchHospital_Click(object sender, EventArgs e)
        {
            var request = new HospitalSearchRequest
            {
                Name = txtHospitalNameSearch.Text
            };

            dgvHospital.DataSource = await _service.Get<List<HospitalDTO>>(request);
        }

        private async void frmHospital_Load(object sender, EventArgs e)
        {
            dgvHospital.DataSource = await _service.Get<List<HospitalDTO>>(null);
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
            txtHospitalIdUpsert.Text = "";
            txtHospitalNameUpsert.Text = "";
            txtHospitalLatitudeUpsert.Text = "";
            txtHospitalLongitudeUpsert.Text = "";
        }

        private async void btnHospitalSave_Click(object sender, EventArgs e)
        {
            var request = new HospitalUpsertRequest
            {
                Name = txtHospitalNameUpsert.Text,
                Latitude = decimal.Parse(txtHospitalLatitudeUpsert.Text),
                Longitude = decimal.Parse(txtHospitalLongitudeUpsert.Text),
            };

            if (string.IsNullOrWhiteSpace(txtHospitalIdUpsert.Text))
            {
                await _service.Insert<HospitalDTO>(request);
                dgvHospital.DataSource = await _service.Get<List<HospitalDTO>>(null);
            }
            else
            {
                var id = txtHospitalIdUpsert.Text;
                await _service.Update<HospitalDTO>(id, request);
                dgvHospital.DataSource = await _service.Get<List<HospitalDTO>>(null);

                txtHospitalIdUpsert.Text = "";
                txtHospitalNameUpsert.Text = "";
                txtHospitalLatitudeUpsert.Text = "";
                txtHospitalLongitudeUpsert.Text = "";
            }
        }
    }
}
