using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;

namespace Vivel.Helpers.Reports
{
    public class DrivesReportHelper
    {
        public string HospitalName { get; set; }
        public string Description { get; set; }
        public List<Drive> drives { get; set; }


        public string GetHtml()
        {
            var html = "";

            html += $@"<!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8' />
                <title></title>
            </head>

            <style>
                h1, h3 {{
                    text-align: center;
                }}

                main{{
                    margin: 50px;
                }}

                table {{
                    font-family: arial, sans-serif;
                    border-collapse: collapse;
                    width: 100%;
                }}

                td, th {{
                    border: 1px solid #dddddd;
                    text-align: left;
                    padding: 8px;
                }}

                tr:nth-child(even) {{
                    background - color: #dddddd;
                }}
            </style>
            <body>
                <h1>{HospitalName}</h1>
                <h3>{Description}</h3>
            <main>
                <table>
                    <tr>
                        <th>Date</th>
                        <th>BloodType</th>
                        <th>Amount</th>
                        <th>Status</th>
                        <th>Urgency</th>
                        <th>Donation count</th>
                    </tr>
            { GetTableBody()}
            </table>
            </main>
            </body>
            </html>";

            return html;
        }

        private string GetTableBody()
        {
            var html = "";

            foreach (var drive in drives)
            {
                html += $@"
                <tr>
                    <td>{drive.Date.Value:MMM dd yyyy}</td>
                    <td>{drive.BloodType.Name}</td>
                    <td>{drive.Amount} ml</td>
                    <td>{drive.Status.Name}</td>
                    <td>{(drive.Urgency ? "Urgent" : "Routine")}</td>
                    <td>{drive.Donations.Count()}</td>
                </tr>";
            }

            return html;
        }
    }
}
