using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fingerprint1.view;
namespace Fingerprint1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void الاعداداتالاساسيةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AttendanceAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة حركات الموظفين الي قاعدة البيانات
            AttendanceApp adminPanel = new AttendanceApp();
            adminPanel.Show();
        }

        private void AddZKTecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة الموظفين الى قاعدة البيانات
            AddZKTeco adminPanel = new AddZKTeco();
            adminPanel.Show();
        }

        private void AddEmployeeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة موظف جديد 
            AddEmployeeForm adminPanel = new AddEmployeeForm();
            adminPanel.Show();
        }

        private void ShiftsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة فترات 
            ShiftsForm adminPanel = new ShiftsForm();
            adminPanel.Show();
        }

        private void SchedulesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة ورديات 
            SchedulesForm adminPanel = new SchedulesForm();
            adminPanel.Show();
        }

        private void EmployeeSchedulesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ربط الوارديه بلموظفين 
            EmployeeSchedulesForm adminPanel = new EmployeeSchedulesForm();
            adminPanel.Show();
        }

        

        private void PermissionsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة اذونات
            PermissionsForm adminPanel = new PermissionsForm();
            adminPanel.Show();
        }

        private void LeavesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة الإجازات للموظفين
            LeavesForm adminPanel = new LeavesForm();
            adminPanel.Show();
        }

        private void HolidaysFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //اضافة عطلة رسمية سنوية
            HolidaysForm adminPanel = new HolidaysForm();
            adminPanel.Show();
        }

        private void MonthlyReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //التقرير الشهري
            MonthlyReportForm adminPanel = new MonthlyReportForm();
            adminPanel.Show();
        }

        private void DailyReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //التقرير اليومي
            DailyReportForm adminPanel = new DailyReportForm();
            adminPanel.Show();
        }

        private void DailyAttendanceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //تقرير الحظور اليومي
            DailyAttendanceForm adminPanel = new DailyAttendanceForm();
            adminPanel.Show();
        }

        private void EmployeeAttendanceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //تقرير الحضور والانصراف الشهري للموظف
            EmployeeAttendanceForm adminPanel = new EmployeeAttendanceForm();
            adminPanel.Show();
        }

        private void DisciplinedAttendanceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //تقرير المنضبطين في الحضور الشهري
            DisciplinedAttendanceForm adminPanel = new DisciplinedAttendanceForm();
            adminPanel.Show();
        }

        private void StatisticalReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticalReportForm adminPanel = new StatisticalReportForm();
            adminPanel.Show();
        }

        private void AttendanceSettingsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceStatusForm adminPanel = new AttendanceStatusForm();
            adminPanel.Show();


        }

        private void BonusFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonusForm adminPanel = new BonusForm();
            adminPanel.Show();
        }

        private void DeductionReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //تقرير الخصومات المتوقعة.
            MonthlyReportForm1 adminPanel = new MonthlyReportForm1();
            adminPanel.Show();
        }

        private void DiscountManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //إدارة الخصومات
            DiscountManagement adminPanel = new DiscountManagement();
            adminPanel.Show();
        }

        private void التقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SalaryManagementFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //إدارة الرواتب
            SalaryManagementForm adminPanel = new SalaryManagementForm();
            adminPanel.Show();
        }
    }
}
