using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vivel.Desktop.Helpers;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.PresetBadge;

namespace Vivel.Desktop.Resources.PresetBadge
{
    public partial class frmPresetBadge : Form
    {
        private readonly APIService _service;

        public frmPresetBadge(string accessToken)
        {
            InitializeComponent();
            _service = new APIService("PresetBadge", accessToken);
        }

        private async void GetPresetBadges()
        {
            var request = new PresetBadgeSearchRequest { Name = txtPresetBadgeNameSearch.Text };

            var response = await _service.Get<PagedResult<PresetBadgeDTO>>(request);

            dgvPresetBadge.DataSource = response.Results;
        }

        private async void btnPresetBadgeSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                var request = new PresetBadgeUpsertRequest
                {
                    Name = txtPresetBadgeNameUpsert.Text,
                    Description = txtPresetBadgeDescriptionUpsert.Text,
                    Picture = ConvertImageToBase64(pbPresetBadgeImage.Image)
                };

                if (string.IsNullOrWhiteSpace(txtPresetBadgeIdUpsert.Text))
                {
                    await _service.Insert<PresetBadgeDTO>(request);
                }
                else
                {
                    var id = txtPresetBadgeIdUpsert.Text;
                    await _service.Update<PresetBadgeDTO>(id, request);
                }
                GetPresetBadges();
                clearForm();
            }
        }

        private void lblPresetBadgeClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearForm();
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
            pbPresetBadgeImage.Image = LoadImageFromBase64(badge.Picture);
        }

        private void pbPresetBadgeImage_Click(object sender, EventArgs e)
        {
            ofdPresetBadgeImage.FileName = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (ofdPresetBadgeImage.ShowDialog() == DialogResult.OK)
            {
                pbPresetBadgeImage.Image = new Bitmap(ofdPresetBadgeImage.FileName);
            }
        }
        public static Image LoadImageFromBase64(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        public string ConvertImageToBase64(Image file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, file.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        private void clearForm()
        {
            txtPresetBadgeIdUpsert.Text = "";
            txtPresetBadgeNameUpsert.Text = "";
            txtPresetBadgeDescriptionUpsert.Text = "";
            pbPresetBadgeImage.Image = null;
        }

        private bool validateForm()
        {
            return FormValidator.validateTextField(errorProvider1, txtPresetBadgeNameUpsert, "Required field") &&
                FormValidator.validateTextField(errorProvider1, txtPresetBadgeDescriptionUpsert, "Required field");
        }

        private async void labelDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPresetBadgeIdUpsert.Text))
                return;

            await _service.Delete<PresetBadgeDTO>(txtPresetBadgeIdUpsert.Text);

            GetPresetBadges();
            clearForm();
        }
    }
}
