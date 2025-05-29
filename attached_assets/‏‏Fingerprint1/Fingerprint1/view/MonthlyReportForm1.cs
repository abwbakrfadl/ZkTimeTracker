using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Drawing.Printing;

namespace Fingerprint1.view
{
    public partial class MonthlyReportForm1 : Form
    {

        private List<string> employeeIds = new List<string>();
        private int currentEmployeeIndex = -1;





        public MonthlyReportForm1()
        {
            InitializeComponent();
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            LoadEmployees();
            LoadEmployeeComboBox();
            dataveiw();
        }

        private void dataveiw()
        {

            dgvReport.DataBindingComplete += (sender, e) =>
            {
                // SELECT ShiftID, ShiftName, StartTime, EndTime, CheckInGracePeriod, CheckOutGracePeriod, CheckInStart, CheckInEnd
                // إخفاء العمود DiscountID
                if (dgvReport.Columns.Contains("ShiftID"))
                    dgvReport.Columns["ShiftID"].Visible = false;

                // تغيير عناوين الأعمدة
                if (dgvReport.Columns.Contains("ShiftName"))
                    dgvReport.Columns["ShiftName"].HeaderText = "اسم الفترة";

                if (dgvReport.Columns.Contains("StartTime"))
                    dgvReport.Columns["StartTime"].HeaderText = " وقت بدء العمل ";

                if (dgvReport.Columns.Contains("EndTime"))
                    dgvReport.Columns["EndTime"].HeaderText = "وقت انتهاء العمل ";
                if (dgvReport.Columns.Contains("CheckInGracePeriod"))
                    dgvReport.Columns["CheckInGracePeriod"].HeaderText = "سماحية الحضور ";
                if (dgvReport.Columns.Contains("CheckOutGracePeriod"))
                    dgvReport.Columns["CheckOutGracePeriod"].HeaderText = " سماحية الانصراف";
                if (dgvReport.Columns.Contains("CheckInStart"))
                    dgvReport.Columns["CheckInStart"].HeaderText = "بداية فترة الحضور ";
                if (dgvReport.Columns.Contains("CheckInEnd"))
                    dgvReport.Columns["CheckInEnd"].HeaderText = "نهاية فترة الانصراف ";

            };
            dgvReport.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvReport.Font = new Font("Arial", 9);
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // dgvReport.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 110);
            dgvReport.ReadOnly = true;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Dock = DockStyle.Bottom;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.RightToLeft = RightToLeft.Yes;

            // ... existing code ...

            // DataGridView settings
            // ... existing code ...



            // ... rest of the code ...

            // ... rest of the code ...

            //// تنسيق رأس الجدول
            dgvReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReport.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvReport.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvReport.ColumnHeadersHeight = 40;

            //// تنسيق الصفوف
            dgvReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 65, 89);
            dgvReport.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvReport.DefaultCellStyle.Padding = new Padding(5);
            dgvReport.RowTemplate.Height = 35;

            dgvReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);

        }



        private void ShowDisciplinedReport()
        {
            try
            {
                string html = @"
        <!DOCTYPE html>
        <html dir='rtl'>
        <head>
            <meta charset='utf-8'>
            <style>
                body { font-family: Arial; margin: 20px; }
                .report { border: 2px solid #000; padding: 20px; }
                .header { text-align: center; margin-bottom: 20px; }
                table { width: 100%; border-collapse: collapse; }
                th, td { border: 1px solid #000; padding: 8px; text-align: center; }
                th { background-color: #f0f0f0; }
                tr:nth-child(even) { background-color: #f9f9f9; }
            </style>
        </head>
        <body>
            <div class='report'>
                <div class='header'>
                    <h2>تقرير الموظفين المتضبطين</h2>
                    <p>الفترة من: " + dtpFromDate.Value.ToString("yyyy/MM/dd") + @" إلى: " + dtpToDate.Value.ToString("yyyy/MM/dd") + @"</p>
                </div>
                <table>
                    <tr>
                        <th>الرقم</th>
                        <th>اسم الموظف</th>
                        <th>عدد أيام الحضور</th>
                        <th>عدد أيام الغياب</th>
                        <th>عدد مرات التأخير</th>
                        <th>عدد مرات الانصراف المبكر</th>
                    </tr>";

                var employeeGroups = dgvReport.Rows.Cast<DataGridViewRow>()
                    .GroupBy(r => new
                    {
                        Id = r.Cells["المعرف"].Value?.ToString(),
                        Name = r.Cells["الاسم"].Value?.ToString()
                    });

                foreach (var emp in employeeGroups)
                {
                    int presentDays = emp.Count(r => r.Cells["الحالة"].Value?.ToString() == "حاضر");
                    int absentDays = emp.Count(r => r.Cells["الحالة"].Value?.ToString() == "غائب");
                    int lateDays = emp.Count(r => r.Cells["الحالة"].Value?.ToString() == "حضور متأخر");
                    int earlyLeave = emp.Count(r => r.Cells["الحالة"].Value?.ToString() == "انصراف مبكر");

                    if (absentDays == 0 && lateDays == 0 && earlyLeave == 0) // Only disciplined employees
                    {
                        html += $@"
                <tr>
                    <td>{emp.Key.Id}</td>
                    <td>{emp.Key.Name}</td>
                    <td>{presentDays}</td>
                    <td>{absentDays}</td>
                    <td>{lateDays}</td>
                    <td>{earlyLeave}</td>
                </tr>";
                    }
                }

                html += @"
                </table>
            </div>
            <button onclick='window.print()' style='margin: 20px;'>طباعة</button>
        </body>
        </html>";

                string tempFile = Path.Combine(Path.GetTempPath(), "disciplined_report1.html");
                File.WriteAllText(tempFile, html, Encoding.UTF8);
                Process.Start(new ProcessStartInfo { FileName = "cmd.exe", Arguments = $"/c start {tempFile}", UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }

        //    private void PrintSalaryReceipt()
        //    {
        //        string html = @"
        //<!DOCTYPE html>
        //<html dir='rtl'>
        //<head>
        //    <meta charset='utf-8'>
        //    <style>
        //        body { font-family: Arial; padding: 20px; }
        //        .receipt { border: 2px solid #000; padding: 20px; max-width: 800px; margin: auto; }
        //        .header { text-align: center; margin-bottom: 30px; }
        //        .receipt-details { margin: 20px 0; }
        //        .row { display: flex; margin: 10px 0; }
        //        .label { font-weight: bold; width: 150px; }
        //        .value { flex: 1; }
        //        .footer { margin-top: 50px; display: flex; justify-content: space-between; }
        //        .signature { width: 200px; text-align: center; }
        //        @media print {
        //            .no-print { display: none; }
        //        }
        //    </style>
        //</head>
        //<body>
        //    <div class='receipt'>
        //        <div class='header'>
        //            <h2>سند صرف راتب</h2>
        //            <p>التاريخ: " + DateTime.Now.ToString("yyyy/MM/dd") + @"</p>
        //        </div>
        //        <div class='receipt-details'>
        //            <div class='row'>
        //                <div class='label'>اسم الموظف:</div>
        //                <div class='value'>" + cmbEmployee.Text + @"</div>
        //            </div>
        //            <div class='row'>
        //                <div class='label'>الراتب الأساسي:</div>
        //                <div class='value'>" + txtSalary.Text + @"</div>
        //            </div>
        //            <div class='row'>
        //                <div class='label'>الفترة من:</div>
        //                <div class='value'>" + dtpFromDate.Value.ToString("yyyy/MM/dd") + @"</div>
        //            </div>
        //            <div class='row'>
        //                <div class='label'>الفترة إلى:</div>
        //                <div class='value'>" + dtpToDate.Value.ToString("yyyy/MM/dd") + @"</div>
        //            </div>
        //            <div class='row'>
        //                <div class='label'>إجمالي الخصومات:</div>
        //                <div class='value'>" + CalculateTotalDeductions() + @"</div>
        //            </div>
        //            <div class='row'>
        //                <div class='label'>صافي الراتب:</div>
        //                <div class='value'>" + CalculateNetSalary() + @"</div>
        //            </div>
        //        </div>
        //        <div class='footer'>
        //            <div class='signature'>
        //                <p>توقيع الموظف</p>
        //                <div style='border-bottom: 1px solid #000; height: 40px;'></div>
        //            </div>
        //            <div class='signature'>
        //                <p>توقيع المدير</p>
        //                <div style='border-bottom: 1px solid #000; height: 40px;'></div>
        //            </div>
        //        </div>
        //    </div>
        //    <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
        //</body>
        //</html>";

        //        string tempFile = Path.Combine(Path.GetTempPath(), "salary_receipt.html");
        //        File.WriteAllText(tempFile, html, Encoding.UTF8);
        //        Process.Start(tempFile);
        //    }




        private void BtnSalaryReceipt_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات للطباعة");
                return;
            }

            try
            {
                var employeeGroups = dgvReport.Rows.Cast<DataGridViewRow>()
                    .GroupBy(row => row.Cells["المعرف"].Value?.ToString());

                string allReceipts = "<!DOCTYPE html><html dir='rtl'><head><meta charset='utf-8'><style>" +
                    "body { font-family: Arial; } " +
                    ".page-break { page-break-after: always; } " +
                    "@media print { .no-print { display: none; } }" +
                    "</style></head><body>";

                foreach (var group in employeeGroups)
                {
                    var employeeRows = group.ToArray();
                    allReceipts += CreateSalaryReceiptHtml(employeeRows) + "<div class='page-break'></div>";
                }

                allReceipts += "</body></html>";

                string tempFile = Path.Combine(Path.GetTempPath(), "salary_receipts.html");
                File.WriteAllText(tempFile, allReceipts, Encoding.UTF8);

                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c start {tempFile}",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }
        public class AttendanceSummary
        {
            public int Present { get; set; }
            public int Absent { get; set; }
            public int LateAttendance { get; set; }
            public int HalfDay { get; set; }
            public int LateNoCheckout { get; set; }
            public int EarlyLeave { get; set; }
            public int Weekend { get; set; }
            public int Vacation { get; set; }
            public int NoCheckIn { get; set; }  // Added this property
            public int LateAndEarlyLeave { get; set; }  // Added this property
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }



        private void btnDisciplinedReport_Click(object sender, EventArgs e)
        {
            //ShowDisciplinedReport();
        }
        private AttendanceSummary CalculateAttendanceSummary()
        {
            var summary = new AttendanceSummary();

            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                string status = row.Cells["الحالة"].Value?.ToString() ?? "";

                switch (status)
                {
                    case "حاضر":
                        summary.Present++;
                        break;
                    case "غائب":
                        summary.Absent++;
                        break;
                    case "غائب-حضور متاخر":
                        summary.LateAttendance++;
                        break;
                    case "نصف يوم":
                        summary.HalfDay++;
                        break;
                    case "حضور متأخر بدون انصراف":
                        summary.LateNoCheckout++;
                        break;
                    case "انصراف مبكر":
                        summary.EarlyLeave++;
                        break;
                    case "اسبوعية":
                        summary.Weekend++;
                        break;
                    case "إجازة":
                        summary.Vacation++;
                        break;
                }
            }

            return summary;
        }

        private string CreateSalaryReceiptHtml(DataGridViewRow[] employeeRows)
        {
            var attendanceSummary = CalculateAttendanceSummary(employeeRows);
            decimal basicSalary = decimal.Parse(employeeRows[0].Cells["الراتب الشهري"].Value?.ToString() ?? "0");
            decimal deductions = CalculateDeductions(employeeRows);
            decimal netSalary = decimal.Parse(employeeRows[employeeRows.Length - 1].Cells["صافي الراتب"].Value?.ToString() ?? "0");
            return @"
<!DOCTYPE html>
<html dir='rtl'>
<head>
    <meta charset='utf-8'>
    <style>
        @page {
            size: A5 landscape;
            margin: 10mm;
        }
        body {
            font-family: Arial;
            width: 210mm;
            height: 148mm;
            margin: 0;
            padding: 10mm;
            box-sizing: border-box;
        }
        .receipt {
            border: 1px solid #000;
            padding: 10px;
            height: 100%;
        }
        .header {
            text-align: center;
            margin-bottom: 10px;
        }
        .header h2 { margin: 5px 0; }
        .info-row {
            margin: 5px 0;
            font-size: 12px;
        }
        .label {
            font-weight: bold;
            width: 100px;
            display: inline-block;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 10px 0;
            font-size: 12px;
        }
        th, td {
            border: 1px solid #000;
            padding: 4px;
            text-align: center;
        }
        .summary-box {
            margin: 10px 0;
            padding: 5px;
            border: 1px solid #ccc;
            font-size: 11px;
        }
        .summary-grid {
            display: grid;
            grid-template-columns: repeat(4, 1fr);
            gap: 5px;
        }
        .signatures {
            margin-top: 10px;
            display: flex;
            justify-content: space-between;
            font-size: 12px;
        }
        .signature {
            text-align: center;
            width: 150px;
        }
        .signature-line {
            border-bottom: 1px solid #000;
            height: 30px;
            margin-top: 10px;
        }
        @media print {
            .no-print { display: none; }
            .page-break { page-break-after: always; }
        }
    </style>
    <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
</head>
<body>
    <div class='receipt'>
        <div class='header'>
         <h2 style='margin: 0;'>سند صرف راتب</h2>
            <p style='margin: 10px 0;'>التاريخ: " + DateTime.Now.ToString("yyyy/MM/dd") + @"</p>
        </div>

        <div class='info-row'>
            <span class='label'>رقم الموظف:</span>
            <span>" + employeeRows[0].Cells["المعرف"].Value + @"</span>
        </div>
        <div class='info-row'>
            <span class='label'>اسم الموظف:</span>
            <span>" + employeeRows[0].Cells["الاسم"].Value + @"</span>
        </div>

        <div class='info-row'>
            <span class='label'>الفترة من:</span>
            <span>" + dtpFromDate.Value.ToString("yyyy/MM/dd") + @"</span>
        </div>
        <div class='info-row'>
            <span class='label'>الفترة إلى:</span>
            <span>" + dtpToDate.Value.ToString("yyyy/MM/dd") + @"</span>
        </div>

        <table>
            <tr>
                <th>الراتب الأساسي</th>
                <th>أيام العمل</th>
                <th>الخصومات</th>
                <th>صافي الراتب</th>
            </tr>
            <tr>
                <td>" + basicSalary.ToString("N2") + @"</td>
                <td>" + attendanceSummary.Present + @"</td>
                <td>" + deductions.ToString("N2") + @"</td>
                <td>" + netSalary.ToString("N2") + @"</td>
            </tr>
        </table>

        <div class='summary-box'>
           <h3 style='margin-top: 0;'>ملخص الحضور والانصراف</h3>
<div class='summary-grid'>
    <div class='summary-item'>حاضر: " + attendanceSummary.Present + @"</div>
    <div class='summary-item'>غائب: " + attendanceSummary.Absent + @"</div>
    <div class='summary-item'>حضور متاخر: " + attendanceSummary.LateAttendance + @"</div>
    <div class='summary-item'>حضور بدون انصراف: " + attendanceSummary.HalfDay + @"</div>
    <div class='summary-item'>حضور متاخر بدون انصراف: " + attendanceSummary.LateNoCheckout + @"</div>
    <div class='summary-item'>انصراف مبكر: " + attendanceSummary.EarlyLeave + @"</div>
    <div class='summary-item'>حضور متاخر وانصراف مبكر: " + attendanceSummary.LateAndEarlyLeave + @"</div>
    <div class='summary-item'>لم يسجل حضور: " + attendanceSummary.NoCheckIn + @"</div>
    <div class='summary-item'>عطلة أسبوعية: " + attendanceSummary.Weekend + @"</div>
    <div class='summary-item'>إجازة: " + attendanceSummary.Vacation + @"</div>
</div>
        </div>

        <div class='signatures'>
            <div class='signature'>
                <p>توقيع الموظف</p>
                <div class='signature-line'></div>
            </div>
            <div class='signature'>
                <p>توقيع المدير</p>
                <div class='signature-line'></div>
            </div>
        </div>
    </div>
</body>
</html>";
        }
        //        private string CreateSalaryReceiptHtml()
        //        {
        //            var attendanceSummary = CalculateAttendanceSummary();
        //            decimal basicSalary = decimal.Parse(dgvReport.Rows[0].Cells["الراتب الشهري"].Value?.ToString() ?? "0");
        //            decimal deductions = CalculateDeductions();
        //            decimal netSalary = decimal.Parse(dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["صافي الراتب"].Value?.ToString() ?? "0");
        //            return @"
        //<!DOCTYPE html>
        //<html dir='rtl'>
        //<head>
        //    <meta charset='utf-8'>
        //    <style>
        //        body { font-family: Arial; margin: 20px; }
        //        .receipt { border: 2px solid #000; padding: 20px; }
        //        .header { text-align: center; }
        //        .info-row { margin: 10px 0; }
        //        .label { font-weight: bold; width: 150px; display: inline-block; }
        //        table { width: 100%; border-collapse: collapse; margin: 20px 0; }
        //        th, td { border: 1px solid #000; padding: 8px; text-align: center; }
        //        .signatures { margin-top: 50px; display: flex; justify-content: space-between; }
        //        .signature { text-align: center; width: 200px; }
        //        @media print { .no-print { display: none; } }
        //    </style>
        //</head>
        //<body>
        //    <div class='receipt'>
        //        <div class='header'>
        //            <h2>سند صرف راتب</h2>
        //            <p>التاريخ: " + DateTime.Now.ToString("yyyy/MM/dd") + @"</p>
        //        </div>

        //        <div class='info-row'>
        //            <span class='label'>رقم الموظف:</span>
        //            <span>" + dgvReport.Rows[0].Cells[0].Value + @"</span>
        //        </div>
        //        <div class='info-row'>
        //            <span class='label'>اسم الموظف:</span>
        //            <span>" + dgvReport.Rows[0].Cells[1].Value + @"</span>
        //        </div>
        //        <div class='info-row'>
        //            <span class='label'>الفترة من:</span>
        //            <span>" + dtpFromDate.Value.ToString("yyyy/MM/dd") + @"</span>
        //        </div>
        //        <div class='info-row'>
        //            <span class='label'>الفترة إلى:</span>
        //            <span>" + dtpToDate.Value.ToString("yyyy/MM/dd") + @"</span>
        //        </div>

        //        <table>

        //            <tr>
        //                <th>الراتب الأساسي</th>
        //                <th>أيام العمل</th>
        //                <th>الخصومات</th>
        //                <th>صافي الراتب</th>
        //            </tr>
        //            <tr>
        //                <td>" + basicSalary.ToString("N2") + @"</td>
        //                <td>" + dgvReport.Rows.Count + @"</td>
        //                <td>" + deductions.ToString("N2") + @"</td>
        //                <td>" + netSalary.ToString("N2") + @"</td>
        //            </tr>
        //        </table>

        //        <div class='signatures'>
        // <div style='margin-top: 20px; padding: 10px; background-color: #f9f9f9; border: 1px solid #ddd;'>
        //            <h3 style='margin-bottom: 10px;'>ملخص الحضور والانصراف:</h3>
        //            <div style='display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px;'>
        //                <div>حاضر: " + attendanceSummary.Present + @"</div>
        //                <div>غائب: " + attendanceSummary.Absent + @"</div>
        //                <div>حضور متأخر: " + attendanceSummary.LateAttendance + @"</div>
        //                <div>نصف يوم: " + attendanceSummary.HalfDay + @"</div>
        //                <div>حضور متأخر بدون انصراف: " + attendanceSummary.LateNoCheckout + @"</div>
        //                <div>انصراف مبكر: " + attendanceSummary.EarlyLeave + @"</div>
        //                <div>عطلة أسبوعية: " + attendanceSummary.Weekend + @"</div>
        //                <div>إجازة: " + attendanceSummary.Vacation + @"</div>
        //            </div>
        //        </div>
        //            <div class='signature'>
        //                <p>توقيع الموظف</p>
        //                <div style='border-bottom: 1px solid #000; height: 40px;'></div>
        //            </div>
        //            <div class='signature'>
        //                <p>توقيع المدير</p>
        //                <div style='border-bottom: 1px solid #000; height: 40px;'></div>
        //            </div>
        //        </div>
        //    </div>
        //    <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
        //</body>
        //</html>";
        //        }
        private AttendanceSummary CalculateAttendanceSummary(DataGridViewRow[] rows)
        {
            var summary = new AttendanceSummary();
            foreach (DataGridViewRow row in rows)
            {
                string status = row.Cells["الحالة"].Value?.ToString() ?? "";
                switch (status)
                {
                    case "حاضر": summary.Present++; break;
                    case "غائب": summary.Absent++; break;
                    case "حضور متاخر": summary.LateAttendance++; break;
                    case "حضور بدون انصراف": summary.HalfDay++; break;
                    case "حضور متاخر بدون انصراف": summary.LateNoCheckout++; break;
                    case "انصراف مبكر": summary.EarlyLeave++; break;
                    case "عطلة أسبوعية": summary.Weekend++; break;
                    case "حضور متاخر وانصراف مبكر": summary.LateAndEarlyLeave++; break;
                    case "لم يسجل حضور": summary.NoCheckIn++; break;
                }
                if (status.Contains("إجازة")) summary.Vacation++;
            }
            return summary;
        }

        private decimal CalculateDeductions(DataGridViewRow[] rows)
        {
            try
            {
                return decimal.Parse(rows[rows.Length - 1].Cells["إجمالي الخصومات"].Value?.ToString() ?? "0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حساب الخصومات: {ex.Message}");
                return 0;
            }
        }

        // في دالة الطباعة
        private void PrintSalaryReceipt()
        {
            var employeeGroups = dgvReport.Rows.Cast<DataGridViewRow>()
                .GroupBy(row => row.Cells["المعرف"].Value?.ToString());

            string allReceipts = "";
            foreach (var group in employeeGroups)
            {
                var employeeRows = group.ToArray();
                allReceipts += CreateSalaryReceiptHtml(employeeRows) + "<div class='page-break'></div>";
            }

            // حفظ وعرض الملف
            string tempFile = Path.Combine(Path.GetTempPath(), "salary_receipts.html");
            File.WriteAllText(tempFile, allReceipts, Encoding.UTF8);
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c start {tempFile}",
                UseShellExecute = true,
                CreateNoWindow = true
            });
        }
        private decimal CalculateDeductions()
        {
            try
            {
                // Get the last non-zero deduction value
                for (int i = dgvReport.Rows.Count - 1; i >= 0; i--)
                {
                    var deductionValue = dgvReport.Rows[i].Cells["إجمالي الخصومات"].Value?.ToString() ?? "0";
                    if (decimal.TryParse(deductionValue, out decimal deduction) && deduction > 0)
                    {
                        return deduction;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حساب الخصومات: {ex.Message}");
                return 0;
            }
        }

        private int CalculateWorkDays()
        {
            int workDays = 0;
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                string status = row.Cells["الحالة"].Value?.ToString() ?? "";
                if (status != "اسبوعية" && status != "عطلة" && status != "إجازة")
                {
                    workDays++;
                }
            }
            return workDays;
        }


        private class BasicInfo
        {
            public string EmployeeId { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string Position { get; set; }
            public string HireDate { get; set; }
            public decimal BasicSalary { get; set; }
        }

        private BasicInfo GetBasicInfo()
        {
            var employeeId = dgvReport.Rows[0].Cells["المعرف"].Value?.ToString() ?? "";
            var name = dgvReport.Rows[0].Cells["الاسم"].Value?.ToString() ?? "";

            return new BasicInfo
            {
                EmployeeId = employeeId,
                Name = name,
                Department = "قسم الموظفين", // يمكنك تعديل هذه القيم حسب احتياجك
                Position = "موظف",
                HireDate = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd"),
                BasicSalary = 1000 // يمكنك تغيير القيمة الافتراضية
            };
        }


        private class AttendanceStats
        {
            public int PresentDays { get; set; }
            public int AbsentDays { get; set; }
            public int LateArrivals { get; set; }
            public int EarlyDepartures { get; set; }
            public int Vacations { get; set; }
            public int WorkDays { get; set; }
        }

        private AttendanceStats CalculateAttendanceStats()
        {
            var stats = new AttendanceStats();

            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                string status = row.Cells["الحالة"].Value?.ToString() ?? "";

                switch (status)
                {
                    case "حاضر":
                        stats.PresentDays++;
                        break;
                    case "غائب":
                        stats.AbsentDays++;
                        break;
                    case "إجازة":
                    case "اسبوعية":
                        stats.Vacations++;
                        break;
                }

                // Check actual check-in time
                if (!string.IsNullOrEmpty(row.Cells["الحضور الفعلي"].Value?.ToString()))
                {
                    TimeSpan checkIn;
                    if (TimeSpan.TryParse(row.Cells["الحضور الفعلي"].Value.ToString(), out checkIn))
                    {
                        if (checkIn > new TimeSpan(8, 30, 0))
                            stats.LateArrivals++;
                    }
                }

                // Check actual check-out time
                if (!string.IsNullOrEmpty(row.Cells["الانصراف الفعلي"].Value?.ToString()))
                {
                    TimeSpan checkOut;
                    if (TimeSpan.TryParse(row.Cells["الانصراف الفعلي"].Value.ToString(), out checkOut))
                    {
                        if (checkOut < new TimeSpan(15, 30, 0))
                            stats.EarlyDepartures++;
                    }
                }
            }

            stats.WorkDays = dgvReport.Rows.Count - stats.Vacations;

            return stats;
        }
        private decimal CalculateTotalDeductions()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (decimal.TryParse(row.Cells["إجمالي الخصومات"].Value?.ToString(), out decimal deduction))
                {
                    total += deduction;
                }
            }
            return total;
        }

        private decimal CalculateNetSalary()
        {
            decimal salary = decimal.Parse(txtSalary.Text);
            return salary - CalculateTotalDeductions();
        }
        private void PrintViaWeb()
        {
            string html = @"
<!DOCTYPE html>
<html dir='rtl'>
<head>
    <meta charset='utf-8'>
    <style>
        body { font-family: Arial; margin: 0; padding: 15px; }
        .report-header { text-align: center; margin-bottom: 20px; }
        table { width: 100%; border-collapse: collapse; }
        th { background-color: #000080; color: white; padding: 8px; }
        td { padding: 6px; text-align: center; }
        tr:nth-child(even) { background-color: #f2f2f2; }
        .employee-section { page-break-after: always; }
        .employee-section:last-child { page-break-after: avoid; }
        @media print {
            .no-print { display: none; }
            .employee-section { margin-top: 20px; }
        }
    </style>
</head>
<body>
    <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>";

            // Group rows by employee
            var employeeGroups = dgvReport.Rows.Cast<DataGridViewRow>()
                .GroupBy(row => row.Cells["المعرف"].Value?.ToString());

            foreach (var group in employeeGroups)
            {
                html += $@"
        <div class='employee-section'>
            <div class='report-header'>
                <h2>نظام الحضور والانصراف</h2>
                <p>التاريخ: {DateTime.Now:yyyy/MM/dd}</p>
                <h3>تقرير الحضور والانصراف</h3>
                <p>الموظف: {group.First().Cells["الاسم"].Value?.ToString()}</p>
            </div>
            <table border='1'>
                <thead>
                    <tr>";

                // Add column headers
                foreach (DataGridViewColumn col in dgvReport.Columns)
                {
                    if (col.HeaderText != "الاسم" && col.HeaderText != "GroupOrder")
                    {
                        html += $"<th>{col.HeaderText}</th>";
                    }
                }

                html += @"</tr>
                </thead>
                <tbody>";

                // Add data rows
                foreach (DataGridViewRow row in group)
                {
                    html += "<tr>";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.HeaderText != "الاسم" && cell.OwningColumn.HeaderText != "GroupOrder")
                        {
                            string value = cell.Value?.ToString() ?? "--";
                            html += $"<td>{value}</td>";
                        }
                    }
                    html += "</tr>";
                }

                html += "</tbody></table></div>";
            }

            html += "</body></html>";

            // Save and display the file
            string tempFile = Path.Combine(Path.GetTempPath(), "report.html");
            File.WriteAllText(tempFile, html, Encoding.UTF8);
            Process.Start(new ProcessStartInfo
            {
                FileName = tempFile,
                UseShellExecute = true
            });
        }
        //    private void PrintViaWeb()
        //    {
        //        string html = @"
        //<!DOCTYPE html>
        //<html dir='rtl'>
        //<head>
        //    <meta charset='utf-8'>
        //    <style>
        //        body { font-family: Arial; }
        //        .report-header { text-align: center; margin: 20px; }
        //        table { width: 100%; border-collapse: collapse; margin-top: 20px; }
        //        th { background-color: #000080; color: white; padding: 8px; }
        //        td { padding: 6px; text-align: center; }
        //        tr:nth-child(even) { background-color: #f2f2f2; }
        //        @media print {
        //            .no-print { display: none; }
        //            body { margin: 0; padding: 15px; }
        //        }
        //    </style>
        //</head>
        //<body>
        //    <div class='report-header'>
        //        <h2>نظام الحضور والانصراف</h2>
        //        <p>التاريخ: " + DateTime.Now.ToString("yyyy/MM/dd") + @"</p>
        //        <h3>تقرير الحضور والانصراف</h3>
        //    </div>
        //    <table border='1'>
        //        <tr>";

        //        // إضافة رؤوس الأعمدة
        //        foreach (DataGridViewColumn col in dgvReport.Columns)
        //        {
        //            html += $"<th>{col.HeaderText}</th>";
        //        }

        //        html += "</tr>";

        //        // إضافة البيانات
        //        foreach (DataGridViewRow row in dgvReport.Rows)
        //        {
        //            html += "<tr>";
        //            foreach (DataGridViewCell cell in row.Cells)
        //            {
        //                html += $"<td>{cell.Value?.ToString() ?? "--"}</td>";
        //            }
        //            html += "</tr>";
        //        }

        //        html += @"
        //    </table>
        //    <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
        //</body>
        //</html>";

        //        // حفظ وعرض الملف
        //        string tempFile = Path.Combine(Path.GetTempPath(), "report.html");
        //        File.WriteAllText(tempFile, html, Encoding.UTF8);
        //        Process.Start(tempFile);
        //    }



        //private void BtnPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        PrintPreviewDialog preview = new PrintPreviewDialog();
        //        preview.RightToLeft = RightToLeft.Yes;
        //        printDocument.DefaultPageSettings.Landscape = true;
        //        printDocument.OriginAtMargins = true;
        //        preview.Document = printDocument;
        //        preview.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"حدث خطأ: {ex.Message}");
        //    }
        //}

        //private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    try
        //    {
        //        float rightMargin = e.MarginBounds.Right - 50;
        //        float topMargin = 30;
        //        float yPos = topMargin;
        //        int count = 0;

        //        // عنوان النظام
        //        using (Font systemFont = new Font("Arial", 16, FontStyle.Bold))
        //        {
        //            string systemName = "نظام الحضور والانصراف";
        //            float systemNameWidth = e.Graphics.MeasureString(systemName, systemFont).Width;
        //            e.Graphics.DrawString(systemName, systemFont, Brushes.Navy, rightMargin - systemNameWidth / 2 - 400, yPos);
        //        }
        //        yPos += 30;

        //        // التاريخ
        //        using (Font dateFont = new Font("Arial", 10))
        //        {
        //            string date = $"التاريخ: {DateTime.Now:yyyy/MM/dd}";
        //            e.Graphics.DrawString(date, dateFont, Brushes.Black, rightMargin - 100, yPos);
        //        }
        //        yPos += 30;

        //        // عنوان التقرير
        //        using (Font titleFont = new Font("Arial", 14, FontStyle.Bold))
        //        {
        //            string title = "تقرير الحضور والانصراف";
        //            float titleWidth = e.Graphics.MeasureString(title, titleFont).Width;
        //            e.Graphics.DrawString(title, titleFont, Brushes.Navy, rightMargin - titleWidth / 2 - 400, yPos);
        //        }
        //        yPos += 40;

        //        // رؤوس الأعمدة - معكوسة من اليمين لليسار
        //        float[] columnWidths = { 80, 80, 80, 80, 100, 80, 80, 80, 100, 150, 50 };
        //        string[] headers = { "الراتب", "الخصم", "الخصم", "الراتب", "الحالة", "الانصراف", "الحضور", "اليوم", "التاريخ", "الاسم", "م" };

        //        float xPos = rightMargin;
        //        using (Font headerFont = new Font("Arial", 10, FontStyle.Bold))
        //        {
        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                xPos -= columnWidths[i];
        //                RectangleF headerRect = new RectangleF(xPos, yPos, columnWidths[i], 25);
        //                e.Graphics.FillRectangle(new SolidBrush(Color.Navy), headerRect);
        //                e.Graphics.DrawString(headers[i], headerFont, Brushes.White, headerRect,
        //                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        //            }
        //        }
        //        yPos += 25;

        //        // البيانات - معكوسة من اليمين لليسار
        //        using (Font contentFont = new Font("Arial", 9))
        //        {
        //            for (int i = count; i < dgvReport.Rows.Count; i++)
        //            {
        //                if (yPos + 20 > e.MarginBounds.Height)
        //                {
        //                    e.HasMorePages = true;
        //                    count = i;
        //                    return;
        //                }

        //                xPos = rightMargin;
        //                for (int j = dgvReport.Columns.Count - 1; j >= 0; j--)
        //                {
        //                    xPos -= columnWidths[dgvReport.Columns.Count - 1 - j];
        //                    RectangleF cellRect = new RectangleF(xPos, yPos, columnWidths[dgvReport.Columns.Count - 1 - j], 20);
        //                    e.Graphics.DrawRectangle(new Pen(Color.LightGray), cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
        //                    e.Graphics.DrawString(dgvReport.Rows[i].Cells[j].Value?.ToString() ?? "--",
        //                        contentFont, Brushes.Black, cellRect,
        //                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        //                }
        //                yPos += 20;
        //            }
        //        }

        //        e.HasMorePages = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"حدث خطأ أثناء الطباعة: {ex.Message}");
        //    }
        //}

        private void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedIndex == 0) // الكل
            {
                LoadEmployeeIds();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                currentEmployeeIndex = 0;
                LoadReportForCurrentEmployee();
            }
            else
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                // /*LoadMonthlyReport*/();
            }
        }

        private void LoadEmployeeIds()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            employeeIds.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UserID FROM Employees WHERE Enabled = 1 ORDER BY Name", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeIds.Add(reader["UserID"].ToString());
                        }
                    }
                }
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentEmployeeIndex > 0)
            {
                currentEmployeeIndex--;
                LoadReportForCurrentEmployee();
            }
            UpdateNavigationButtons();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentEmployeeIndex < employeeIds.Count - 1)
            {
                currentEmployeeIndex++;
                LoadReportForCurrentEmployee();
            }
            UpdateNavigationButtons();
        }

        //private void LoadReportForCurrentEmployee()
        //{
        //    if (currentEmployeeIndex >= 0 && currentEmployeeIndex < employeeIds.Count)
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(GetDisciplinedEmployeesQuery(), conn))
        //            {
        //                cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
        //                cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);
        //                cmd.Parameters.AddWithValue("@SelectedUserID", employeeIds[currentEmployeeIndex]);
        //                cmd.Parameters.AddWithValue("@SalaryAmount",
        //                    decimal.TryParse(txtSalary.Text, out decimal salary) ? salary : 0);

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                dgvReport.DataSource = dt;
        //            }
        //        }
        //    }
        //}

        private void LoadReportForCurrentEmployee()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            if (currentEmployeeIndex >= 0 && currentEmployeeIndex < employeeIds.Count)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(GetDisciplinedEmployeesQuery(), conn))
                        {
                            cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                            cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);
                            cmd.Parameters.AddWithValue("@SelectedUserID", employeeIds[currentEmployeeIndex]);

                            // إضافة معامل مصدر الخصم
                            int deductionSource = rbSalary.Checked ? 0 :
                                                rbBonus.Checked ? 1 : 2;
                            cmd.Parameters.AddWithValue("@DeductionSource", deductionSource);

                            // إضافة المبلغ المحدد
                            decimal customAmount = 0;
                            if (rbCustom.Checked && decimal.TryParse(txtSalary.Text, out decimal amount))
                            {
                                customAmount = amount;
                            }
                            cmd.Parameters.AddWithValue("@SalaryAmount", customAmount);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvReport.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}");
                }
            }
        }

        private void UpdateNavigationButtons()
        {
            btnPrevious.Enabled = currentEmployeeIndex > 0;
            btnNext.Enabled = currentEmployeeIndex < employeeIds.Count - 1;
        }
        private void LoadEmployees()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(GetDisciplinedEmployeesQuery(), conn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);
                        cmd.Parameters.AddWithValue("@SelectedUserID",
                            cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue.ToString() == "0"
                            ? DBNull.Value
                            : cmbEmployee.SelectedValue);
                        cmd.Parameters.AddWithValue("@DeductionSource",
                            rbSalary.Checked ? 0 :
                            rbBonus.Checked ? 1 : 2);
                        cmd.Parameters.AddWithValue("@SalaryAmount",
                            decimal.TryParse(txtSalary.Text, out decimal amount) ? amount : 0);

                        conn.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        dgvReport.DataSource = dt;

                        // تنسيق أعمدة التاريخ والوقت
                        foreach (DataGridViewColumn col in dgvReport.Columns)
                        {
                            if (col.Name == "التاريخ")
                                col.DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ في تحميل البيانات: {ex.Message}");
            }
        }
        private void LoadEmployeeComboBox()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT UserID, Name FROM Employees WHERE Enabled = 1 ORDER BY Name", conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        // إضافة خيار "الكل"
                        DataRow allRow = dt.NewRow();
                        allRow["UserID"] = "0";
                        allRow["Name"] = "الكل";
                        dt.Rows.InsertAt(allRow, 0);

                        cmbEmployee.DisplayMember = "Name";
                        cmbEmployee.ValueMember = "UserID";
                        cmbEmployee.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ في تحميل الموظفين: {ex.Message}");
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMonthlyReport();
        }

        private void LoadMonthlyReport()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(GetDisciplinedEmployeesQuery(), conn))
                    {
                        // تحديد مصدر الخصم
                        int deductionSource = rbSalary.Checked ? 0 :
                                            rbBonus.Checked ? 1 : 2;

                        // تحديد مبلغ الراتب
                        decimal salaryAmount = 0;
                        if (deductionSource == 2) // إذا كان المبلغ المحدد
                        {
                            if (!decimal.TryParse(txtSalary.Text, out salaryAmount))
                            {
                                MessageBox.Show("الرجاء إدخال مبلغ صحيح");
                                return;
                            }
                        }

                        cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);
                        cmd.Parameters.AddWithValue("@SelectedUserID",
                            cmbEmployee.SelectedValue.ToString() == "0" ? DBNull.Value : cmbEmployee.SelectedValue);
                        cmd.Parameters.AddWithValue("@DeductionSource", deductionSource);
                        cmd.Parameters.AddWithValue("@SalaryAmount", salaryAmount);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvReport.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }
        private void ExportToExcel()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"تقرير_الحضور_{DateTime.Now:yyyy_MM_dd}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = false;
                    Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel.Worksheet sheet = workbook.ActiveSheet;

                    // تصدير عناوين الأعمدة
                    for (int i = 0; i < dgvReport.Columns.Count; i++)
                    {
                        sheet.Cells[1, i + 1] = dgvReport.Columns[i].HeaderText;
                    }

                    // تصدير البيانات
                    for (int i = 0; i < dgvReport.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvReport.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j + 1] = dgvReport.Rows[i].Cells[j].Value?.ToString() ?? "";
                        }
                    }

                    // تنسيق الجدول
                    var range = sheet.Range[sheet.Cells[1, 1], sheet.Cells[dgvReport.Rows.Count + 1, dgvReport.Columns.Count]];
                    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    range.Font.Name = "Arial";
                    range.Columns.AutoFit();

                    // حفظ الملف
                    workbook.SaveAs(sfd.FileName);
                    workbook.Close();
                    excel.Quit();

                    MessageBox.Show("تم تصدير البيانات بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDisciplinedEmployeesQuery()
        {
            return @"
WITH DateRange AS (
    SELECT TOP (ABS(DATEDIFF(DAY, @FromDate, @ToDate)) + 1)
        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @FromDate) AS Date
    FROM sys.objects
),
EmployeeCurrentSalary AS (
    SELECT
        UserID,
        BasicSalary,
        Bonus
    FROM EmployeeSalary
    WHERE IsActive = 1
),
SalaryBase AS (
    SELECT
        e.UserID,
        CASE @DeductionSource
            WHEN 0 THEN ISNULL(es.BasicSalary, 0)
            WHEN 1 THEN ISNULL(es.Bonus, 0)
            ELSE @SalaryAmount
        END AS BaseAmount
    FROM Employees e
    LEFT JOIN EmployeeSalary es ON e.UserID = es.UserID AND es.IsActive = 1
    WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
),
AttendanceCTE AS (
    SELECT
        e.UserID,
        e.Name,
        sh.ShiftID,
        sh.ShiftName,
        d.Date AS AttendanceDate,
        sh.StartTime AS ScheduledCheckIn,
        sh.EndTime AS ScheduledCheckOut,
        -- إضافة CheckInStart كبداية فترة تسجيل الحضور
        CAST(d.Date AS DATETIME) + CAST(sh.CheckInStart AS DATETIME) AS CheckInStartTime,
        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
    FROM Employees e
    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
    INNER JOIN DateRange d ON d.Date BETWEEN sc.StartDate AND sc.EndDate
    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    INNER JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID -- ربط بالجدول الجديد
        AND swd.DayOfWeek = (
            CASE DATENAME(WEEKDAY, d.Date)
                WHEN 'Sunday' THEN N'الأحد'
                WHEN 'Monday' THEN N'الاثنين'
                WHEN 'Tuesday' THEN N'الثلاثاء'
                WHEN 'Wednesday' THEN N'الأربعاء'
                WHEN 'Thursday' THEN N'الخميس'
                WHEN 'Friday' THEN N'الجمعة'
                WHEN 'Saturday' THEN N'السبت'
            END
        )
    LEFT JOIN Attendance a ON e.UserID = a.UserID
        AND CAST(a.DateTime AS DATE) = d.Date
    WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
    GROUP BY
        e.UserID, e.Name, sh.ShiftID, sh.ShiftName, d.Date,
        sh.StartTime, sh.EndTime, sh.CheckInStart
),
LeavePermissionCTE AS (
    SELECT
        e.UserID,
        d.Date AS AttendanceDate,
        MAX(CASE WHEN l.LeaveDate = d.Date THEN l.LeaveType END) AS LeaveType,
        MAX(CASE WHEN p.PermissionDate = d.Date THEN p.Status END) AS PermissionStatus
    FROM Employees e
    CROSS JOIN DateRange d
    LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = d.Date
    LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = d.Date
    WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
    GROUP BY e.UserID, d.Date
),
DiscountCalculation AS (


    SELECT
        a.*,
        ecs.BasicSalary,
        ecs.Bonus,
        sb.BaseAmount,
        -- نوع الخصم
        CASE
            WHEN h.HolidayDate IS NOT NULL THEN N'بدون خصم'
            WHEN w.DayOfWeek IS NULL THEN N'بدون خصم'
            WHEN l.LeaveType IS NOT NULL THEN N'بدون خصم'
            WHEN l.PermissionStatus = N'مقبول' THEN N'بدون خصم'
            WHEN a.ActualCheckIn < a.CheckInStartTime THEN N'يوم كامل'
            WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'يوم كامل'
            WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
                 AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'نصف يوم'
            ELSE N'بدون خصم'
        END AS DiscountType,
        -- مبلغ الخصم اليومي
        CASE
            WHEN h.HolidayDate IS NOT NULL THEN 0
            WHEN w.DayOfWeek IS NULL THEN 0
            WHEN l.LeaveType IS NOT NULL THEN 0
            WHEN l.PermissionStatus = N'مقبول' THEN 0
            WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN sb.BaseAmount / 30
            WHEN a.ActualCheckIn < a.CheckInStartTime THEN sb.BaseAmount / 30
            WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
                 AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60

   WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND
             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) THEN sb.BaseAmount / 60
        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)) AND
            a.ActualCheckOut IS NULL THEN sb.BaseAmount / 60
        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) AND
             CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN sb.BaseAmount / 60
        WHEN a.ActualCheckIn IS NULL AND CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN sb.BaseAmount / 60
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL AND
             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) AND
             CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut AND
             CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) THEN sb.BaseAmount / 60
            ELSE 0
        END AS DailyDiscount,
        -- مجموع الخصومات
        SUM(
            CASE
                WHEN h.HolidayDate IS NOT NULL THEN 0
                WHEN w.DayOfWeek IS NULL THEN 0
                WHEN l.LeaveType IS NOT NULL THEN 0
                WHEN l.PermissionStatus = N'مقبول' THEN 0
                WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN sb.BaseAmount / 30
                WHEN a.ActualCheckIn < a.CheckInStartTime THEN sb.BaseAmount / 30
                WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
                     AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60

WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND
             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) THEN sb.BaseAmount / 60
        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)) AND
            a.ActualCheckOut IS NULL THEN sb.BaseAmount / 60
        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) AND
             CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN sb.BaseAmount / 60
        WHEN a.ActualCheckIn IS NULL AND CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN sb.BaseAmount / 60
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL AND
             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) AND
             CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut AND
             CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) THEN sb.BaseAmount / 60
                ELSE 0
            END
        ) OVER (
            PARTITION BY a.UserID
            ORDER BY a.AttendanceDate, sh.ShiftID
            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
        ) AS RunningTotalDiscount
    FROM AttendanceCTE a
    LEFT JOIN EmployeeCurrentSalary ecs ON a.UserID = ecs.UserID
    LEFT JOIN SalaryBase sb ON a.UserID = sb.UserID
    LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.AttendanceDate
    LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
    LEFT JOIN WorkingDays w ON w.DayOfWeek = (
        CASE DATENAME(WEEKDAY, a.AttendanceDate)
            WHEN 'Sunday' THEN N'الأحد'
            WHEN 'Monday' THEN N'الاثنين'
            WHEN 'Tuesday' THEN N'الثلاثاء'
            WHEN 'Wednesday' THEN N'الأربعاء'
            WHEN 'Thursday' THEN N'الخميس'
            WHEN 'Friday' THEN N'الجمعة'
            WHEN 'Saturday' THEN N'السبت'
        END
    )
    LEFT JOIN Shifts sh ON a.ShiftID = sh.ShiftID
)



