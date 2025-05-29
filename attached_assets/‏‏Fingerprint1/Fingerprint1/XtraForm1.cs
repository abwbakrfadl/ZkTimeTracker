using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


    using DevExpress.XtraBars.Navigation;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using System.ComponentModel;
    using System.Data;
    using System.Windows.Forms;
   
  

namespace Fingerprint1
{
    public partial class XtraForm1 :Form
    {
    
      
            private Panel sideMenuPanel;
            private Button toggleMenuButton;
            private Panel contentPanel;
            private int sideMenuWidthCollapsed = 50;
            private int sideMenuWidthExpanded = 200;
            private bool isMenuCollapsed = false;

            public XtraForm1()
            {
                InitializeComponent();
                InitializeCustomLayout();
            }

            private void InitializeComponent()
            {
                this.sideMenuPanel = new System.Windows.Forms.Panel();
                this.toggleMenuButton = new System.Windows.Forms.Button();
                this.contentPanel = new System.Windows.Forms.Panel();
                this.SuspendLayout();
                //
                // sideMenuPanel
                //
                this.sideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Right;
                this.sideMenuPanel.Location = new System.Drawing.Point(600, 0);
                this.sideMenuPanel.Name = "sideMenuPanel";
                this.sideMenuPanel.Size = new System.Drawing.Size(200, 450);
                this.sideMenuPanel.TabIndex = 0;
                //
                // toggleMenuButton
                //
                this.toggleMenuButton.Location = new System.Drawing.Point(12, 12);
                this.toggleMenuButton.Name = "toggleMenuButton";
                this.toggleMenuButton.Size = new System.Drawing.Size(40, 30);
                this.toggleMenuButton.TabIndex = 1;
                this.toggleMenuButton.Text = "«";
                this.toggleMenuButton.UseVisualStyleBackColor = true;
                this.toggleMenuButton.Click += new System.EventHandler(this.toggleMenuButton_Click);
                //
                // contentPanel
                //
                this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                this.contentPanel.Location = new System.Drawing.Point(0, 0);
                this.contentPanel.Name = "contentPanel";
                this.contentPanel.Size = new System.Drawing.Size(600, 450);
                this.contentPanel.TabIndex = 2;
                //
                // MainForm
                //
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.toggleMenuButton);
                this.Controls.Add(this.contentPanel);
                this.Controls.Add(this.sideMenuPanel);
                this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                this.RightToLeftLayout = true;
                this.Name = "MainForm";
                this.Text = "لوحة التحكم";
                this.ResumeLayout(false);

            }

            private void InitializeCustomLayout()
            {
                // إضافة عناصر القائمة الجانبية (أزرار أو Label) وتنسيقها
                Button dashboardButton = CreateSideMenuButton("لوحة التحكم الرئيسية");
                dashboardButton.Location = new Point(10, 50);
                this.sideMenuPanel.Controls.Add(dashboardButton);

                Button usersButton = CreateSideMenuButton("المستخدمين");
                usersButton.Location = new Point(10, 90);
                this.sideMenuPanel.Controls.Add(usersButton);

                // ... إضافة المزيد من أزرار القائمة

                // إضافة عناصر أخرى إلى contentPanel (مربعات المعلومات، جدول، إلخ.)
                Panel infoBox1 = CreateInfoBox("إجمالي العملاء", "125");
                infoBox1.Location = new Point(20, 20);
                this.contentPanel.Controls.Add(infoBox1);

                // ... إضافة المزيد من العناصر

                this.sideMenuPanel.Width = sideMenuWidthExpanded; // تعيين العرض الأولي
            }

            private Button CreateSideMenuButton(string text)
            {
                Button button = new Button();
                button.Text = text;
                button.Width = this.sideMenuPanel.Width - 20;
                button.Height = 40;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.TextAlign = ContentAlignment.MiddleRight;
                button.ForeColor = Color.White;
                button.BackColor = Color.Transparent;
                return button;
            }

