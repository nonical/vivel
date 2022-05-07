using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vivel.Desktop.Helpers;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.User;

namespace Vivel.Desktop.Resources.Staff
{
    public partial class frmStaff : Form
    {
        private readonly IdentityAPIService _identity_service;
        private readonly APIService _core_service;
        private IList<HospitalDTO> hospitals;

        public frmStaff(string accessToken)
        {
            InitializeComponent();

            _identity_service = new IdentityAPIService("User", accessToken);
            _core_service = new APIService("Hospital", accessToken);
        }

        async void GetUsers()
        {
            var response = await _identity_service.Get<IList<StaffUserDTO>>();

            foreach (var item in response.Item2 as IList<StaffUserDTO>)
            {
                item.Hospital = hospitals.FirstOrDefault(x => x.HospitalId == item.HospitalId).Name;
            }

            dgvUsers.DataSource = response.Item2;
        }
        private async void frmStaff_Load(object sender, EventArgs e)
        {
            var response = await _core_service.Get<PagedResult<HospitalDTO>>(null);
            hospitals = response.Results;

            cmbUserHospital.DataSource = hospitals;
            cmbUserHospital.DisplayMember = "Name";
            cmbUserHospital.ValueMember = "HospitalId";
            cmbUserHospital.SelectedIndex = 0;

            GetUsers();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = dgvUsers.SelectedRows[0].DataBoundItem as StaffUserDTO;

            txtUserID.Text = user.UserId;
            txtUserUsername.Text = user.UserName;
            cmbUserHospital.SelectedValue = user.HospitalId;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                var claims = new Dictionary<string, string>();
                claims.Add("hospital", cmbUserHospital.SelectedValue.ToString());

                if (string.IsNullOrWhiteSpace(txtUserID.Text))
                {

                    var request = new
                    {
                        UserName = txtUserUsername.Text,
                        Password = txtUserPassword.Text,
                        Role = "staff",
                        Claims = claims
                    };

                    Tuple<int, dynamic> response = await _identity_service.Insert(request);

                    if (response.Item1 != 200)
                        MessageBox.Show($"Validation failed! Duplicate username or weak password!\n {response.Item2}");
                }
                else
                {
                    var request = new AdminStaffUpdateRequest
                    {
                        UserName = txtUserUsername.Text,
                        Claims = claims
                    };

                    if (!string.IsNullOrWhiteSpace(txtUserPassword.Text))
                        request.Password = txtUserPassword.Text;

                    var id = txtUserID.Text;
                    Tuple<int, dynamic> response = await _identity_service.Update(id, request);

                    if (response.Item1 != 200)
                        MessageBox.Show($"Validation failed! Duplicate username or weak password!\n {response.Item2}");
                }

                GetUsers();
                clearForm();
            }
        }

        private async void labelDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
                return;

            Tuple<int, dynamic> response = await _identity_service.Delete(txtUserID.Text);

            if (response.Item1 != 200)
                MessageBox.Show($"{response.Item2}");

            GetUsers();
            clearForm();
        }

        private void lblUserClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            txtUserID.Text = "";
            txtUserUsername.Text = "";
            txtUserPassword.Text = "";
            cmbUserHospital.SelectedIndex = 0;
        }

        private bool validateForm()
        {
            return FormValidator.validateTextField(errorProvider1, txtUserUsername, "Required field");
        }

    }
}
