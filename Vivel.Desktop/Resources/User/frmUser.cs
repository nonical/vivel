using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Requests.User;

namespace Vivel.Desktop.Resources.User
{
    public partial class frmUser : Form
    {
        private readonly APIService _apiService = new APIService("User");

        public frmUser()
        {
            InitializeComponent();
            getUsers();
        }

        private async void getUsers()
        {
            dgvUsers.DataSource = await _apiService.Get<List<UserDTO>>(new UserSearchRequest() { UserName = txtSearch.Text.Trim() });
            txtSearch.Text = "";
        }

        private async void getDonations(string userId)
        {
            dgvUserDonations.DataSource = await _apiService.GetByID<object>(userId + "/donations");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getUsers();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getUsers();
            }
        }

        private void dgvUsers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected)
            {
                var user = (dgvUsers.DataSource as List<UserDTO>)[e.Row.Index];

                lbUserDonations.Text = user.UserName + "'s Donations";
                getDonations(user.UserId);
            }
        }
    }
}