SELECT
    dc.UserID AS 'المعرف',
    dc.Name AS 'الاسم',
    dc.ShiftName AS 'الوردية',
    dc.AttendanceDate AS 'التاريخ',
    CASE DATENAME(WEEKDAY, dc.AttendanceDate)
        WHEN 'Sunday' THEN N'الأحد'
        WHEN 'Monday' THEN N'الاثنين'
        WHEN 'Tuesday' THEN N'الثلاثاء'
        WHEN 'Wednesday' THEN N'الأربعاء'
        WHEN 'Thursday' THEN N'الخميس'
        WHEN 'Friday' THEN N'الجمعة'
        WHEN 'Saturday' THEN N'السبت'
    END AS 'يوم الأسبوع',
    COALESCE(CONVERT(VARCHAR, CAST(dc.ScheduledCheckIn AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckIn AS TIME), 108), '--') AS 'الحضور الفعلي',
    COALESCE(CONVERT(VARCHAR, CAST(dc.ScheduledCheckOut AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckOut AS TIME), 108), '--') AS 'الانصراف الفعلي',
    CASE
        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN N'إجازة'
        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        -- إضافة شرط حضور مبكر غير مسموح
        WHEN dc.ActualCheckIn < dc.CheckInStartTime THEN N'غائب'
        WHEN dc.ActualCheckIn IS NULL AND dc.ActualCheckOut IS NULL THEN N'غائب'
        WHEN (CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
              CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut) THEN N'حاضر'
        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NULL AND
             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
        WHEN (dc.ActualCheckIn IS NOT NULL AND CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn)) AND
            dc.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'
        WHEN CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
             CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'حضور متاخر'
        WHEN dc.ActualCheckIn IS NULL AND CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'لم يسجل حضور'
        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NOT NULL AND
             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
             CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
        WHEN CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut AND
             CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'انصراف مبكر'
        ELSE N'غائب'
    END AS 'الحالة',
    sb.BaseAmount AS 'الراتب الشهري',
    dc.DailyDiscount AS 'مبلغ الخصم اليومي',
    dc.RunningTotalDiscount AS 'إجمالي الخصومات',
    sb.BaseAmount - dc.RunningTotalDiscount AS 'صافي الراتب'
