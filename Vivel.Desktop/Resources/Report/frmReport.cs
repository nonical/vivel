using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vivel.Desktop.Services;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Hospital.Reports;

namespace Vivel.Desktop.Resources.Report
{
    public partial class frmReport : Form
    {
        private readonly APIService _service;
        public frmReport(string accessToken)
        {
            InitializeComponent();
            _service = new APIService("Hospital", accessToken);
        }

        private class Report
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        private async void frmReport_Load(object sender, EventArgs e)
        {
            cmbReports.DataSource = new List<Report>
            {
                new Report { Name = "Drive Report", Url = "drives" } ,
                new Report{ Name="Litres by blood type", Url = "litresbybloodtype" }
            };
            cmbReports.DisplayMember = "Name";
            cmbReports.ValueMember = "Url";
            cmbReports.SelectedIndex = 0;

            var hospitals = await _service.Get<PagedResult<HospitalDTO>>(null);

            cmbHospitals.DataSource = hospitals.Results;
            cmbHospitals.DisplayMember = "Name";
            cmbHospitals.ValueMember = "HospitalId";
            cmbHospitals.SelectedIndex = 0;

            cmbStatus.DataSource = new List<string>
            {
                "All",
                "Open",
                "Closed"
            };

            cmbUrgency.DataSource = new List<string>
            {
                "All",
                "Urgent",
                "Routine"
            };

        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            var hospitalId = cmbHospitals.SelectedValue as string;
            var reportUrl = cmbReports.SelectedValue as string;
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;
            var status = cmbStatus.SelectedValue as string;
            var urgency = cmbUrgency.SelectedValue as string;


            if (reportUrl == "drives")
            {
                var request = new HospitalReportDrivesRequest { From = from, To = to };

                if (status != "All")
                    request.Status = status;

                if (urgency != "All")
                    request.Urgency = urgency == "Urgent";

                await DownloadFile(request, hospitalId, reportUrl);
            }

            if (reportUrl == "litresbybloodtype")
            {
                var request = new HospitalReportLitresRequest { From = from, To = to };

                if (urgency != "All")
                    request.Urgency = urgency == "Urgent";

                await DownloadFile(request, hospitalId, reportUrl);
            }

            MessageBox.Show("Check your c:\\downloads folder");
        }

        private async Task DownloadFile(object request, string hospitalId, string reportUrl)
        {
            var path = $"{hospitalId}/report/{reportUrl}";
            var fileName = $"{reportUrl}_report_{DateTime.Now:MMM-dd-yyyy-HH-mm-ss}.pdf";

            await _service.DownloadFile(path, request, fileName);
        }
    }
}