            private Panel CreateInfoBox(string title, string value)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Size = new Size(150, 80);

                Label titleLabel = new Label();
                titleLabel.Text = title;
                titleLabel.TextAlign = ContentAlignment.MiddleCenter;
                titleLabel.Dock = DockStyle.Top;
                panel.Controls.Add(titleLabel);

                Label valueLabel = new Label();
                valueLabel.Text = value;
                valueLabel.Font = new Font(valueLabel.Font.FontFamily, 16, FontStyle.Bold);
                valueLabel.TextAlign = ContentAlignment.MiddleCenter;
                valueLabel.Dock = DockStyle.Bottom;
                panel.Controls.Add(valueLabel);

                return panel;
            }

            private void toggleMenuButton_Click(object sender, EventArgs e)
            {
                if (isMenuCollapsed)
                {
                    sideMenuPanel.Width = sideMenuWidthExpanded;
                    toggleMenuButton.Text = "«";
                    contentPanel.Dock = DockStyle.Fill;
                }
                else
                {
                    sideMenuPanel.Width = sideMenuWidthCollapsed;
                    toggleMenuButton.Text = "»";
                    contentPanel.Dock = DockStyle.Fill; // قد تحتاج إلى تعديل حسب التخطيط
                }
                isMenuCollapsed = !isMenuCollapsed;
            }
        }
    }


    //public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    //{
    //    private Panel sidePanel;
    //    private Panel mainPanel;
    //    private DataGridView employeesGrid;
    //    private Button addEmployeeBtn;
    //    private Label totalEmployeesLabel;
    //    private Label presentTodayLabel;
    //    private Label newRequestsLabel;
    //    private Label absentTodayLabel;

//    public XtraForm1()
//    {
//        InitializeComponent();
//        InitializeUI();
//    }

//    private void InitializeComponent()
//    {
//        this.Text = "نظام الموارد البشرية";
//        this.RightToLeft = RightToLeft.Yes;
//        this.RightToLeftLayout = true;
//        this.Size = new Size(1200, 800);
//        this.StartPosition = FormStartPosition.CenterScreen;

//        // Initialize panels
//        sidePanel = new Panel
//        {
//            Dock = DockStyle.Right,
//            Width = 200,
//            BackColor = Color.FromArgb(51, 51, 76)
//        };

//        mainPanel = new Panel
//        {
//            Dock = DockStyle.Fill,
//            BackColor = Color.White
//        };

//        // Stats cards
//        var statsPanel = new FlowLayoutPanel
//        {
//            Dock = DockStyle.Top,
//            Height = 100,
//            Padding = new Padding(10),
//            BackColor = Color.White
//        };

//        totalEmployeesLabel = CreateStatsCard("إجمالي الموظفين", "125", Color.FromArgb(0, 123, 255));
//        presentTodayLabel = CreateStatsCard("الحاضرون اليوم", "112", Color.FromArgb(40, 167, 69));
//        absentTodayLabel = CreateStatsCard("الغائبون اليوم", "8", Color.FromArgb(220, 53, 69));
//        newRequestsLabel = CreateStatsCard("طلبات الإجازة الجديدة", "5", Color.FromArgb(255, 193, 7));

//        statsPanel.Controls.AddRange(new Control[] { totalEmployeesLabel, presentTodayLabel, absentTodayLabel, newRequestsLabel });

//        // Grid setup
//        employeesGrid = new DataGridView
//        {
//            Dock = DockStyle.Fill,
//            BackgroundColor = Color.White,
//            BorderStyle = BorderStyle.None,
//            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
//            AllowUserToAddRows = false,
//            RightToLeft = RightToLeft.Yes,
//            MultiSelect = false,
//            SelectionMode = DataGridViewSelectionMode.FullRowSelect
//        };

