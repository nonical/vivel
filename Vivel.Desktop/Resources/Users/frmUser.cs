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
using Vivel.Model.Extensions;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.User;

namespace Vivel.Desktop.Resources.Users
{
    public partial class frmUser : Form
    {
        private readonly IdentityAPIService _identity_service;
        private readonly APIService _core_service;
        private int _currentPage;

        public frmUser(string accessToken)
        {
            InitializeComponent();
            _identity_service = new IdentityAPIService("User", accessToken);
            _core_service = new APIService("User", accessToken);
        }

        async void GetUsers(int pageNumber = 1)
        {
            _currentPage = pageNumber;

            var request = new UserSearchRequest { UserName = txtUserUsernameSearch.Text, Page = pageNumber };

            var response = await _core_service.Get<PagedResult<UserDTO>>(request);

            dgvUsers.DataSource = response.Results;

            lblUserPrevious.Enabled = _currentPage != 1;
            lblUserNext.Enabled = response.CurrentPage < response.PageCount;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            GetUsers();
            btnSearchUser.Enabled = true;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = dgvUsers.SelectedRows[0].DataBoundItem as UserDTO;

            txtUserID.Text = user.UserId;
            txtUserUsername.Text = user.UserName;
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            GetUsers();
        }

        private void lblUserNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetUsers(_currentPage + 1);
        }

        private void lblUserPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetUsers(_currentPage - 1);
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
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                if (string.IsNullOrWhiteSpace(txtUserID.Text))
                {

                    var request = new
                    {
                        UserName = txtUserUsername.Text,
                        Password = txtUserPassword.Text,
                        Role = "user"
                    };

                    Tuple<int, dynamic> response = await _identity_service.Insert(request);

                    if (response.Item1 != 200)
                        MessageBox.Show($"Validation failed! Duplicate username or weak password!\n {response.Item2}");

                    GetUsers();
                    clearForm();
                }
                else
                {
                    var request = new UserUpdateRequest
                    {
                        UserName = txtUserUsername.Text
                    };

                    if (!string.IsNullOrWhiteSpace(txtUserPassword.Text))
                        request.Password = txtUserPassword.Text;

                    var id = txtUserID.Text;
                    Tuple<int, dynamic> response = await _identity_service.Update(id, request);

                    if (response.Item1 != 200)
                        MessageBox.Show($"Validation failed! Duplicate username or weak password!\n {response.Item2}");

                    GetUsers();
                    clearForm();
                }
            }
        }

        private bool validateForm()
        {
            return FormValidator.validateTextField(errorProvider1, txtUserUsername, "Required field");
        }
    }
}
