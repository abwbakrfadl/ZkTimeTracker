namespace Fingerprint1.view
{
    partial class AddZKTeco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddZKTeco));
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnFetchData = new Guna.UI.WinForms.GunaButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
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
            // btnFetchData
            // 
            this.btnFetchData.AnimationHoverSpeed = 0.07F;
            this.btnFetchData.AnimationSpeed = 0.03F;
            this.btnFetchData.BaseColor = System.Drawing.Color.Navy;
            this.btnFetchData.BorderColor = System.Drawing.Color.Black;
            this.btnFetchData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFetchData.FocusedColor = System.Drawing.Color.Empty;
            this.btnFetchData.Font = new System.Drawing.Font("Cairo SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFetchData.ForeColor = System.Drawing.Color.White;
            this.btnFetchData.Image = ((System.Drawing.Image)(resources.GetObject("btnFetchData.Image")));
            this.btnFetchData.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnFetchData.ImageSize = new System.Drawing.Size(40, 40);
            this.btnFetchData.Location = new System.Drawing.Point(487, 147);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnFetchData.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnFetchData.OnHoverForeColor = System.Drawing.Color.White;
            this.btnFetchData.OnHoverImage = null;
            this.btnFetchData.OnPressedColor = System.Drawing.Color.Black;
            this.btnFetchData.Size = new System.Drawing.Size(301, 65);
            this.btnFetchData.TabIndex = 1;
            this.btnFetchData.Text = "جلب بيانات الموظفين من البصمة";
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvData.Location = new System.Drawing.Point(0, 229);
            this.dgvData.Name = "dgvData";
            this.dgvData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 26;
            this.dgvData.Size = new System.Drawing.Size(800, 221);
            this.dgvData.TabIndex = 2;
            // 
            // AddZKTeco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnFetchData);
            this.Controls.Add(this.lblMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddZKTeco";
            this.Text = "AttendanceApp";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private Guna.UI.WinForms.GunaButton btnFetchData;
        private System.Windows.Forms.DataGridView dgvData;
    }
}