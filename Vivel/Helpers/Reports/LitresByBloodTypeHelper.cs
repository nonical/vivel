using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Model.Requests.Hospital.Reports;

namespace Vivel.Helpers.Reports
{
    public class LitresByBloodTypeHelper
    {
        public string HospitalName { get; set; }
        public string Description { get; set; }
        public List<LitresByBloodTypeDTO> Stats { get; set; }

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
                        <th>BloodType</th>
                        <th>Amount</th>
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

            foreach (var stat in Stats)
            {
                html += $@"
                <tr>
                    <td>{stat.BloodType}</td>
                    <td>{Math.Round(stat.Amount, 2)}</td>
                </tr>";
            }

            return html;
        }
    }
}
