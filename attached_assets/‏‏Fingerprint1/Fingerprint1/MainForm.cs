using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Fingerprint1.view;
namespace Fingerprint1
{
    public partial class MainForm : Form
    {
        private Panel mainPanel = new Panel();
        private Panel sidePanel = new Panel();
        private Panel headerPanel = new Panel();
        private List<Button> menuButtons;
        private Button homeButton;

        public MainForm()
        {
            //InitializeComponent();

            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit(); // إضافة هذا السطر
            SetupForm();
            CreatePanels();
            CreateMenuButtons();
        }

        private void SetupForm()
        {
            this.WindowState = FormWindowState.Maximized;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.Sizable; // لإظهار أزرار التحكم
        }

        private void CreatePanels()
        {
            // إنشاء لوحة الهيدر
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(31, 30, 68)
            };
            this.Controls.Add(headerPanel);

            // إضافة شعار في الهيدر
            Label logo = new Label
            {
                Text = "نظام إدارة الحضور",
                Font = new Font("Tajawal", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            headerPanel.Controls.Add(logo);

            // إنشاء القائمة الجانبية
            sidePanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                BackColor = Color.FromArgb(31, 30, 68),
                Padding = new Padding(10)
            };
            this.Controls.Add(sidePanel);

            // إضافة تأثير التدرج اللوني
            sidePanel.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    sidePanel.ClientRectangle,
                    Color.FromArgb(31, 30, 68),
                    Color.FromArgb(10, 10, 10),
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, sidePanel.ClientRectangle);
                }
            };

            // إنشاء زر الصفحة الرئيسية
            homeButton = new Button
            {
                Text = "الصفحة الرئيسية",
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Tajawal", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Height = 50,
                Width = sidePanel.Width - 20,
                Top = 10,
                Left = 10,
                Cursor = Cursors.Hand,
                Padding = new Padding(10, 0, 10, 0),
                ImageAlign = ContentAlignment.MiddleLeft,
                FlatAppearance = { BorderSize = 0 }
            };

            // تأثيرات التمرير لزر الصفحة الرئيسية
            homeButton.MouseEnter += (s, e) =>
            {
                homeButton.BackColor = Color.FromArgb(50, 48, 90);
                homeButton.ForeColor = Color.FromArgb(0, 173, 181);
            };

            homeButton.MouseLeave += (s, e) =>
            {
                homeButton.BackColor = Color.Transparent;
                homeButton.ForeColor = Color.White;
            };

            homeButton.Click += HomeButton_Click;
            sidePanel.Controls.Add(homeButton);

            // إنشاء اللوحة الرئيسية
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 240),
                Padding = new Padding(20)
            };
            this.Controls.Add(mainPanel);
            mainPanel.BringToFront();
        }

        private void CreateMenuButtons()
        {
            menuButtons = new List<Button>();
            var menuStructure = new Dictionary<string, List<string>>
            {
                { "إدارة الموظفين", new List<string> { "إضافة موظف جديد", "قائمة الموظفين", "إدارة الرواتب", "إدارة الخصومات" } },
                { "إدارة الدوام", new List<string> { "توقيت المدة الزمنيه لجهاز البصمه","إضافة فترات", "إضافة ورديات", "ربط الورديات بالموظفين", "العطل الرسمية" } },
                { "الإجازات والأذونات", new List<string> { "إضافة إجازة", "إضافة إذن", "عرض الإجازات والأذونات" } },
                { "الحضور والانصراف", new List<string> { "تسجيل الحضور والانصراف يدوي", "تسجيل الحضور والانصراف", "عرض حركات الموظفين" } },
                { "التقارير", new List<string> { "التقرير اليومي", "تقرير الحضور اليومي", "التقرير الشهري", "تقرير الحضور الشهري للموظف", "تقرير المنضبطين", "تقرير الخصومات المتوقعة" } }
            };

            int yPosition = homeButton.Bottom + 10; // بدء الأزرار بعد زر الصفحة الرئيسية

            foreach (var menu in menuStructure)
            {
                Button mainButton = CreateMainMenuButton(menu.Key, yPosition);
                sidePanel.Controls.Add(mainButton);
                menuButtons.Add(mainButton);
                yPosition += mainButton.Height + 5;

                Panel submenuPanel = new Panel
                {
                    BackColor = Color.FromArgb(40, 39, 80),
                    Width = sidePanel.Width,
                    Height = 0,
                    Left = 0,
                    Top = yPosition,
                    Visible = false
                };
                sidePanel.Controls.Add(submenuPanel);

                foreach (var submenu in menu.Value)
                {
                    Button subButton = CreateSubMenuButton(submenu);
                    submenuPanel.Controls.Add(subButton);
                    subButton.Top = submenuPanel.Controls.Count * (subButton.Height + 2) - subButton.Height;
                }

                mainButton.Tag = submenuPanel;
                mainButton.Click += (s, e) => ToggleSubmenu(mainButton);
            }
        }

        private Button CreateMainMenuButton(string text, int top)
        {
            Button btn = new Button
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Tajawal", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Height = 50,
                Width = sidePanel.Width - 20,
                Top = top,
                Left = 10,
                Cursor = Cursors.Hand,
                Padding = new Padding(10, 0, 10, 0),
                ImageAlign = ContentAlignment.MiddleLeft,
                FlatAppearance = { BorderSize = 0 }
            };

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(50, 48, 90);
                btn.ForeColor = Color.FromArgb(0, 173, 181);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
            };

            return btn;
        }

        private Button CreateSubMenuButton(string text)
        {
            Button btn = new Button
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Tajawal", 10, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Height = 40,
                Width = sidePanel.Width - 30,
                Left = 10,
                Cursor = Cursors.Hand,
                Padding = new Padding(10, 0, 10, 0),
                ImageAlign = ContentAlignment.MiddleLeft,
                FlatAppearance = { BorderSize = 0 }
            };

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(50, 48, 90);
                btn.ForeColor = Color.FromArgb(0, 173, 181);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
            };

            btn.Click += SubMenu_Click;
            return btn;
        }

        private void ToggleSubmenu(Button mainButton)
        {
            Panel submenuPanel = mainButton.Tag as Panel;
            if (submenuPanel != null)
            {
                if (submenuPanel.Visible)
                {
                    submenuPanel.Visible = false;
                    mainButton.BackColor = Color.Transparent;
                }
                else
                {
                    foreach (Button btn in menuButtons)
                    {
                        if (btn != mainButton && btn.Tag is Panel panel)
                        {
                            panel.Visible = false;
                            btn.BackColor = Color.Transparent;
                        }
                    }
                    submenuPanel.Height = submenuPanel.Controls.Count * 42;
                    submenuPanel.Visible = true;
                    mainButton.BackColor = Color.FromArgb(50, 48, 90);
                }
            }
        }

        private void SubMenu_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            OpenFormByName(clickedButton.Text);
        }

        private void OpenFormByName(string formName)
        {
            Form form = GetFormByName(formName);
            if (form != null)
            {
                OpenForm(form);
            }
        }

        private Form GetFormByName(string formName)
        {
            switch (formName)
            {

                case "إضافة موظف جديد": return new AddEmployeeForm();
                // case "قائمة الموظفين": return new EmployeeListForm();
                case "إدارة الرواتب": return new SalaryManagementForm();
                case "إدارة الخصومات": return new DiscountManagement();
                case "إضافة فترات": return new ShiftsForm();
                case "إضافة ورديات": return new SchedulesForm();
                case "ربط الورديات بالموظفين": return new EmployeeSchedulesForm();
                case "توقيت المدة الزمنيه لجهاز البصمه": return new SetGroupTZApp();




                case "العطل الرسمية": return new HolidaysForm();
                case "إضافة إجازة": return new LeavesForm();
                case "إضافة إذن": return new PermissionsForm();
                case "تسجيل الحضور والانصراف": return new AttendanceApp();
                case "تسجيل الحضور والانصراف يدوي": return new ManualAttendanceForm();
                case "التقرير اليومي": return new DailyReportForm();
                case "تقرير الحضور اليومي": return new DailyAttendanceForm();
                //  case "التقرير الشهري": return new MonthlyReportForm();
                case "التقرير الشهري": return new AttendanceReportForm();
                case "تقرير الحضور الشهري للموظف": return new EmployeeAttendanceForm();
                case "تقرير المنضبطين": return new DisciplinedAttendanceForm();
                case "تقرير الخصومات المتوقعة": return new MonthlyReportForm1();
                default: return null;
            }
        }

        private void OpenForm(Form form)
        {
            foreach (Control ctrl in mainPanel.Controls)
            {
                ctrl.Dispose();
            }
            mainPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.BackColor = Color.White;
            mainPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            // مسح المحتويات الحالية وإظهار الصفحة الرئيسية المخصصة
            foreach (Control ctrl in mainPanel.Controls)
            {
                ctrl.Dispose();
            }
            mainPanel.Controls.Clear();

            // إضافة محتوى الصفحة الرئيسية (بدون إعادة إنشاء الهيدر أو القائمة الجانبية)
            Label welcomeLabel = new Label
            {
               // Text = "مرحبًا في نظام إدارة الحضور",
                Font = new Font("Tajawal", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 30, 68),
                AutoSize = true,
                Location = new Point(50, 50)
            };
            mainPanel.Controls.Add(welcomeLabel);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (mainPanel.Controls.Count > 0 && mainPanel.Controls[0] is Form currentForm)
            {
                int minWidth = Math.Max(mainPanel.Width - 40, 100);
                int minHeight = Math.Max(mainPanel.Height - 40, 100);
                currentForm.MinimumSize = new Size(minWidth, minHeight);
            }
        }
    }
}