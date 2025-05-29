namespace Fingerprint1.view
{
    partial class AddEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeForm));
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnAddEmployee = new Guna.UI.WinForms.GunaButton();
            this.btnEnrollFingerprint = new Guna.UI.WinForms.GunaButton();
            this.btnUpdateEmployee = new Guna.UI.WinForms.GunaButton();
            this.btnDeleteEmployee = new Guna.UI.WinForms.GunaButton();
            this.cmbFingerIndex = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbEmployeeStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCardNumber = new Guna.UI.WinForms.GunaTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbGenderType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI.WinForms.GunaTextBox();
            this.txtFinancialID = new Guna.UI.WinForms.GunaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI.WinForms.GunaTextBox();
            this.txtName = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAge = new Guna.UI.WinForms.GunaTextBox();
            this.txtDepartment = new Guna.UI.WinForms.GunaTextBox();
            this.txtJobTitle = new Guna.UI.WinForms.GunaTextBox();
            this.txtPhone = new Guna.UI.WinForms.GunaTextBox();
            this.txtProtectionType = new Guna.UI.WinForms.GunaTextBox();
            this.cmbPrivilege = new Guna.UI.WinForms.GunaComboBox();
            this.chbEnabled = new Guna.UI.WinForms.GunaCheckBox();
            this.chkUpdateFingerprint = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.lblState = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPort = new Guna.UI.WinForms.GunaTextBox();
            this.txtIP = new Guna.UI.WinForms.GunaTextBox();
            this.btnConnect = new Guna.UI.WinForms.GunaButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 539);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.RowTemplate.Height = 26;
            this.dgvEmployees.Size = new System.Drawing.Size(1322, 246);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellClick);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.AnimationHoverSpeed = 0.07F;
            this.btnAddEmployee.AnimationSpeed = 0.03F;
            this.btnAddEmployee.BaseColor = System.Drawing.Color.Navy;
            this.btnAddEmployee.BorderColor = System.Drawing.Color.Black;
            this.btnAddEmployee.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddEmployee.FocusedColor = System.Drawing.Color.Empty;
            this.btnAddEmployee.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEmployee.Image")));
            this.btnAddEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAddEmployee.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddEmployee.Location = new System.Drawing.Point(913, 468);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnAddEmployee.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAddEmployee.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAddEmployee.OnHoverImage = null;
            this.btnAddEmployee.OnPressedColor = System.Drawing.Color.Black;
            this.btnAddEmployee.Size = new System.Drawing.Size(239, 58);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "اضافة موظف جديد ";
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnEnrollFingerprint
            // 
            this.btnEnrollFingerprint.AnimationHoverSpeed = 0.07F;
            this.btnEnrollFingerprint.AnimationSpeed = 0.03F;
            this.btnEnrollFingerprint.BaseColor = System.Drawing.Color.Navy;
            this.btnEnrollFingerprint.BorderColor = System.Drawing.Color.Black;
            this.btnEnrollFingerprint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEnrollFingerprint.FocusedColor = System.Drawing.Color.Empty;
            this.btnEnrollFingerprint.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollFingerprint.ForeColor = System.Drawing.Color.White;
            this.btnEnrollFingerprint.Image = ((System.Drawing.Image)(resources.GetObject("btnEnrollFingerprint.Image")));
            this.btnEnrollFingerprint.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnEnrollFingerprint.ImageSize = new System.Drawing.Size(40, 40);
            this.btnEnrollFingerprint.Location = new System.Drawing.Point(85, 468);
            this.btnEnrollFingerprint.Name = "btnEnrollFingerprint";
            this.btnEnrollFingerprint.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnEnrollFingerprint.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEnrollFingerprint.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEnrollFingerprint.OnHoverImage = null;
            this.btnEnrollFingerprint.OnPressedColor = System.Drawing.Color.Black;
            this.btnEnrollFingerprint.Size = new System.Drawing.Size(239, 58);
            this.btnEnrollFingerprint.TabIndex = 6;
            this.btnEnrollFingerprint.Text = "تسجيل بصمة ";
            this.btnEnrollFingerprint.Click += new System.EventHandler(this.btnEnrollFingerprint_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.AnimationHoverSpeed = 0.07F;
            this.btnUpdateEmployee.AnimationSpeed = 0.03F;
            this.btnUpdateEmployee.BaseColor = System.Drawing.Color.Navy;
            this.btnUpdateEmployee.BorderColor = System.Drawing.Color.Black;
            this.btnUpdateEmployee.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpdateEmployee.FocusedColor = System.Drawing.Color.Empty;
            this.btnUpdateEmployee.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmployee.ForeColor = System.Drawing.Color.White;
            this.btnUpdateEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateEmployee.Image")));
            this.btnUpdateEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnUpdateEmployee.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUpdateEmployee.Location = new System.Drawing.Point(637, 468);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnUpdateEmployee.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUpdateEmployee.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUpdateEmployee.OnHoverImage = null;
            this.btnUpdateEmployee.OnPressedColor = System.Drawing.Color.Black;
            this.btnUpdateEmployee.Size = new System.Drawing.Size(239, 58);
            this.btnUpdateEmployee.TabIndex = 34;
            this.btnUpdateEmployee.Text = "تعديل موظف موجود";
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.AnimationHoverSpeed = 0.07F;
            this.btnDeleteEmployee.AnimationSpeed = 0.03F;
            this.btnDeleteEmployee.BaseColor = System.Drawing.Color.Navy;
            this.btnDeleteEmployee.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteEmployee.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteEmployee.FocusedColor = System.Drawing.Color.Empty;
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmployee.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteEmployee.Image")));
            this.btnDeleteEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDeleteEmployee.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDeleteEmployee.Location = new System.Drawing.Point(361, 468);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDeleteEmployee.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDeleteEmployee.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDeleteEmployee.OnHoverImage = null;
            this.btnDeleteEmployee.OnPressedColor = System.Drawing.Color.Black;
            this.btnDeleteEmployee.Size = new System.Drawing.Size(239, 58);
            this.btnDeleteEmployee.TabIndex = 35;
            this.btnDeleteEmployee.Text = "حذف موظف";
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbFingerIndex
            // 
            this.cmbFingerIndex.BorderColor = System.Drawing.Color.Empty;
            this.cmbFingerIndex.BorderThickness = 0;
            this.cmbFingerIndex.FillColor = System.Drawing.Color.Empty;
            this.cmbFingerIndex.FocusedColor = System.Drawing.Color.Empty;
            this.cmbFingerIndex.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.cmbFingerIndex.Location = new System.Drawing.Point(28, 317);
            this.cmbFingerIndex.Name = "cmbFingerIndex";
            this.cmbFingerIndex.Size = new System.Drawing.Size(273, 42);
            this.cmbFingerIndex.StartIndex = 0;
            this.cmbFingerIndex.TabIndex = 56;
            this.cmbFingerIndex.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // cmbEmployeeStatus
            // 
            this.cmbEmployeeStatus.BorderColor = System.Drawing.Color.Empty;
            this.cmbEmployeeStatus.BorderThickness = 0;
            this.cmbEmployeeStatus.FillColor = System.Drawing.Color.Empty;
            this.cmbEmployeeStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cmbEmployeeStatus.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.cmbEmployeeStatus.Location = new System.Drawing.Point(28, 127);
            this.cmbEmployeeStatus.Name = "cmbEmployeeStatus";
            this.cmbEmployeeStatus.Size = new System.Drawing.Size(273, 42);
            this.cmbEmployeeStatus.StartIndex = 0;
            this.cmbEmployeeStatus.TabIndex = 54;
            this.cmbEmployeeStatus.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(316, 313);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(123, 36);
            this.label10.TabIndex = 53;
            this.label10.Text = "اختيار الإصبع";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(318, 253);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(118, 36);
            this.label11.TabIndex = 52;
            this.label11.Text = "رقم البطاقة";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BaseColor = System.Drawing.Color.White;
            this.txtCardNumber.BorderColor = System.Drawing.Color.Silver;
            this.txtCardNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCardNumber.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCardNumber.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCardNumber.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCardNumber.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.Location = new System.Drawing.Point(28, 253);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.PasswordChar = '\0';
            this.txtCardNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCardNumber.SelectedText = "";
            this.txtCardNumber.Size = new System.Drawing.Size(273, 44);
            this.txtCardNumber.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(318, 198);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(112, 36);
            this.label12.TabIndex = 50;
            this.label12.Text = "نوع الحماية";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(318, 127);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(128, 36);
            this.label13.TabIndex = 49;
            this.label13.Text = "حالة الموظف";
            // 
            // cmbGenderType
            // 
            this.cmbGenderType.BorderColor = System.Drawing.Color.Empty;
            this.cmbGenderType.BorderThickness = 0;
            this.cmbGenderType.FillColor = System.Drawing.Color.Empty;
            this.cmbGenderType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbGenderType.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.cmbGenderType.Location = new System.Drawing.Point(893, 387);
            this.cmbGenderType.Name = "cmbGenderType";
            this.cmbGenderType.Size = new System.Drawing.Size(273, 42);
            this.cmbGenderType.StartIndex = 0;
            this.cmbGenderType.TabIndex = 48;
            this.cmbGenderType.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(741, 313);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(142, 36);
            this.label5.TabIndex = 47;
            this.label5.Text = "عنوان الموظف";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(741, 253);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(118, 36);
            this.label6.TabIndex = 46;
            this.label6.Text = "الرقم المالي";
            // 
            // txtAddress
            // 
            this.txtAddress.BaseColor = System.Drawing.Color.White;
            this.txtAddress.BorderColor = System.Drawing.Color.Silver;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.FocusedBaseColor = System.Drawing.Color.White;
            this.txtAddress.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtAddress.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddress.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(453, 314);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(273, 44);
            this.txtAddress.TabIndex = 45;
            // 
            // txtFinancialID
            // 
            this.txtFinancialID.BaseColor = System.Drawing.Color.White;
            this.txtFinancialID.BorderColor = System.Drawing.Color.Silver;
            this.txtFinancialID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFinancialID.FocusedBaseColor = System.Drawing.Color.White;
            this.txtFinancialID.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtFinancialID.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFinancialID.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinancialID.Location = new System.Drawing.Point(453, 254);
            this.txtFinancialID.Name = "txtFinancialID";
            this.txtFinancialID.PasswordChar = '\0';
            this.txtFinancialID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFinancialID.SelectedText = "";
            this.txtFinancialID.Size = new System.Drawing.Size(273, 44);
            this.txtFinancialID.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(741, 198);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(80, 36);
            this.label7.TabIndex = 43;
            this.label7.Text = "الهاتف ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(741, 127);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(88, 36);
            this.label8.TabIndex = 42;
            this.label8.Text = "الوظيفة";
            // 
            // txtPassword
            // 
            this.txtPassword.BaseColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPassword.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(893, 198);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(273, 44);
            this.txtPassword.TabIndex = 37;
            // 
            // txtName
            // 
            this.txtName.BaseColor = System.Drawing.Color.White;
            this.txtName.BorderColor = System.Drawing.Color.Silver;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtName.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtName.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(893, 128);
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(273, 44);
            this.txtName.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1194, 136);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(130, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "اسم الموظف";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1194, 215);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(114, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "كلمة المرور";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1190, 269);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(64, 36);
            this.label4.TabIndex = 11;
            this.label4.Text = "العمر ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1194, 341);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(77, 36);
            this.label3.TabIndex = 12;
            this.label3.Text = "القسم ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1194, 393);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(105, 36);
            this.label9.TabIndex = 22;
            this.label9.Text = "نوع الجنس";
            // 
            // txtAge
            // 
            this.txtAge.BaseColor = System.Drawing.Color.White;
            this.txtAge.BorderColor = System.Drawing.Color.Silver;
            this.txtAge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAge.FocusedBaseColor = System.Drawing.Color.White;
            this.txtAge.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtAge.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAge.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(893, 263);
            this.txtAge.Name = "txtAge";
            this.txtAge.PasswordChar = '\0';
            this.txtAge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAge.SelectedText = "";
            this.txtAge.Size = new System.Drawing.Size(273, 44);
            this.txtAge.TabIndex = 38;
            // 
            // txtDepartment
            // 
            this.txtDepartment.BaseColor = System.Drawing.Color.White;
            this.txtDepartment.BorderColor = System.Drawing.Color.Silver;
            this.txtDepartment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartment.FocusedBaseColor = System.Drawing.Color.White;
            this.txtDepartment.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtDepartment.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDepartment.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(893, 324);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.PasswordChar = '\0';
            this.txtDepartment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDepartment.SelectedText = "";
            this.txtDepartment.Size = new System.Drawing.Size(273, 44);
            this.txtDepartment.TabIndex = 39;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.BaseColor = System.Drawing.Color.White;
            this.txtJobTitle.BorderColor = System.Drawing.Color.Silver;
            this.txtJobTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobTitle.FocusedBaseColor = System.Drawing.Color.White;
            this.txtJobTitle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtJobTitle.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtJobTitle.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobTitle.Location = new System.Drawing.Point(453, 128);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.PasswordChar = '\0';
            this.txtJobTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtJobTitle.SelectedText = "";
            this.txtJobTitle.Size = new System.Drawing.Size(273, 44);
            this.txtJobTitle.TabIndex = 40;
            // 
            // txtPhone
            // 
            this.txtPhone.BaseColor = System.Drawing.Color.White;
            this.txtPhone.BorderColor = System.Drawing.Color.Silver;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPhone.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPhone.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPhone.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(453, 198);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(273, 44);
            this.txtPhone.TabIndex = 41;
            // 
            // txtProtectionType
            // 
            this.txtProtectionType.BaseColor = System.Drawing.Color.White;
            this.txtProtectionType.BorderColor = System.Drawing.Color.Silver;
            this.txtProtectionType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProtectionType.FocusedBaseColor = System.Drawing.Color.White;
            this.txtProtectionType.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtProtectionType.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtProtectionType.Font = new System.Drawing.Font("Cairo", 10.8F);
            this.txtProtectionType.Location = new System.Drawing.Point(28, 190);
            this.txtProtectionType.Name = "txtProtectionType";
            this.txtProtectionType.PasswordChar = '\0';
            this.txtProtectionType.SelectedText = "";
            this.txtProtectionType.Size = new System.Drawing.Size(273, 44);
            this.txtProtectionType.TabIndex = 9;
            // 
            // cmbPrivilege
            // 
            this.cmbPrivilege.BackColor = System.Drawing.Color.Transparent;
            this.cmbPrivilege.BaseColor = System.Drawing.Color.White;
            this.cmbPrivilege.BorderColor = System.Drawing.Color.Silver;
            this.cmbPrivilege.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPrivilege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrivilege.FocusedColor = System.Drawing.Color.Empty;
            this.cmbPrivilege.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPrivilege.ForeColor = System.Drawing.Color.Black;
            this.cmbPrivilege.FormattingEnabled = true;
            this.cmbPrivilege.Items.AddRange(new object[] {
            "موظف",
            "مدير"});
            this.cmbPrivilege.Location = new System.Drawing.Point(28, 377);
            this.cmbPrivilege.Name = "cmbPrivilege";
            this.cmbPrivilege.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbPrivilege.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbPrivilege.Size = new System.Drawing.Size(273, 31);
            this.cmbPrivilege.TabIndex = 10;
            // 
            // chbEnabled
            // 
            this.chbEnabled.BaseColor = System.Drawing.Color.White;
            this.chbEnabled.CheckedOffColor = System.Drawing.Color.Gray;
            this.chbEnabled.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chbEnabled.FillColor = System.Drawing.Color.White;
            this.chbEnabled.Font = new System.Drawing.Font("Cairo", 10.8F);
            this.chbEnabled.Location = new System.Drawing.Point(147, 414);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(154, 38);
            this.chbEnabled.TabIndex = 11;
            this.chbEnabled.Text = "مفعل حاله الموظف";
            // 
            // chkUpdateFingerprint
            // 
            this.chkUpdateFingerprint.AutoSize = true;
            this.chkUpdateFingerprint.Font = new System.Drawing.Font("Cairo", 10.8F);
            this.chkUpdateFingerprint.Location = new System.Drawing.Point(474, 418);
            this.chkUpdateFingerprint.Name = "chkUpdateFingerprint";
            this.chkUpdateFingerprint.Size = new System.Drawing.Size(156, 40);
            this.chkUpdateFingerprint.TabIndex = 58;
            this.chkUpdateFingerprint.Text = "تحديث البصمه ";
            this.chkUpdateFingerprint.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(329, 377);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(90, 36);
            this.label14.TabIndex = 59;
            this.label14.Text = "الصلاحيه";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.lblState);
            this.xtraTabPage1.Controls.Add(this.label16);
            this.xtraTabPage1.Controls.Add(this.label15);
            this.xtraTabPage1.Controls.Add(this.txtPort);
            this.xtraTabPage1.Controls.Add(this.txtIP);
            this.xtraTabPage1.Controls.Add(this.btnConnect);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1320, 81);
            this.xtraTabPage1.Text = "xtraTabPage1";
            this.xtraTabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage1_Paint);
            // 
            // lblState
            // 
            this.lblState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(31, 7);
            this.lblState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblState.Name = "lblState";
            this.lblState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblState.Size = new System.Drawing.Size(218, 36);
            this.lblState.TabIndex = 41;
            this.lblState.Text = "الحالة الحالية: غير متصل";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(541, 13);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(117, 36);
            this.label16.TabIndex = 40;
            this.label16.Text = "رقم المنفذ: ";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(964, 12);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(125, 36);
            this.label15.TabIndex = 39;
            this.label15.Text = "عنوان الأيبي:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtPort
            // 
            this.txtPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPort.BaseColor = System.Drawing.Color.White;
            this.txtPort.BorderColor = System.Drawing.Color.Silver;
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPort.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPort.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPort.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtPort.Location = new System.Drawing.Point(380, 7);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.PasswordChar = '\0';
            this.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPort.SelectedText = "";
            this.txtPort.Size = new System.Drawing.Size(132, 55);
            this.txtPort.TabIndex = 38;
            this.txtPort.Text = "4370";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP
            // 
            this.txtIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIP.BaseColor = System.Drawing.Color.White;
            this.txtIP.BorderColor = System.Drawing.Color.Silver;
            this.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIP.FocusedBaseColor = System.Drawing.Color.White;
            this.txtIP.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtIP.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtIP.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtIP.Location = new System.Drawing.Point(719, 7);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChar = '\0';
            this.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIP.SelectedText = "";
            this.txtIP.Size = new System.Drawing.Size(201, 55);
            this.txtIP.TabIndex = 37;
            this.txtIP.Text = "180.180.4.201";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConnect.AnimationHoverSpeed = 0.07F;
            this.btnConnect.AnimationSpeed = 0.03F;
            this.btnConnect.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnConnect.BorderColor = System.Drawing.Color.Black;
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConnect.FocusedColor = System.Drawing.Color.Empty;
            this.btnConnect.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageSize = new System.Drawing.Size(20, 20);
            this.btnConnect.Location = new System.Drawing.Point(1153, 7);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnConnect.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnConnect.OnHoverForeColor = System.Drawing.Color.White;
            this.btnConnect.OnHoverImage = null;
            this.btnConnect.OnPressedColor = System.Drawing.Color.Black;
            this.btnConnect.Size = new System.Drawing.Size(200, 52);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "اتصال ";
            this.btnConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(8);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1322, 119);
            this.xtraTabControl1.TabIndex = 60;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 823);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkUpdateFingerprint);
            this.Controls.Add(this.txtProtectionType);
            this.Controls.Add(this.cmbPrivilege);
            this.Controls.Add(this.chbEnabled);
            this.Controls.Add(this.cmbFingerIndex);
            this.Controls.Add(this.cmbEmployeeStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbGenderType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtFinancialID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnUpdateEmployee);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnrollFingerprint);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.dgvEmployees);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("AddEmployeeForm.IconOptions.Icon")));
            this.Name = "AddEmployeeForm";
            this.Text = "اضافة موظف جديد";
            this.Load += new System.EventHandler(this.AddEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private Guna.UI.WinForms.GunaButton btnAddEmployee;
        private Guna.UI.WinForms.GunaButton btnEnrollFingerprint;
        private Guna.UI.WinForms.GunaButton btnUpdateEmployee;
        private Guna.UI.WinForms.GunaButton btnDeleteEmployee;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFingerIndex;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEmployeeStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Guna.UI.WinForms.GunaTextBox txtCardNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGenderType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaTextBox txtAddress;
        private Guna.UI.WinForms.GunaTextBox txtFinancialID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaTextBox txtPassword;
        private Guna.UI.WinForms.GunaTextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private Guna.UI.WinForms.GunaTextBox txtAge;
        private Guna.UI.WinForms.GunaTextBox txtDepartment;
        private Guna.UI.WinForms.GunaTextBox txtJobTitle;
        private Guna.UI.WinForms.GunaTextBox txtPhone;
        // داخل دالة InitializeComponent في ملف Designer.cs
        private Guna.UI.WinForms.GunaTextBox txtProtectionType;
        private Guna.UI.WinForms.GunaComboBox cmbPrivilege;
        private Guna.UI.WinForms.GunaCheckBox chbEnabled;
        private System.Windows.Forms.CheckBox chkUpdateFingerprint;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private Guna.UI.WinForms.GunaTextBox txtIP;
        private Guna.UI.WinForms.GunaButton btnConnect;
        private System.Windows.Forms.Label label15;
        private Guna.UI.WinForms.GunaTextBox txtPort;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblState;
    }
}