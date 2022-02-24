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
using Vivel.Model.Pagination;
using Vivel.Model.Requests.PresetBadge;

namespace Vivel.Desktop.Resources.PresetBadge
{
    public partial class frmPresetBadge : Form
    {
        private readonly APIService _service = new APIService("PresetBadge");

        public frmPresetBadge()
        {
            InitializeComponent();
        }

        private async void GetPresetBadges()
        {
            var request = new PresetBadgeSearchRequest { Name = txtPresetBadgeNameSearch.Text };

            var response = await _service.Get<PagedResult<PresetBadgeDTO>>(request);

            dgvPresetBadge.DataSource = response.Results;
        }

        private async void btnPresetBadgeSave_Click(object sender, EventArgs e)
        {
            var request = new PresetBadgeUpsertRequest
            {
                Name = txtPresetBadgeNameUpsert.Text,
                Description = txtPresetBadgeDescriptionUpsert.Text,
                Picture = txtPresetBadgeImageUpsert.Text,
            };

            if (string.IsNullOrWhiteSpace(txtPresetBadgeIdUpsert.Text))
            {
                await _service.Insert<PresetBadgeDTO>(request);
                GetPresetBadges();
            }
            else
            {
                var id = txtPresetBadgeIdUpsert.Text;
                await _service.Update<PresetBadgeDTO>(id, request);
                GetPresetBadges();

                txtPresetBadgeIdUpsert.Text = "";
                txtPresetBadgeNameUpsert.Text = "";
                txtPresetBadgeDescriptionUpsert.Text = "";
                txtPresetBadgeImageUpsert.Text = "";
            }
        }

        private void lblPresetBadgeClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPresetBadgeIdUpsert.Text = "";
            txtPresetBadgeNameUpsert.Text = "";
            txtPresetBadgeDescriptionUpsert.Text = "";
            txtPresetBadgeImageUpsert.Text = "";

        }

        private void btnSearchPresetBadge_Click(object sender, EventArgs e)
        {
            GetPresetBadges();
        }

        private void frmPresetBadge_Load(object sender, EventArgs e)
        {
            GetPresetBadges();
        }

        private void dgvPresetBadge_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var badge = dgvPresetBadge.SelectedRows[0].DataBoundItem as PresetBadgeDTO;

            txtPresetBadgeIdUpsert.Text = badge.PresetBadgeId;
            txtPresetBadgeNameUpsert.Text = badge.Name;
            txtPresetBadgeDescriptionUpsert.Text = badge.Description;
            txtPresetBadgeImageUpsert.Text = badge.Picture;
        }
    }
}
