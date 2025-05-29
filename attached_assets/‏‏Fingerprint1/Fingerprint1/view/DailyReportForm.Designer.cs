using System.Windows.Forms;

namespace Fingerprint1.view
{
    partial class DailyReportForm
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
        /// </summary>InitializeControls
        //private void InitializeComponent()
        //{
        //    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        //    this.DailyReportForm1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        //    this.menuStrip1.SuspendLayout();
        //    this.SuspendLayout();
        //    // 
        //    // menuStrip1
        //    // 
        //    this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        //    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        //    this.DailyReportForm1ToolStripMenuItem});
        //    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        //    this.menuStrip1.Name = "menuStrip1";
        //    this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        //    this.menuStrip1.Size = new System.Drawing.Size(800, 28);
        //    this.menuStrip1.TabIndex = 0;
        //    this.menuStrip1.Text = "menuStrip1";
        //    // 
        //    // DailyReportForm1ToolStripMenuItem
        //    // 
        //    this.DailyReportForm1ToolStripMenuItem.Name = "DailyReportForm1ToolStripMenuItem";
        //    this.DailyReportForm1ToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
        //    this.DailyReportForm1ToolStripMenuItem.Text = "تقرير 1";
        //    this.DailyReportForm1ToolStripMenuItem.Click += new System.EventHandler(this.DailyReportForm1ToolStripMenuItem_Click);
        //    // 
        //    // DailyReportForm
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Controls.Add(this.menuStrip1);
        //    this.MainMenuStrip = this.menuStrip1;
        //    this.Name = "DailyReportForm";
        //    this.Text = "DailyReportForm";
        //    this.menuStrip1.ResumeLayout(false);
        //    this.menuStrip1.PerformLayout();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyReportForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new Guna.UI.WinForms.GunaButton();
            this.btnExportExcel = new Guna.UI.WinForms.GunaButton();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnExportPDF = new Guna.UI.WinForms.GunaButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DailyReportForm1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDate.Font = new System.Drawing.Font("Cairo", 10F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(155, 50);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(214, 39);
            this.dtpDate.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerate.AnimationHoverSpeed = 0.07F;
            this.btnGenerate.AnimationSpeed = 0.03F;
            this.btnGenerate.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGenerate.BorderColor = System.Drawing.Color.Black;
            this.btnGenerate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGenerate.FocusedColor = System.Drawing.Color.Empty;
            this.btnGenerate.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerate.Image")));
            this.btnGenerate.ImageSize = new System.Drawing.Size(20, 20);
            this.btnGenerate.Location = new System.Drawing.Point(154, 102);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnGenerate.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnGenerate.OnHoverForeColor = System.Drawing.Color.White;
            this.btnGenerate.OnHoverImage = null;
            this.btnGenerate.OnPressedColor = System.Drawing.Color.Black;
            this.btnGenerate.Size = new System.Drawing.Size(215, 57);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "عرض التقرير ";
            this.btnGenerate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnExportExcel.Location = new System.Drawing.Point(447, 102);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnExportExcel.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExportExcel.OnHoverForeColor = System.Drawing.Color.White;
            this.btnExportExcel.OnHoverImage = null;
            this.btnExportExcel.OnPressedColor = System.Drawing.Color.Black;
            this.btnExportExcel.Size = new System.Drawing.Size(215, 57);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "تصدير Excel ";
            this.btnExportExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReport.ColumnHeadersHeight = 29;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(81)))));
            this.dgvReport.Location = new System.Drawing.Point(0, 190);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(1182, 363);
            this.dgvReport.TabIndex = 4;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportPDF.AnimationHoverSpeed = 0.07F;
            this.btnExportPDF.AnimationSpeed = 0.03F;
            this.btnExportPDF.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExportPDF.BorderColor = System.Drawing.Color.Black;
            this.btnExportPDF.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportPDF.FocusedColor = System.Drawing.Color.Empty;
            this.btnExportPDF.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.Image")));
            this.btnExportPDF.ImageSize = new System.Drawing.Size(20, 20);
            this.btnExportPDF.Location = new System.Drawing.Point(740, 102);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnExportPDF.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExportPDF.OnHoverForeColor = System.Drawing.Color.White;
            this.btnExportPDF.OnHoverImage = null;
            this.btnExportPDF.OnPressedColor = System.Drawing.Color.Black;
            this.btnExportPDF.Size = new System.Drawing.Size(215, 57);
            this.btnExportPDF.TabIndex = 10;
            this.btnExportPDF.Text = "طباعة التقرير ";
            this.btnExportPDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExportPDF.Click += new System.EventHandler(this.BtnExportPDF_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DailyReportForm1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1182, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DailyReportForm1ToolStripMenuItem
            // 
            this.DailyReportForm1ToolStripMenuItem.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.DailyReportForm1ToolStripMenuItem.Name = "DailyReportForm1ToolStripMenuItem";
            this.DailyReportForm1ToolStripMenuItem.Size = new System.Drawing.Size(70, 36);
            this.DailyReportForm1ToolStripMenuItem.Text = "تقرير 1";
            this.DailyReportForm1ToolStripMenuItem.Click += new System.EventHandler(this.DailyReportForm1ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(33, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "اختار التاريخ";
            // 
            // DailyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dgvReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DailyReportForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "التقرير اليومي للحضور والانصراف";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private MenuStrip menuStrip1;
        private ToolStripMenuItem DailyReportForm1ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private Guna.UI.WinForms.GunaButton btnGenerate;
        private Guna.UI.WinForms.GunaButton btnExportExcel;
        private System.Windows.Forms.DataGridView dgvReport;
        private Guna.UI.WinForms.GunaButton btnExportPDF;
        private Label label1;
    }
    #endregion
}




