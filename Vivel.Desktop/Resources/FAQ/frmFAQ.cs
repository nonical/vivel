using System.Collections.Generic;
using System.Windows.Forms;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;

namespace Vivel.Desktop.Resources.FAQ
{
    public partial class frmFAQ : Form
    {
        private readonly APIService _apiService = new APIService("Faq");

        public frmFAQ()
        {
            InitializeComponent();
            getFAQs();
        }

        async void getFAQs(bool? answered = null)
        {
            var searchReq = answered != null ? new FaqSearchRequest() { Answered = answered } : null;
            var faqs = await _apiService.Get<List<FaqDTO>>(searchReq);

            dgvFAQs.DataSource = faqs;
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
        }

        private void btnAnswered_Click(object sender, System.EventArgs e)
        {
            getFAQs(true);
        }

        private void btnUnanswered_Click(object sender, System.EventArgs e)
        {
            getFAQs(false);
        }
    }
}