FROM DiscountCalculation dc
LEFT JOIN SalaryBase sb ON dc.UserID = sb.UserID
LEFT JOIN LeavePermissionCTE l ON dc.UserID = l.UserID AND dc.AttendanceDate = l.AttendanceDate
LEFT JOIN Holidays h ON h.HolidayDate = dc.AttendanceDate
LEFT JOIN WorkingDays w ON w.DayOfWeek = (
    CASE DATENAME(WEEKDAY, dc.AttendanceDate)
        WHEN 'Sunday' THEN N'الأحد'
        WHEN 'Monday' THEN N'الاثنين'
        WHEN 'Tuesday' THEN N'الثلاثاء'
        WHEN 'Wednesday' THEN N'الأربعاء'
        WHEN 'Thursday' THEN N'الخميس'
        WHEN 'Friday' THEN N'الجمعة'
        WHEN 'Saturday' THEN N'السبت'
    END
)
LEFT JOIN Shifts s ON dc.ShiftID = s.ShiftID
ORDER BY
    CASE WHEN @SelectedUserID IS NULL THEN dc.UserID ELSE 1 END,
    dc.AttendanceDate,
    CASE
        WHEN dc.ShiftName = 'فترة صباحيه' THEN 1
        WHEN dc.ShiftName = 'فترة مسائية' THEN 2
        ELSE 3
    END,
    dc.Name;";
        }
        //        private string GetDisciplinedEmployeesQuery()
        //        {
        //            return @"


        //WITH DateRange AS (
        //    SELECT TOP (ABS(DATEDIFF(DAY, @FromDate, @ToDate)) + 1)
        //        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @FromDate) AS Date
        //    FROM sys.objects
        //),
        //EmployeeCurrentSalary AS (
        //    SELECT
        //        UserID,
        //        BasicSalary,
        //        Bonus
        //    FROM EmployeeSalary
        //    WHERE IsActive = 1
        //),
        //SalaryBase AS (
        //    SELECT
        //        e.UserID,
        //        CASE @DeductionSource
        //            WHEN 0 THEN ISNULL(es.BasicSalary, 0)
        //            WHEN 1 THEN ISNULL(es.Bonus, 0)
        //            ELSE @SalaryAmount
        //        END AS BaseAmount
        //    FROM Employees e
        //    LEFT JOIN EmployeeSalary es ON e.UserID = es.UserID AND es.IsActive = 1
        //    WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
        //),
        //AttendanceCTE AS (
        //    SELECT
        //        e.UserID,
        //        e.Name,
        //        sh.ShiftID,
        //        sh.ShiftName,
        //        d.Date AS AttendanceDate,
        //        sh.StartTime AS ScheduledCheckIn,
        //        sh.EndTime AS ScheduledCheckOut,

        //        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        //        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
        //    FROM Employees e
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
        //    INNER JOIN DateRange d ON d.Date BETWEEN sc.StartDate AND sc.EndDate
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    INNER JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID -- ربط بالجدول الجديد
        //        AND swd.DayOfWeek = (
        //            CASE DATENAME(WEEKDAY, d.Date)
        //                WHEN 'Sunday' THEN N'الأحد'
        //                WHEN 'Monday' THEN N'الاثنين'
        //                WHEN 'Tuesday' THEN N'الثلاثاء'
        //                WHEN 'Wednesday' THEN N'الأربعاء'
        //                WHEN 'Thursday' THEN N'الخميس'
        //                WHEN 'Friday' THEN N'الجمعة'
        //                WHEN 'Saturday' THEN N'السبت'
        //            END
        //        )
        //    LEFT JOIN Attendance a ON e.UserID = a.UserID
        //        AND CAST(a.DateTime AS DATE) = d.Date
        //    WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
        //    GROUP BY
        //        e.UserID, e.Name, sh.ShiftID, sh.ShiftName, d.Date,
        //        sh.StartTime, sh.EndTime
        //),
        //LeavePermissionCTE AS (
        //    SELECT
        //        e.UserID,
        //        d.Date AS AttendanceDate,
        //        MAX(CASE WHEN l.LeaveDate = d.Date THEN l.LeaveType END) AS LeaveType,
        //        MAX(CASE WHEN p.PermissionDate = d.Date THEN p.Status END) AS PermissionStatus
        //    FROM Employees e
        //    CROSS JOIN DateRange d
        //    LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = d.Date
        //    LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = d.Date
        //    WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
        //    GROUP BY e.UserID, d.Date
        //),
        //DiscountCalculation AS (
        //    SELECT
        //        a.*,
        //        ecs.BasicSalary,
        //        ecs.Bonus,
        //        COALESCE(d.DiscountAmount, 0) AS DailyDiscount,
        //        SUM(COALESCE(d.DiscountAmount, 0)) OVER(
        //            PARTITION BY a.UserID
        //            ORDER BY a.AttendanceDate, sh.ShiftID
        //            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
        //        ) AS RunningTotalDiscount
        //    FROM AttendanceCTE a
        //    LEFT JOIN EmployeeCurrentSalary ecs ON a.UserID = ecs.UserID
        //    LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.AttendanceDate
        //    LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
        //    LEFT JOIN WorkingDays w ON w.DayOfWeek = (
        //        CASE DATENAME(WEEKDAY, a.AttendanceDate)
        //            WHEN 'Sunday' THEN N'الأحد'
        //            WHEN 'Monday' THEN N'الاثنين'
        //            WHEN 'Tuesday' THEN N'الثلاثاء'
        //            WHEN 'Wednesday' THEN N'الأربعاء'
        //            WHEN 'Thursday' THEN N'الخميس'
        //            WHEN 'Friday' THEN N'الجمعة'
        //            WHEN 'Saturday' THEN N'السبت'
        //        END
        //    )
        //    LEFT JOIN Shifts sh ON a.ShiftID = sh.ShiftID
        //    LEFT JOIN Discounts d ON
        //        CASE
        //            WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        //            WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        //            WHEN l.LeaveType IS NOT NULL THEN N'إجازة'
        //            WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        //            WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'

        //            WHEN (CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) AND
        //                  CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut) THEN N'حاضر'
        //            WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND
        //                 CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
        //            WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)) AND
        //                a.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'
        //            WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) AND
        //                 CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'حضور متاخر'
        //            WHEN a.ActualCheckIn IS NULL AND CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'لم يسجل حضور'
        //            WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL AND
        //                 CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) AND
        //                 CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
        //            WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut AND
        //                 CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'انصراف مبكر'
        //            ELSE N'غائب'
        //        END = d.ConditionName
        //)
        //SELECT
        //    dc.UserID AS 'المعرف',
        //    dc.Name AS 'الاسم',
        //    dc.ShiftName AS 'الوردية',
        //    dc.AttendanceDate AS 'التاريخ',
        //    CASE DATENAME(WEEKDAY, dc.AttendanceDate)
        //        WHEN 'Sunday' THEN N'الأحد'
        //        WHEN 'Monday' THEN N'الاثنين'
        //        WHEN 'Tuesday' THEN N'الثلاثاء'
        //        WHEN 'Wednesday' THEN N'الأربعاء'
        //        WHEN 'Thursday' THEN N'الخميس'
        //        WHEN 'Friday' THEN N'الجمعة'
        //        WHEN 'Saturday' THEN N'السبت'
        //    END AS 'يوم الأسبوع',
        //    COALESCE(CONVERT(VARCHAR, CAST(dc.ScheduledCheckIn AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckIn AS TIME), 108), '--') AS 'الحضور الفعلي',
        //    COALESCE(CONVERT(VARCHAR, CAST(dc.ScheduledCheckOut AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckOut AS TIME), 108), '--') AS 'الانصراف الفعلي',
        //    CASE
        //        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        //        WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        //        WHEN l.LeaveType IS NOT NULL THEN N'إجازة'
        //        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        //        WHEN dc.ActualCheckIn IS NULL AND dc.ActualCheckOut IS NULL THEN N'غائب'

        //        WHEN (CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
        //              CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut) THEN N'حاضر'
        //        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NULL AND
        //             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
        //        WHEN (dc.ActualCheckIn IS NOT NULL AND CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn)) AND
        //            dc.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'
        //        WHEN CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
        //             CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'حضور متاخر'
        //        WHEN dc.ActualCheckIn IS NULL AND CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'لم يسجل حضور'
        //        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NOT NULL AND
        //             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
        //             CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
        //        WHEN CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut AND
        //             CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'انصراف مبكر'
        //        ELSE N'غائب'
        //    END AS 'الحالة',
        //    sb.BaseAmount AS 'الراتب الشهري',
        //    dc.DailyDiscount AS 'مبلغ الخصم اليومي',
        //    dc.RunningTotalDiscount AS 'إجمالي الخصومات',
        //    sb.BaseAmount - dc.RunningTotalDiscount AS 'صافي الراتب'
        //FROM DiscountCalculation dc
        //LEFT JOIN SalaryBase sb ON dc.UserID = sb.UserID
        //LEFT JOIN LeavePermissionCTE l ON dc.UserID = l.UserID AND dc.AttendanceDate = l.AttendanceDate
        //LEFT JOIN Holidays h ON h.HolidayDate = dc.AttendanceDate
        //LEFT JOIN WorkingDays w ON w.DayOfWeek = (
        //    CASE DATENAME(WEEKDAY, dc.AttendanceDate)
        //        WHEN 'Sunday' THEN N'الأحد'
        //        WHEN 'Monday' THEN N'الاثنين'
        //        WHEN 'Tuesday' THEN N'الثلاثاء'
        //        WHEN 'Wednesday' THEN N'الأربعاء'
        //        WHEN 'Thursday' THEN N'الخميس'
        //        WHEN 'Friday' THEN N'الجمعة'
        //        WHEN 'Saturday' THEN N'السبت'
        //    END
        //)
        //LEFT JOIN Shifts s ON dc.ShiftID = s.ShiftID
        //ORDER BY
        //    CASE WHEN @SelectedUserID IS NULL THEN dc.UserID ELSE 1 END,
        //    dc.AttendanceDate,
        //    CASE
        //        WHEN dc.ShiftName = 'فترة صباحيه' THEN 1
        //        WHEN dc.ShiftName = 'فترة مسائية' THEN 2
        //        ELSE 3
        //    END,
        //    dc.Name;";
        //        }



        ////        private string GetDisciplinedEmployeesQuery()
        ////        {
        ////            return @"
        ////        DECLARE @SelectedShiftName NVARCHAR(50) = NULL;

        //            //        WITH EmployeeCurrentSalary AS (
        //            //            SELECT 
        //            //                UserID,
        //            //                BasicSalary,
        //            //                Bonus
        //            //            FROM EmployeeSalary
        //            //            WHERE IsActive = 1
        //            //        ),
        //            //        DateRange AS (
        //            //            SELECT TOP (ABS(DATEDIFF(DAY, @FromDate, @ToDate)) + 1)
        //            //                DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @FromDate) AS Date
        //            //            FROM sys.objects
        //            //        ),
        //            //        SalaryBase AS (
        //            //            SELECT 
        //            //                e.UserID,
        //            //                CASE @DeductionSource
        //            //                    WHEN 0 THEN ISNULL(es.BasicSalary, 0)
        //            //                    WHEN 1 THEN ISNULL(es.Bonus, 0)
        //            //                    ELSE @SalaryAmount
        //            //                END AS BaseAmount
        //            //            FROM Employees e
        //            //            LEFT JOIN EmployeeSalary es ON e.UserID = es.UserID AND es.IsActive = 1
        //            //            WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
        //            //        ),
        //            //        AttendanceCTE AS (
        //            //            SELECT 
        //            //                e.UserID,
        //            //                e.Name,
        //            //                sh.ShiftName,
        //            //                d.Date AS AttendanceDate,
        //            //                sh.StartTime AS ScheduledCheckIn,
        //            //                sh.EndTime AS ScheduledCheckOut,
        //            //                MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        //            //                MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
        //            //            FROM Employees e
        //            //            INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID -- التعديل هنا (INNER بدل CROSS)
        //            //            INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
        //            //            INNER JOIN DateRange d ON d.Date BETWEEN sc.StartDate AND sc.EndDate -- التعديل هنا
        //            //            INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //            //            LEFT JOIN Attendance a ON e.UserID = a.UserID 
        //            //                AND CAST(a.DateTime AS DATE) = d.Date
        //            //            WHERE (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
        //            //            GROUP BY 
        //            //                e.UserID, e.Name, sh.ShiftName, d.Date, 
        //            //                sh.StartTime, sh.EndTime
        //            //        ),
        //            //        LeavePermissionCTE AS (
        //            //            SELECT 
        //            //                e.UserID,
        //            //                d.Date AS AttendanceDate,
        //            //                MAX(CASE WHEN l.LeaveDate = d.Date THEN l.LeaveType END) AS LeaveType,
        //            //                MAX(CASE WHEN p.PermissionDate = d.Date THEN p.Status END) AS PermissionStatus
        //            //            FROM Employees e
        //            //            CROSS JOIN DateRange d
        //            //            LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = d.Date
        //            //            LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = d.Date
        //            //            WHERE @SelectedUserID IS NULL OR e.UserID = @SelectedUserID
        //            //            GROUP BY e.UserID, d.Date
        //            //        ),
        //            //        DiscountCalculation AS (
        //            //            SELECT 
        //            //                a.*,
        //            //                ecs.BasicSalary,
        //            //                ecs.Bonus,
        //            //                COALESCE(d.DiscountAmount, 0) AS DailyDiscount,
        //            //                SUM(COALESCE(d.DiscountAmount, 0)) OVER (
        //            //                    PARTITION BY a.UserID
        //            //                    ORDER BY a.AttendanceDate
        //            //                    ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
        //            //                ) AS RunningTotalDiscount
        //            //            FROM AttendanceCTE a
        //            //            LEFT JOIN EmployeeCurrentSalary ecs ON a.UserID = ecs.UserID
        //            //            LEFT JOIN Leaves l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate -- التعديل هنا
        //            //            LEFT JOIN Permissions p ON a.UserID = p.UserID AND a.AttendanceDate = p.PermissionDate -- التعديل هنا
        //            //            LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
        //            //            LEFT JOIN Shifts s ON a.ShiftName = s.ShiftName
        //            //           LEFT JOIN Discounts d ON
        //            //    CASE
        //            //        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        //            //        WHEN l.LeaveType IS NOT NULL THEN N'إجازة'
        //            //        WHEN p.Status = N'مقبول' THEN N'أذن عمل' -- التعديل هنا
        //            //        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
        //            //        ELSE N'حاضر'
        //            //    END = d.ConditionName
        //            //        )

        //            //        SELECT DISTINCT
        //            //            dc.UserID AS 'المعرف',
        //            //            dc.Name AS 'الاسم',
        //            //            dc.ShiftName AS 'الوردية',
        //            //            dc.AttendanceDate AS 'التاريخ',
        //            //            CASE DATENAME(WEEKDAY, dc.AttendanceDate)
        //            //                WHEN 'Sunday' THEN N'الأحد'
        //            //                WHEN 'Monday' THEN N'الاثنين'
        //            //                WHEN 'Tuesday' THEN N'الثلاثاء'
        //            //                WHEN 'Wednesday' THEN N'الأربعاء'
        //            //                WHEN 'Thursday' THEN N'الخميس'
        //            //                WHEN 'Friday' THEN N'الجمعة'
        //            //                WHEN 'Saturday' THEN N'السبت'
        //            //            END AS 'يوم الأسبوع',
        //            //            CONVERT(VARCHAR, CAST(dc.ScheduledCheckIn AS TIME), 100) AS 'ميعاد الحضور المخطط',
        //            //            COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckIn AS TIME), 100), '--') AS 'الحضور الفعلي',
        //            //            CONVERT(VARCHAR, CAST(dc.ScheduledCheckOut AS TIME), 100) AS 'ميعاد الانصراف المخطط',
        //            //            COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',
        //            //           CASE
        //            //    WHEN l.LeaveType IS NOT NULL THEN N'إجازة'
        //            //    WHEN p.Status = N'مقبول' THEN N'أذن عمل' -- التعديل هنا
        //            //    WHEN dc.ActualCheckIn IS NULL AND dc.ActualCheckOut IS NULL THEN N'غائب'
        //            //    ELSE N'حاضر'
        //            //END AS 'الحالة'
        //            //            sb.BaseAmount AS 'الراتب الشهري',
        //            //            dc.DailyDiscount AS 'مبلغ الخصم اليومي',
        //            //            dc.RunningTotalDiscount AS 'إجمالي الخصومات',
        //            //            sb.BaseAmount - dc.RunningTotalDiscount AS 'صافي الراتب'
        //            //        FROM DiscountCalculation dc
        //            //        LEFT JOIN SalaryBase sb ON dc.UserID = sb.UserID
        //            //        LEFT JOIN Leaves l ON dc.UserID = l.UserID AND dc.AttendanceDate = l.LeaveDate -- التعديل هنا
        //            //        LEFT JOIN Permissions p ON dc.UserID = p.UserID AND dc.AttendanceDate = p.PermissionDate -- التعديل هنا
        //            //        ORDER BY dc.AttendanceDate;";
        //            //        }


        private void btnWebPrint_Click(object sender, EventArgs e)
        {
            PrintViaWeb();
        }




