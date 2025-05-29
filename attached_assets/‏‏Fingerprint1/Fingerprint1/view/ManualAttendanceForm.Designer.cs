namespace Fingerprint1.view
{
    partial class ManualAttendanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualAttendanceForm));
            this.cmbEmployees = new Guna.UI.WinForms.GunaComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new Guna.UI.WinForms.GunaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInOutMode = new Guna.UI.WinForms.GunaComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVerificationMode = new Guna.UI.WinForms.GunaComboBox();
            this.SuspendLayout();
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.BackColor = System.Drawing.Color.Transparent;
            this.cmbEmployees.BaseColor = System.Drawing.Color.White;
            this.cmbEmployees.BorderColor = System.Drawing.Color.Silver;
            this.cmbEmployees.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployees.FocusedColor = System.Drawing.Color.Empty;
            this.cmbEmployees.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmployees.ForeColor = System.Drawing.Color.Black;
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(456, 112);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbEmployees.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbEmployees.Size = new System.Drawing.Size(217, 31);
            this.cmbEmployees.TabIndex = 21;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Black;
            this.lblFromDate.Location = new System.Drawing.Point(694, 190);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(58, 32);
            this.lblFromDate.TabIndex = 18;
            this.lblFromDate.Text = "التاريخ";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(456, 183);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(217, 39);
            this.dtpDate.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.AnimationHoverSpeed = 0.07F;
            this.btnSave.AnimationSpeed = 0.03F;
            this.btnSave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.BorderColor = System.Drawing.Color.Black;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FocusedColor = System.Drawing.Color.Empty;
            this.btnSave.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(456, 439);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(217, 57);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(694, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = "الموظف";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(694, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 32);
            this.label2.TabIndex = 23;
            this.label2.Text = "الوقت";
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(456, 241);
            this.dtpTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(217, 39);
            this.dtpTime.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(694, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 32);
            this.label3.TabIndex = 26;
            this.label3.Text = "نوع الحركة";
            // 
            // cmbInOutMode
            // 
            this.cmbInOutMode.BackColor = System.Drawing.Color.Transparent;
            this.cmbInOutMode.BaseColor = System.Drawing.Color.White;
            this.cmbInOutMode.BorderColor = System.Drawing.Color.Silver;
            this.cmbInOutMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbInOutMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInOutMode.FocusedColor = System.Drawing.Color.Empty;
            this.cmbInOutMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbInOutMode.ForeColor = System.Drawing.Color.Black;
            this.cmbInOutMode.FormattingEnabled = true;
            this.cmbInOutMode.Location = new System.Drawing.Point(456, 313);
            this.cmbInOutMode.Name = "cmbInOutMode";
            this.cmbInOutMode.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbInOutMode.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbInOutMode.Size = new System.Drawing.Size(217, 31);
            this.cmbInOutMode.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(694, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 32);
            this.label4.TabIndex = 28;
            this.label4.Text = "طريقة التحقق";
            // 
            // cmbVerificationMode
            // 
            this.cmbVerificationMode.BackColor = System.Drawing.Color.Transparent;
            this.cmbVerificationMode.BaseColor = System.Drawing.Color.White;
            this.cmbVerificationMode.BorderColor = System.Drawing.Color.Silver;
            this.cmbVerificationMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVerificationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerificationMode.FocusedColor = System.Drawing.Color.Empty;
            this.cmbVerificationMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbVerificationMode.ForeColor = System.Drawing.Color.Black;
            this.cmbVerificationMode.FormattingEnabled = true;
            this.cmbVerificationMode.Location = new System.Drawing.Point(456, 359);
            this.cmbVerificationMode.Name = "cmbVerificationMode";
            this.cmbVerificationMode.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbVerificationMode.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbVerificationMode.Size = new System.Drawing.Size(217, 31);
            this.cmbVerificationMode.TabIndex = 27;
            // 
            // ManualAttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 736);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbVerificationMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbInOutMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEmployees);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnSave);
            this.Name = "ManualAttendanceForm";
            this.Text = "ManualAttendanceForm";
            this.Load += new System.EventHandler(this.ManualAttendanceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaComboBox cmbEmployees;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private Guna.UI.WinForms.GunaButton btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaComboBox cmbInOutMode;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaComboBox cmbVerificationMode;
    }
}