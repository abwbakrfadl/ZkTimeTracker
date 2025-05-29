namespace Fingerprint1.view
{
    partial class AttendanceApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceApp));
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnFetchAttendance = new Guna.UI.WinForms.GunaButton();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(655, 76);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(105, 32);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "رسالة الخطاء";
            // 
            // btnFetchAttendance
            // 
            this.btnFetchAttendance.AnimationHoverSpeed = 0.07F;
            this.btnFetchAttendance.AnimationSpeed = 0.03F;
            this.btnFetchAttendance.BaseColor = System.Drawing.Color.Navy;
            this.btnFetchAttendance.BorderColor = System.Drawing.Color.Black;
            this.btnFetchAttendance.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFetchAttendance.FocusedColor = System.Drawing.Color.Empty;
            this.btnFetchAttendance.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFetchAttendance.ForeColor = System.Drawing.Color.White;
            this.btnFetchAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnFetchAttendance.Image")));
            this.btnFetchAttendance.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnFetchAttendance.ImageSize = new System.Drawing.Size(40, 40);
            this.btnFetchAttendance.Location = new System.Drawing.Point(491, 147);
            this.btnFetchAttendance.Name = "btnFetchAttendance";
            this.btnFetchAttendance.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnFetchAttendance.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnFetchAttendance.OnHoverForeColor = System.Drawing.Color.White;
            this.btnFetchAttendance.OnHoverImage = null;
            this.btnFetchAttendance.OnPressedColor = System.Drawing.Color.Black;
            this.btnFetchAttendance.Size = new System.Drawing.Size(297, 65);
            this.btnFetchAttendance.TabIndex = 1;
            this.btnFetchAttendance.Text = "جلب بيانات الموظفين من البصمة";
            this.btnFetchAttendance.Click += new System.EventHandler(this.btnFetchAttendance_Click);
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvAttendance.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAttendance.Location = new System.Drawing.Point(0, 229);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAttendance.RowHeadersWidth = 51;
            this.dgvAttendance.RowTemplate.Height = 26;
            this.dgvAttendance.Size = new System.Drawing.Size(800, 221);
            this.dgvAttendance.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 206);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(800, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // AttendanceApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.btnFetchAttendance);
            this.Controls.Add(this.lblMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AttendanceApp";
            this.Text = "AttendanceApp";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private Guna.UI.WinForms.GunaButton btnFetchAttendance;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}