//        DiscountCalculation AS(
//            SELECT
//                a.*,
//                ecs.BasicSalary,
//                ecs.Bonus,
//                sb.BaseAmount,
//                -- نوع الخصم
        
//                CASE
//                    WHEN h.HolidayDate IS NOT NULL THEN N'بدون خصم'

//                    WHEN w.DayOfWeek IS NULL THEN N'بدون خصم'

//                    WHEN l.LeaveType IS NOT NULL THEN N'بدون خصم'

//                    WHEN l.PermissionStatus = N'مقبول' THEN N'بدون خصم'

//                    WHEN a.ActualCheckIn<a.CheckInStartTime THEN N'يوم كامل'

//                    WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'يوم كامل'

//                    WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
//                 AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'نصف يوم'
//            ELSE N'بدون خصم'
//        END AS DiscountType,
//        -- مبلغ الخصم اليومي
//        CASE
//            WHEN h.HolidayDate IS NOT NULL THEN 0
//            WHEN w.DayOfWeek IS NULL THEN 0
//            WHEN l.LeaveType IS NOT NULL THEN 0
//            WHEN l.PermissionStatus = N'مقبول' THEN 0
//            WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN sb.BaseAmount / 30
//            WHEN a.ActualCheckIn<a.CheckInStartTime THEN sb.BaseAmount / 30
//            WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
//                 AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60
//            ELSE 0
//        END AS DailyDiscount,
//        -- مجموع الخصومات
//        SUM(
//            CASE

