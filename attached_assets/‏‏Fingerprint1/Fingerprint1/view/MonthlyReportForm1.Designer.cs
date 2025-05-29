namespace Fingerprint1.view
{
    partial class MonthlyReportForm1
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyReportForm1));
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtSalary = new Guna.UI.WinForms.GunaTextBox();
            this.gbDeductionSource = new System.Windows.Forms.GroupBox();
            this.rbSalary = new System.Windows.Forms.RadioButton();
            this.rbBonus = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.btnLoad = new Guna.UI.WinForms.GunaButton();
            this.btnExportExcel = new Guna.UI.WinForms.GunaButton();
            this.btnWebPrint = new Guna.UI.WinForms.GunaButton();
            this.btnSalaryReceipt = new Guna.UI.WinForms.GunaButton();
            this.btnDisciplinedReport = new Guna.UI.WinForms.GunaButton();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.cmbEmployee = new Guna.UI.WinForms.GunaComboBox();
            this.btnPrevious = new Guna.UI.WinForms.GunaButton();
            this.btnNext = new Guna.UI.WinForms.GunaButton();
            this.gbDeductionSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Black;
            this.lblFromDate.Location = new System.Drawing.Point(583, 26);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(78, 32);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "من تاريخ:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(689, 23);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(151, 39);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.Black;
            this.lblToDate.Location = new System.Drawing.Point(877, 31);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(78, 32);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "إلى تاريخ:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(986, 26);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(151, 39);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.ForeColor = System.Drawing.Color.Black;
            this.lblEmployee.Location = new System.Drawing.Point(246, 26);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(82, 32);
            this.lblEmployee.TabIndex = 4;
            this.lblEmployee.Text = "الموظف:";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.ForeColor = System.Drawing.Color.Black;
            this.lblSalary.Location = new System.Drawing.Point(6, 26);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(62, 32);
            this.lblSalary.TabIndex = 6;
            this.lblSalary.Text = "المبلغ:";
            // 
            // txtSalary
            // 
            this.txtSalary.BaseColor = System.Drawing.Color.White;
            this.txtSalary.BorderColor = System.Drawing.Color.Silver;
            this.txtSalary.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSalary.FocusedBaseColor = System.Drawing.Color.White;
            this.txtSalary.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtSalary.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSalary.Location = new System.Drawing.Point(75, 24);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.PasswordChar = '\0';
            this.txtSalary.SelectedText = "";
            this.txtSalary.Size = new System.Drawing.Size(152, 37);
            this.txtSalary.TabIndex = 7;
            this.txtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbDeductionSource
            // 
            this.gbDeductionSource.Controls.Add(this.rbSalary);
            this.gbDeductionSource.Controls.Add(this.rbBonus);
            this.gbDeductionSource.Controls.Add(this.rbCustom);
            this.gbDeductionSource.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.gbDeductionSource.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbDeductionSource.Location = new System.Drawing.Point(53, 80);
            this.gbDeductionSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDeductionSource.Name = "gbDeductionSource";
            this.gbDeductionSource.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDeductionSource.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbDeductionSource.Size = new System.Drawing.Size(525, 74);
            this.gbDeductionSource.TabIndex = 8;
            this.gbDeductionSource.TabStop = false;
            this.gbDeductionSource.Text = "مصدر الخصم";
            // 
            // rbSalary
            // 
            this.rbSalary.Checked = true;
            this.rbSalary.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbSalary.Location = new System.Drawing.Point(327, 31);
            this.rbSalary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbSalary.Name = "rbSalary";
            this.rbSalary.Size = new System.Drawing.Size(121, 30);
            this.rbSalary.TabIndex = 0;
            this.rbSalary.TabStop = true;
            this.rbSalary.Text = "من الراتب الأساسي";
            // 
            // rbBonus
            // 
            this.rbBonus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbBonus.Location = new System.Drawing.Point(171, 31);
            this.rbBonus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbBonus.Name = "rbBonus";
            this.rbBonus.Size = new System.Drawing.Size(137, 30);
            this.rbBonus.TabIndex = 1;
            this.rbBonus.Text = "من المكافأة";
            // 
            // rbCustom
            // 
            this.rbCustom.ForeColor = System.Drawing.Color.Black;
            this.rbCustom.Location = new System.Drawing.Point(23, 31);
            this.rbCustom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(121, 30);
            this.rbCustom.TabIndex = 2;
            this.rbCustom.Text = "من المبلغ المحدد";
            // 
            // btnLoad
            // 
            this.btnLoad.AnimationHoverSpeed = 0.07F;
            this.btnLoad.AnimationSpeed = 0.03F;
            this.btnLoad.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLoad.BorderColor = System.Drawing.Color.Black;
            this.btnLoad.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLoad.FocusedColor = System.Drawing.Color.Empty;
            this.btnLoad.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLoad.Location = new System.Drawing.Point(42, 170);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnLoad.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLoad.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLoad.OnHoverImage = null;
            this.btnLoad.OnPressedColor = System.Drawing.Color.Black;
            this.btnLoad.Size = new System.Drawing.Size(190, 57);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "عرض التقرير";
            this.btnLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.AnimationHoverSpeed = 0.07F;
            this.btnExportExcel.AnimationSpeed = 0.03F;
            this.btnExportExcel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExportExcel.BorderColor = System.Drawing.Color.Black;
            this.btnExportExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportExcel.FocusedColor = System.Drawing.Color.Empty;
            this.btnExportExcel.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageSize = new System.Drawing.Size(20, 20);
            this.btnExportExcel.Location = new System.Drawing.Point(278, 170);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnExportExcel.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExportExcel.OnHoverForeColor = System.Drawing.Color.White;
            this.btnExportExcel.OnHoverImage = null;
            this.btnExportExcel.OnPressedColor = System.Drawing.Color.Black;
            this.btnExportExcel.Size = new System.Drawing.Size(190, 57);
            this.btnExportExcel.TabIndex = 12;
            this.btnExportExcel.Text = "تصدير إلى Excel";
            this.btnExportExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnWebPrint
            // 
            this.btnWebPrint.AnimationHoverSpeed = 0.07F;
            this.btnWebPrint.AnimationSpeed = 0.03F;
            this.btnWebPrint.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnWebPrint.BorderColor = System.Drawing.Color.Black;
            this.btnWebPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnWebPrint.FocusedColor = System.Drawing.Color.Empty;
            this.btnWebPrint.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnWebPrint.ForeColor = System.Drawing.Color.White;
            this.btnWebPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnWebPrint.Image")));
            this.btnWebPrint.ImageSize = new System.Drawing.Size(20, 20);
            this.btnWebPrint.Location = new System.Drawing.Point(514, 170);
            this.btnWebPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWebPrint.Name = "btnWebPrint";
            this.btnWebPrint.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnWebPrint.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnWebPrint.OnHoverForeColor = System.Drawing.Color.White;
            this.btnWebPrint.OnHoverImage = null;
            this.btnWebPrint.OnPressedColor = System.Drawing.Color.Black;
            this.btnWebPrint.Size = new System.Drawing.Size(190, 57);
            this.btnWebPrint.TabIndex = 13;
            this.btnWebPrint.Text = "طباعة عبر الويب";
            this.btnWebPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnWebPrint.Click += new System.EventHandler(this.btnWebPrint_Click);
            // 
            // btnSalaryReceipt
            // 
            this.btnSalaryReceipt.AnimationHoverSpeed = 0.07F;
            this.btnSalaryReceipt.AnimationSpeed = 0.03F;
            this.btnSalaryReceipt.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSalaryReceipt.BorderColor = System.Drawing.Color.Black;
            this.btnSalaryReceipt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSalaryReceipt.FocusedColor = System.Drawing.Color.Empty;
            this.btnSalaryReceipt.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSalaryReceipt.ForeColor = System.Drawing.Color.White;
            this.btnSalaryReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnSalaryReceipt.Image")));
            this.btnSalaryReceipt.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSalaryReceipt.Location = new System.Drawing.Point(750, 170);
            this.btnSalaryReceipt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalaryReceipt.Name = "btnSalaryReceipt";
            this.btnSalaryReceipt.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnSalaryReceipt.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSalaryReceipt.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSalaryReceipt.OnHoverImage = null;
            this.btnSalaryReceipt.OnPressedColor = System.Drawing.Color.Black;
            this.btnSalaryReceipt.Size = new System.Drawing.Size(190, 57);
            this.btnSalaryReceipt.TabIndex = 14;
            this.btnSalaryReceipt.Text = "سند صرف";
            this.btnSalaryReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSalaryReceipt.Click += new System.EventHandler(this.BtnSalaryReceipt_Click);
            // 
            // btnDisciplinedReport
            // 
            this.btnDisciplinedReport.AnimationHoverSpeed = 0.07F;
            this.btnDisciplinedReport.AnimationSpeed = 0.03F;
            this.btnDisciplinedReport.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDisciplinedReport.BorderColor = System.Drawing.Color.Black;
            this.btnDisciplinedReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDisciplinedReport.FocusedColor = System.Drawing.Color.Empty;
            this.btnDisciplinedReport.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDisciplinedReport.ForeColor = System.Drawing.Color.White;
            this.btnDisciplinedReport.Image = ((System.Drawing.Image)(resources.GetObject("btnDisciplinedReport.Image")));
            this.btnDisciplinedReport.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDisciplinedReport.Location = new System.Drawing.Point(986, 170);
            this.btnDisciplinedReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisciplinedReport.Name = "btnDisciplinedReport";
            this.btnDisciplinedReport.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDisciplinedReport.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDisciplinedReport.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDisciplinedReport.OnHoverImage = null;
            this.btnDisciplinedReport.OnPressedColor = System.Drawing.Color.Black;
            this.btnDisciplinedReport.Size = new System.Drawing.Size(190, 59);
            this.btnDisciplinedReport.TabIndex = 15;
            this.btnDisciplinedReport.Text = "تقرير المتضبطين";
            this.btnDisciplinedReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDisciplinedReport.Click += new System.EventHandler(this.btnDisciplinedReport_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.dgvReport.ColumnHeadersHeight = 29;
            this.dgvReport.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dgvReport.Location = new System.Drawing.Point(20, 266);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(1206, 477);
            this.dgvReport.TabIndex = 16;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.BackColor = System.Drawing.Color.Transparent;
            this.cmbEmployee.BaseColor = System.Drawing.Color.White;
            this.cmbEmployee.BorderColor = System.Drawing.Color.Silver;
            this.cmbEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FocusedColor = System.Drawing.Color.Empty;
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmployee.ForeColor = System.Drawing.Color.Black;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(334, 27);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbEmployee.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbEmployee.Size = new System.Drawing.Size(217, 31);
            this.cmbEmployee.TabIndex = 17;
            this.cmbEmployee.Click += new System.EventHandler(this.CmbEmployee_SelectedIndexChanged);
            // 
            // btnPrevious
            // 
            this.btnPrevious.AnimationHoverSpeed = 0.07F;
            this.btnPrevious.AnimationSpeed = 0.03F;
            this.btnPrevious.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnPrevious.BorderColor = System.Drawing.Color.Black;
            this.btnPrevious.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FocusedColor = System.Drawing.Color.Empty;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Image = null;
            this.btnPrevious.ImageSize = new System.Drawing.Size(20, 20);
            this.btnPrevious.Location = new System.Drawing.Point(129, 234);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnPrevious.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPrevious.OnHoverForeColor = System.Drawing.Color.White;
            this.btnPrevious.OnHoverImage = null;
            this.btnPrevious.OnPressedColor = System.Drawing.Color.Black;
            this.btnPrevious.Size = new System.Drawing.Size(50, 30);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.AnimationHoverSpeed = 0.07F;
            this.btnNext.AnimationSpeed = 0.03F;
            this.btnNext.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnNext.BorderColor = System.Drawing.Color.Black;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNext.Enabled = false;
            this.btnNext.FocusedColor = System.Drawing.Color.Empty;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = null;
            this.btnNext.ImageSize = new System.Drawing.Size(20, 20);
            this.btnNext.Location = new System.Drawing.Point(62, 234);
            this.btnNext.Name = "btnNext";
            this.btnNext.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnNext.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnNext.OnHoverForeColor = System.Drawing.Color.White;
            this.btnNext.OnHoverImage = null;
            this.btnNext.OnPressedColor = System.Drawing.Color.Black;
            this.btnNext.Size = new System.Drawing.Size(50, 30);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">>";
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // MonthlyReportForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1251, 945);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.gbDeductionSource);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnWebPrint);
            this.Controls.Add(this.btnSalaryReceipt);
            this.Controls.Add(this.btnDisciplinedReport);
            this.Controls.Add(this.dgvReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MonthlyReportForm1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "التقرير الشهري";
            this.gbDeductionSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblSalary;
        private Guna.UI.WinForms.GunaTextBox txtSalary;
        private System.Windows.Forms.GroupBox gbDeductionSource;
        private System.Windows.Forms.RadioButton rbSalary;
        private System.Windows.Forms.RadioButton rbBonus;
        private System.Windows.Forms.RadioButton rbCustom;
        private Guna.UI.WinForms.GunaButton btnLoad;
        private Guna.UI.WinForms.GunaButton btnExportExcel;
        private Guna.UI.WinForms.GunaButton btnWebPrint;
        private Guna.UI.WinForms.GunaButton btnSalaryReceipt;
        private Guna.UI.WinForms.GunaButton btnDisciplinedReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private Guna.UI.WinForms.GunaComboBox cmbEmployee;
        private Guna.UI.WinForms.GunaButton btnNext;
        private Guna.UI.WinForms.GunaButton btnPrevious;
    }
}

