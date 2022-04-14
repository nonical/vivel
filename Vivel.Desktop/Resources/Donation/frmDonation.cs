using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Extensions;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.User;

namespace Vivel.Desktop.Resources.User
{
    public partial class frmDonation : Form
    {
        private readonly APIService _apiService;

        private int _currentUserPage;

        private int _currentDonationPage;

        public frmDonation(string accessToken)
        {
            InitializeComponent();
            _apiService = new APIService("User", accessToken);
            getUsers();
        }

        private async void getUsers(int pageNumber = 1)
        {
            _currentUserPage = pageNumber;

            var response = await _apiService.Get<PagedResult<UserDTO>>(new UserSearchRequest() { UserName = txtSearch.Text.Trim(), Page = pageNumber });

            dgvUsers.DataSource = response.Results;
            txtSearch.Text = "";

            lblUserPrevious.Enabled = _currentUserPage != 1;
            lblUserNext.Enabled = response.CurrentPage < response.PageCount;
        }

        private async void getDonations(string userId, int pageNumber = 1)
        {
            _currentDonationPage = pageNumber;

            var queryString = await new DonationSearchRequest() { Page = pageNumber }.ToQueryString();

            var response = await _apiService.GetByID<PagedResult<DonationDTO>>(userId + $"/donations?{queryString}");

            dgvUserDonations.DataSource = response.Results;

            lblDonationPrevious.Enabled = _currentDonationPage != 1;
            lblDonationNext.Enabled = response.CurrentPage < response.PageCount;
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

        private void lblUserNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getUsers(_currentUserPage + 1);
        }

        private void lblUserPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getUsers(_currentUserPage - 1);
        }

        private void lblDonationNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var user = dgvUsers.SelectedRows[0].DataBoundItem as UserDTO;
            getDonations(user.UserId, _currentDonationPage + 1);
        }

        private void lblDonationPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var user = dgvUsers.SelectedRows[0].DataBoundItem as UserDTO;
            getDonations(user.UserId, _currentDonationPage - 1);
        }
    }
}