// WHEN dc.ActualCheckIn<dc.CheckInStartTime THEN N'غائب'
//        WHEN dc.ActualCheckIn IS NULL AND dc.ActualCheckOut IS NULL THEN N'غائب'
//        WHEN (CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
//              CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut) THEN N'حاضر'
//        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NULL AND
//             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
//        WHEN(dc.ActualCheckIn IS NOT NULL AND CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn)) AND
//           dc.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'

//       WHEN CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
//            CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'حضور متاخر'
//        WHEN dc.ActualCheckIn IS NULL AND CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'لم يسجل حضور'
//        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NOT NULL AND
//             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
//             CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
//        WHEN CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut AND
//             CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'انصراف مبكر'

//                WHEN h.HolidayDate IS NOT NULL THEN 0
//                WHEN w.DayOfWeek IS NULL THEN 0
//                WHEN l.LeaveType IS NOT NULL THEN 0
//                WHEN l.PermissionStatus = N'مقبول' THEN 0
//                WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN sb.BaseAmount / 30
//                WHEN a.ActualCheckIn<a.CheckInStartTime THEN sb.BaseAmount / 30
//                WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
//                     AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60
//             WHEN(a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)) AND
//           a.ActualCheckOut IS NULL THEN sb.BaseAmount / 30

