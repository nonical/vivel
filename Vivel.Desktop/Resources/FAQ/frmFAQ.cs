using System.Collections.Generic;
using System.Windows.Forms;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Faq;

namespace Vivel.Desktop.Resources.FAQ
{
    public partial class frmFAQ : Form
    {
        private readonly APIService _apiService;

        private int _currentPage;

        public frmFAQ(string accessToken)
        {
            InitializeComponent();
            _apiService = new APIService("Faq", accessToken);
            getFAQs();
        }

        async void getFAQs(int pageNumber = 1)
        {
            _currentPage = pageNumber;

            var request = new FaqSearchRequest() { Answered = cbFAQAnswered.Checked, Page = pageNumber };

            var response = await _apiService.Get<PagedResult<FaqDTO>>(request);

            lblFAQPrevious.Enabled = _currentPage != 1;
            lblFAQNext.Enabled = response.CurrentPage < response.PageCount;

            dgvFAQs.DataSource = response.Results;
        }

        async void updateFAQ(string faqId, FaqUpdateRequest updateBody)
        {
            await _apiService.Update<FaqDTO>(faqId, updateBody);
        }

        private void dgvFAQs_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected)
            {
                var faq = (dgvFAQs.DataSource as List<FaqDTO>)[e.Row.Index];

                txtQuestionId.Text = faq.Faqid;
                txtQuestion.Text = faq.Question;
                txtAnswer.Text = faq.Answer;
            }
            else
            {
                txtQuestionId.Text = null;
                txtQuestion.Text = null;
                txtAnswer.Text = null;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            updateFAQ(txtQuestionId.Text, new FaqUpdateRequest()
            {
                Answer = txtAnswer.Text,
                Answered = !string.IsNullOrWhiteSpace(txtAnswer.Text),
                Question = txtQuestion.Text
            });
            getFAQs();

            txtQuestionId.Text = "";
            txtQuestion.Text = "";
            txtAnswer.Text = "";
        }

        private void btnFAQSearch_Click(object sender, System.EventArgs e)
        {
            getFAQs();
        }

        private void lblFAQNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getFAQs(_currentPage + 1);
        }

        private void lblFAQPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getFAQs(_currentPage - 1);
        }
    }
}