//        employeesGrid.Columns.AddRange(new DataGridViewColumn[]
//        {
//            new DataGridViewTextBoxColumn { Name = "Employee", HeaderText = "الموظف", DataPropertyName = "Employee" },
//            new DataGridViewTextBoxColumn { Name = "EmpId", HeaderText = "الرقم الوظيفي", DataPropertyName = "EmpId" },
//            new DataGridViewTextBoxColumn { Name = "Department", HeaderText = "القسم", DataPropertyName = "Department" },
//            new DataGridViewTextBoxColumn { Name = "JobTitle", HeaderText = "المسمى الوظيفي", DataPropertyName = "JobTitle" },
//            new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "رقم الهاتف", DataPropertyName = "Phone" },
//            new DataGridViewTextBoxColumn { Name = "HireDate", HeaderText = "تاريخ التعيين", DataPropertyName = "HireDate" },
//            new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "الحالة", DataPropertyName = "Status" },
//            new DataGridViewButtonColumn { Name = "Actions", HeaderText = "الإجراءات", Text = "تعديل", UseColumnTextForButtonValue = true }
//        });

//        // Add Employee Button
//        addEmployeeBtn = new Button
//        {
//            Text = "إضافة موظف",
//            BackColor = Color.FromArgb(0, 123, 255),
//            ForeColor = Color.White,
//            Dock = DockStyle.Top,
//            Height = 40,
//            Font = new Font("Segoe UI", 10, FontStyle.Regular),
//            FlatStyle = FlatStyle.Flat
//        };
//        addEmployeeBtn.Click += AddEmployeeBtn_Click;

//        // Layout
//        mainPanel.Controls.Add(employeesGrid);
//        mainPanel.Controls.Add(statsPanel);
//        mainPanel.Controls.Add(addEmployeeBtn);

//        this.Controls.Add(mainPanel);
//        this.Controls.Add(sidePanel);

//        LoadSampleData();
//    }

//    private Label CreateStatsCard(string title, string value, Color color)
//    {
//        var card = new Label
//        {
//            Text = $"{title}\n{value}",
//            TextAlign = ContentAlignment.MiddleCenter,
//            AutoSize = false,
//            Size = new Size(200, 80),
//            Margin = new Padding(10),
//            BackColor = color,
//            ForeColor = Color.White,
//            Font = new Font("Segoe UI", 12, FontStyle.Bold)
//        };
//        return card;
//    }

//    private void LoadSampleData()
//    {
//        var dt = new DataTable();
//        dt.Columns.AddRange(new DataColumn[]
//        {
//            new DataColumn("Employee", typeof(string)),
//            new DataColumn("EmpId", typeof(string)),
//            new DataColumn("Department", typeof(string)),
//            new DataColumn("JobTitle", typeof(string)),
//            new DataColumn("Phone", typeof(string)),
//            new DataColumn("HireDate", typeof(string)),
//            new DataColumn("Status", typeof(string))
//        });

//        dt.Rows.Add("أحمد محمد علي", "EMP001", "تطوير البرمجيات", "مطور برمجيات", "0512345678", "01/01/2023", "نشط");
//        dt.Rows.Add("سارة أحمد محمود", "EMP002", "الموارد البشرية", "أخصائي موارد بشرية", "0512345679", "15/01/2023", "في إجازة");
//        dt.Rows.Add("محمد عبدالله", "EMP003", "المالية", "محاسب", "0512345680", "01/02/2023", "نشط");

//        employeesGrid.DataSource = dt;
//    }

//    private void AddEmployeeBtn_Click(object sender, EventArgs e)
//    {
//        //var addEmployeeForm = new AddEmployeeForm();
//        //if (addEmployeeForm.ShowDialog() == DialogResult.OK)
//        //{
//        //    LoadSampleData(); // Refresh the grid after adding new employee
//        //}
//    }

//    private void InitializeUI()
//    {
//        // Additional UI initialization if needed
//    }

//    //[STAThread]
//    //static void Main()
//    //{
//    //    Application.EnableVisualStyles();
//    //    Application.SetCompatibleTextRenderingDefault(false);
//    //    Application.Run(new MainForm());
//    //}
//}