//               ELSE 0

//           END

//       ) OVER(
//           PARTITION BY a.UserID
//           ORDER BY a.AttendanceDate, sh.ShiftID
//           ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
//       ) AS RunningTotalDiscount
//    FROM AttendanceCTE a
//    LEFT JOIN EmployeeCurrentSalary ecs ON a.UserID = ecs.UserID
//    LEFT JOIN SalaryBase sb ON a.UserID = sb.UserID
//    LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.AttendanceDate
//    LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
//    LEFT JOIN WorkingDays w ON w.DayOfWeek = (
//        CASE DATENAME(WEEKDAY, a.AttendanceDate)
//            WHEN 'Sunday' THEN N'الأحد'
//            WHEN 'Monday' THEN N'الاثنين'
//            WHEN 'Tuesday' THEN N'الثلاثاء'
//            WHEN 'Wednesday' THEN N'الأربعاء'
//            WHEN 'Thursday' THEN N'الخميس'
//            WHEN 'Friday' THEN N'الجمعة'
//            WHEN 'Saturday' THEN N'السبت'
//        END
//    )
//    LEFT JOIN Shifts sh ON a.ShiftID = sh.ShiftID


//        DiscountCalculation AS(
//      SELECT
//          a.*,
//          ecs.BasicSalary,
//          ecs.Bonus,
//          sb.BaseAmount,
//          -- نوع الخصم
  
//          CASE
//              WHEN h.HolidayDate IS NOT NULL THEN N'بدون خصم'

//              WHEN w.DayOfWeek IS NULL THEN N'بدون خصم'

//              WHEN l.LeaveType IS NOT NULL THEN N'بدون خصم'

//              WHEN l.PermissionStatus = N'مقبول' THEN N'بدون خصم'

//              WHEN a.ActualCheckIn<a.CheckInStartTime THEN N'يوم كامل'

//              WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'يوم كامل'

//              WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
//                 AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'نصف يوم'
//            ELSE N'بدون خصم'
//        END AS DiscountType,
//        -- مبلغ الخصم اليومي
//        CASE
//            WHEN h.HolidayDate IS NOT NULL THEN 0
//            WHEN w.DayOfWeek IS NULL THEN 0
//            WHEN l.LeaveType IS NOT NULL THEN 0
//            WHEN l.PermissionStatus = N'مقبول' THEN 0
//            WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN sb.BaseAmount / 30
//            WHEN a.ActualCheckIn<a.CheckInStartTime THEN sb.BaseAmount / 30
//            WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
//                 AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60
//            ELSE 0
//        END AS DailyDiscount,
//        -- مجموع الخصومات
//        SUM(
//            CASE
//                WHEN h.HolidayDate IS NOT NULL THEN 0
//                WHEN w.DayOfWeek IS NULL THEN 0
//                WHEN l.LeaveType IS NOT NULL THEN 0
//                WHEN l.PermissionStatus = N'مقبول' THEN 0
//                WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN sb.BaseAmount / 30
//                WHEN a.ActualCheckIn<a.CheckInStartTime THEN sb.BaseAmount / 30
//                WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, sh.CheckInGracePeriod, a.ScheduledCheckIn)
//                     AND CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN sb.BaseAmount / 60
//                ELSE 0
//            END
//        ) OVER(
//            PARTITION BY a.UserID
//            ORDER BY a.AttendanceDate, sh.ShiftID
//            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
//        ) AS RunningTotalDiscount
//    FROM AttendanceCTE a
//    LEFT JOIN EmployeeCurrentSalary ecs ON a.UserID = ecs.UserID
//    LEFT JOIN SalaryBase sb ON a.UserID = sb.UserID
//    LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.AttendanceDate
//    LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
//    LEFT JOIN WorkingDays w ON w.DayOfWeek = (
//        CASE DATENAME(WEEKDAY, a.AttendanceDate)
//            WHEN 'Sunday' THEN N'الأحد'
//            WHEN 'Monday' THEN N'الاثنين'
//            WHEN 'Tuesday' THEN N'الثلاثاء'
//            WHEN 'Wednesday' THEN N'الأربعاء'
//            WHEN 'Thursday' THEN N'الخميس'
//            WHEN 'Friday' THEN N'الجمعة'
//            WHEN 'Saturday' THEN N'السبت'
//        END
//    )
//    LEFT JOIN Shifts sh ON a.ShiftID = sh.ShiftID
//)








        public class AttendanceDataSet : DataSet
        {
            public AttendanceDataSet()
            {
                DataTable dt = new DataTable("AttendanceTable");

                // إضافة الأعمدة
                dt.Columns.AddRange(new DataColumn[] {
            new DataColumn("المعرف", typeof(string)),
            new DataColumn("الاسم", typeof(string)),
            new DataColumn("التاريخ", typeof(DateTime)),
            new DataColumn("يوم الأسبوع", typeof(string)),
            new DataColumn("الحضور الفعلي", typeof(string)),
            new DataColumn("الانصراف الفعلي", typeof(string)),
            new DataColumn("الحالة", typeof(string)),
            new DataColumn("الراتب الشهري", typeof(decimal)),
            new DataColumn("مبلغ الخصم اليومي", typeof(decimal)),
            new DataColumn("إجمالي الخصومات", typeof(decimal)),
            new DataColumn("صافي الراتب", typeof(decimal))
        });

                this.Tables.Add(dt);
            }
        }
    }
}
    //private string GetDisciplinedEmployeesQuery()
    //{
    //    return @"
    //WITH DateRange AS (
    //    SELECT TOP (ABS(DATEDIFF(DAY, @FromDate, @ToDate)) + 1)
    //        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @FromDate) AS Date
    //    FROM sys.objects
    //),
    //AttendanceCTE AS (
    //    SELECT 
    //        e.UserID,
    //        e.Name,
    //        sh.ShiftName,
    //        d.Date AS AttendanceDate,
    //        sh.StartTime AS ScheduledCheckIn,
    //        sh.EndTime AS ScheduledCheckOut,
    //        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
    //        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
    //    FROM Employees e
    //    CROSS JOIN DateRange d
    //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
    //        AND d.Date BETWEEN sc.StartDate AND sc.EndDate
    //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    //    LEFT JOIN Attendance a ON e.UserID = a.UserID 
    //        AND CAST(a.DateTime AS DATE) = d.Date
    //    WHERE e.Enabled = 1
    //        AND (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
    //    GROUP BY e.UserID, e.Name, sh.ShiftName, d.Date, sh.StartTime, sh.EndTime
    //),
    //LeavePermissionCTE AS (
    //    SELECT 
    //        e.UserID,
    //        d.Date AS AttendanceDate,
    //        MAX(CASE WHEN l.LeaveDate = d.Date THEN l.LeaveType END) AS LeaveType,
    //        MAX(CASE WHEN p.PermissionDate = d.Date THEN p.Status END) AS PermissionStatus
    //    FROM Employees e
    //    CROSS JOIN DateRange d
    //    LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = d.Date
    //    LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = d.Date
    //    WHERE @SelectedUserID IS NULL OR e.UserID = @SelectedUserID
    //    GROUP BY e.UserID, d.Date
    //),
    //DiscountCalculation AS (
    //    SELECT 
    //        a.UserID,
    //        a.Name,
    //        a.ShiftName,
    //        a.AttendanceDate,
    //        a.ScheduledCheckIn,
    //        a.ScheduledCheckOut,
    //        a.ActualCheckIn,
    //        a.ActualCheckOut,
    //        COALESCE(d.DiscountAmount, 0) AS DailyDiscount,
    //        SUM(COALESCE(d.DiscountAmount, 0)) OVER (
    //            PARTITION BY a.UserID 
    //            ORDER BY a.AttendanceDate
    //            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
    //        ) AS RunningTotalDiscount,
    //        @SalaryAmount - SUM(COALESCE(d.DiscountAmount, 0)) OVER (
    //            PARTITION BY a.UserID 
    //            ORDER BY a.AttendanceDate
    //            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
    //        ) AS RunningSalaryBalance
    //    FROM AttendanceCTE a
    //    LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.AttendanceDate
    //    LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
    //    LEFT JOIN WorkingDays w ON w.DayOfWeek = (
    //        CASE DATENAME(WEEKDAY, a.AttendanceDate)
    //            WHEN 'Sunday' THEN N'الأحد'
    //            WHEN 'Monday' THEN N'الاثنين'
    //            WHEN 'Tuesday' THEN N'الثلاثاء'
    //            WHEN 'Wednesday' THEN N'الأربعاء'
    //            WHEN 'Thursday' THEN N'الخميس'
    //            WHEN 'Friday' THEN N'الجمعة'
    //            WHEN 'Saturday' THEN N'السبت'
    //        END
    //    )
    //    LEFT JOIN Shifts s ON a.ShiftName = s.ShiftName
    //    LEFT JOIN Discounts d ON
    //        CASE
    //            WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
    //            WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
    //            WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
    //            WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
    //            WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
    //            WHEN (CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) AND
    //                  CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut) THEN N'حاضر'
    //            WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND
    //                 CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
    //            WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND
    //                 a.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'
    //            WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) AND
    //                 CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'حضور متاخر'
    //            WHEN a.ActualCheckIn IS NULL AND CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'لم يسجل حضور'
    //            WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL AND
    //                 CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) AND
    //                 CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
    //            WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut AND
    //                 CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'انصراف مبكر'
    //            ELSE N'غائب'
    //        END = d.ConditionName
    //)
    //SELECT 
    //    dc.UserID AS 'المعرف',
    //    dc.Name AS 'الاسم',
    //    dc.ShiftName AS 'الوردية',
    //    dc.AttendanceDate AS 'التاريخ',
    //    CASE DATENAME(WEEKDAY, dc.AttendanceDate)
    //        WHEN 'Sunday' THEN N'الأحد'
    //        WHEN 'Monday' THEN N'الاثنين'
    //        WHEN 'Tuesday' THEN N'الثلاثاء'
    //        WHEN 'Wednesday' THEN N'الأربعاء'
    //        WHEN 'Thursday' THEN N'الخميس'
    //        WHEN 'Friday' THEN N'الجمعة'
    //        WHEN 'Saturday' THEN N'السبت'
    //    END AS 'يوم الأسبوع',
    //    COALESCE(CONVERT(VARCHAR, CAST(dc.ScheduledCheckIn AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
    //    COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckIn AS TIME), 100), '--') AS 'الحضور الفعلي',
    //    COALESCE(CONVERT(VARCHAR, CAST(dc.ScheduledCheckOut AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
    //    COALESCE(CONVERT(VARCHAR, CAST(dc.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',
    //    CASE
    //        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
    //        WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
    //        WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
    //        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
    //        WHEN dc.ActualCheckIn IS NULL AND dc.ActualCheckOut IS NULL THEN N'غائب'
    //        WHEN (CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
    //              CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut) THEN N'حاضر'
    //        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NULL AND
    //             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
    //        WHEN (dc.ActualCheckIn IS NOT NULL AND CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn)) AND
    //             dc.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'
    //        WHEN CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
    //             CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'حضور متاخر'
    //        WHEN dc.ActualCheckIn IS NULL AND CAST(dc.ActualCheckOut AS TIME) >= dc.ScheduledCheckOut THEN N'لم يسجل حضور'
    //        WHEN dc.ActualCheckIn IS NOT NULL AND dc.ActualCheckOut IS NOT NULL AND
    //             CAST(dc.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) AND
    //             CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
    //        WHEN CAST(dc.ActualCheckOut AS TIME) < dc.ScheduledCheckOut AND
    //             CAST(dc.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, dc.ScheduledCheckIn) THEN N'انصراف مبكر'
    //        ELSE N'غائب'
    //    END AS 'الحالة',
    //    @SalaryAmount AS 'الراتب الشهري',
    //    dc.DailyDiscount AS 'مبلغ الخصم اليومي',
    //    dc.RunningTotalDiscount AS 'إجمالي الخصومات',
    //    dc.RunningSalaryBalance AS 'صافي الراتب'
    //FROM DiscountCalculation dc
    //LEFT JOIN LeavePermissionCTE l ON dc.UserID = l.UserID AND dc.AttendanceDate = l.AttendanceDate
    //LEFT JOIN Holidays h ON h.HolidayDate = dc.AttendanceDate
    //LEFT JOIN WorkingDays w ON w.DayOfWeek = (
    //    CASE DATENAME(WEEKDAY, dc.AttendanceDate)
    //        WHEN 'Sunday' THEN N'الأحد'
    //        WHEN 'Monday' THEN N'الاثنين'
    //        WHEN 'Tuesday' THEN N'الثلاثاء'
    //        WHEN 'Wednesday' THEN N'الأربعاء'
    //        WHEN 'Thursday' THEN N'الخميس'
    //        WHEN 'Friday' THEN N'الجمعة'
    //        WHEN 'Saturday' THEN N'السبت'
    //    END
    //)
    //LEFT JOIN Shifts s ON dc.ShiftName = s.ShiftName
    //ORDER BY 
    //    CASE WHEN @SelectedUserID IS NULL THEN dc.UserID ELSE 1 END,
    //    dc.AttendanceDate,
    //    dc.ShiftName,
    //    dc.Name;";
