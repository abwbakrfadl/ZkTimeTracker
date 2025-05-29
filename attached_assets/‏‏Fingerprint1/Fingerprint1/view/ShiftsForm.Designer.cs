namespace Fingerprint1.view
{
    partial class ShiftsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftsForm));
            this.dgvShifts = new System.Windows.Forms.DataGridView();
            this.txtShiftName = new Guna.UI.WinForms.GunaTextBox();
            this.txtStartTime = new Guna.UI.WinForms.GunaTextBox();
            this.txtEndTime = new Guna.UI.WinForms.GunaTextBox();
            this.txtCheckInGracePeriod = new Guna.UI.WinForms.GunaTextBox();
            this.txtCheckOutGracePeriod = new Guna.UI.WinForms.GunaTextBox();
            this.txtCheckInStart = new Guna.UI.WinForms.GunaTextBox();
            this.txtCheckInEnd = new Guna.UI.WinForms.GunaTextBox();
            this.btnAdd = new Guna.UI.WinForms.GunaButton();
            this.btnUpdate = new Guna.UI.WinForms.GunaButton();
            this.btnDelete = new Guna.UI.WinForms.GunaButton();
            this.btnRefresh = new Guna.UI.WinForms.GunaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShifts
            // 
            this.dgvShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShifts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvShifts.Location = new System.Drawing.Point(0, 503);
            this.dgvShifts.Name = "dgvShifts";
            this.dgvShifts.RowHeadersWidth = 51;
            this.dgvShifts.RowTemplate.Height = 26;
            this.dgvShifts.Size = new System.Drawing.Size(1299, 256);
            this.dgvShifts.TabIndex = 0;
            this.dgvShifts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShifts_CellClick);
            // 
            // txtShiftName
            // 
            this.txtShiftName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtShiftName.BaseColor = System.Drawing.Color.White;
            this.txtShiftName.BorderColor = System.Drawing.Color.Silver;
            this.txtShiftName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShiftName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtShiftName.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtShiftName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtShiftName.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtShiftName.Location = new System.Drawing.Point(859, 32);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.PasswordChar = '\0';
            this.txtShiftName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShiftName.SelectedText = "";
            this.txtShiftName.Size = new System.Drawing.Size(230, 44);
            this.txtShiftName.TabIndex = 1;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStartTime.BaseColor = System.Drawing.Color.White;
            this.txtStartTime.BorderColor = System.Drawing.Color.Silver;
            this.txtStartTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStartTime.FocusedBaseColor = System.Drawing.Color.White;
            this.txtStartTime.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtStartTime.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtStartTime.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtStartTime.Location = new System.Drawing.Point(462, 34);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.PasswordChar = '\0';
            this.txtStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStartTime.SelectedText = "";
            this.txtStartTime.Size = new System.Drawing.Size(220, 44);
            this.txtStartTime.TabIndex = 2;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEndTime.BaseColor = System.Drawing.Color.White;
            this.txtEndTime.BorderColor = System.Drawing.Color.Silver;
            this.txtEndTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEndTime.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEndTime.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtEndTime.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEndTime.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtEndTime.Location = new System.Drawing.Point(26, 32);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.PasswordChar = '\0';
            this.txtEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEndTime.SelectedText = "";
            this.txtEndTime.Size = new System.Drawing.Size(219, 44);
            this.txtEndTime.TabIndex = 3;
            // 
            // txtCheckInGracePeriod
            // 
            this.txtCheckInGracePeriod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCheckInGracePeriod.BaseColor = System.Drawing.Color.White;
            this.txtCheckInGracePeriod.BorderColor = System.Drawing.Color.Silver;
            this.txtCheckInGracePeriod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCheckInGracePeriod.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCheckInGracePeriod.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCheckInGracePeriod.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCheckInGracePeriod.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtCheckInGracePeriod.Location = new System.Drawing.Point(859, 138);
            this.txtCheckInGracePeriod.Name = "txtCheckInGracePeriod";
            this.txtCheckInGracePeriod.PasswordChar = '\0';
            this.txtCheckInGracePeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheckInGracePeriod.SelectedText = "";
            this.txtCheckInGracePeriod.Size = new System.Drawing.Size(230, 44);
            this.txtCheckInGracePeriod.TabIndex = 4;
            // 
            // txtCheckOutGracePeriod
            // 
            this.txtCheckOutGracePeriod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCheckOutGracePeriod.BaseColor = System.Drawing.Color.White;
            this.txtCheckOutGracePeriod.BorderColor = System.Drawing.Color.Silver;
            this.txtCheckOutGracePeriod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCheckOutGracePeriod.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCheckOutGracePeriod.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCheckOutGracePeriod.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCheckOutGracePeriod.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtCheckOutGracePeriod.Location = new System.Drawing.Point(462, 138);
            this.txtCheckOutGracePeriod.Name = "txtCheckOutGracePeriod";
            this.txtCheckOutGracePeriod.PasswordChar = '\0';
            this.txtCheckOutGracePeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheckOutGracePeriod.SelectedText = "";
            this.txtCheckOutGracePeriod.Size = new System.Drawing.Size(220, 44);
            this.txtCheckOutGracePeriod.TabIndex = 5;
            // 
            // txtCheckInStart
            // 
            this.txtCheckInStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCheckInStart.BaseColor = System.Drawing.Color.White;
            this.txtCheckInStart.BorderColor = System.Drawing.Color.Silver;
            this.txtCheckInStart.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCheckInStart.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCheckInStart.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCheckInStart.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCheckInStart.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtCheckInStart.Location = new System.Drawing.Point(26, 138);
            this.txtCheckInStart.Name = "txtCheckInStart";
            this.txtCheckInStart.PasswordChar = '\0';
            this.txtCheckInStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheckInStart.SelectedText = "";
            this.txtCheckInStart.Size = new System.Drawing.Size(219, 44);
            this.txtCheckInStart.TabIndex = 6;
            // 
            // txtCheckInEnd
            // 
            this.txtCheckInEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCheckInEnd.BaseColor = System.Drawing.Color.White;
            this.txtCheckInEnd.BorderColor = System.Drawing.Color.Silver;
            this.txtCheckInEnd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCheckInEnd.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCheckInEnd.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCheckInEnd.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCheckInEnd.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtCheckInEnd.Location = new System.Drawing.Point(859, 239);
            this.txtCheckInEnd.Name = "txtCheckInEnd";
            this.txtCheckInEnd.PasswordChar = '\0';
            this.txtCheckInEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheckInEnd.SelectedText = "";
            this.txtCheckInEnd.Size = new System.Drawing.Size(230, 44);
            this.txtCheckInEnd.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.AnimationHoverSpeed = 0.07F;
            this.btnAdd.AnimationSpeed = 0.03F;
            this.btnAdd.BaseColor = System.Drawing.Color.Navy;
            this.btnAdd.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.FocusedColor = System.Drawing.Color.Empty;
            this.btnAdd.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAdd.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAdd.Location = new System.Drawing.Point(949, 348);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnAdd.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAdd.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAdd.OnHoverImage = null;
            this.btnAdd.OnPressedColor = System.Drawing.Color.Black;
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(278, 58);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "إضافة فترة جديدة";
            this.btnAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.AnimationHoverSpeed = 0.07F;
            this.btnUpdate.AnimationSpeed = 0.03F;
            this.btnUpdate.BaseColor = System.Drawing.Color.Navy;
            this.btnUpdate.BorderColor = System.Drawing.Color.Black;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpdate.FocusedColor = System.Drawing.Color.Empty;
            this.btnUpdate.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnUpdate.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUpdate.Location = new System.Drawing.Point(527, 348);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnUpdate.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUpdate.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUpdate.OnHoverImage = null;
            this.btnUpdate.OnPressedColor = System.Drawing.Color.Black;
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUpdate.Size = new System.Drawing.Size(273, 58);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "تحديث بيانات الفترة المحددة";
            this.btnUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.AnimationHoverSpeed = 0.07F;
            this.btnDelete.AnimationSpeed = 0.03F;
            this.btnDelete.BaseColor = System.Drawing.Color.Navy;
            this.btnDelete.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.FocusedColor = System.Drawing.Color.Empty;
            this.btnDelete.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDelete.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDelete.Location = new System.Drawing.Point(104, 348);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDelete.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDelete.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDelete.OnHoverImage = null;
            this.btnDelete.OnPressedColor = System.Drawing.Color.Black;
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(274, 58);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "حذف الفترة المحددة";
            this.btnDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AnimationHoverSpeed = 0.07F;
            this.btnRefresh.AnimationSpeed = 0.03F;
            this.btnRefresh.BaseColor = System.Drawing.Color.Navy;
            this.btnRefresh.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefresh.FocusedColor = System.Drawing.Color.Empty;
            this.btnRefresh.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnRefresh.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRefresh.Location = new System.Drawing.Point(0, 445);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnRefresh.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRefresh.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRefresh.OnHoverImage = null;
            this.btnRefresh.OnPressedColor = System.Drawing.Color.Black;
            this.btnRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRefresh.Size = new System.Drawing.Size(1299, 58);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "تحديث البيانات المعروضة في الجدول";
            this.btnRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1111, 38);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(109, 36);
            this.label1.TabIndex = 12;
            this.label1.Text = "اسم الفترة";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(688, 35);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(147, 36);
            this.label2.TabIndex = 13;
            this.label2.Text = "وقت بدء العمل ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(270, 35);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(167, 36);
            this.label3.TabIndex = 14;
            this.label3.Text = "وقت انتهاء العمل";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1111, 143);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(149, 36);
            this.label4.TabIndex = 15;
            this.label4.Text = "سماحية الحضور";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(688, 143);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(163, 36);
            this.label5.TabIndex = 16;
            this.label5.Text = "سماحية الانصراف";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(270, 143);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(165, 36);
            this.label6.TabIndex = 17;
            this.label6.Text = "بداية فترة الحضور";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(1110, 242);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(182, 36);
            this.label7.TabIndex = 18;
            this.label7.Text = "نهاية فترة الانصراف";
            // 
            // ShiftsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 759);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCheckInEnd);
            this.Controls.Add(this.txtCheckInStart);
            this.Controls.Add(this.txtCheckOutGracePeriod);
            this.Controls.Add(this.txtCheckInGracePeriod);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.txtShiftName);
            this.Controls.Add(this.dgvShifts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShiftsForm";
            this.Text = "ShiftsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShifts;
        private Guna.UI.WinForms.GunaTextBox txtShiftName;
        private Guna.UI.WinForms.GunaTextBox txtStartTime;
        private Guna.UI.WinForms.GunaTextBox txtEndTime;
        private Guna.UI.WinForms.GunaTextBox txtCheckInGracePeriod;
        private Guna.UI.WinForms.GunaTextBox txtCheckOutGracePeriod;
        private Guna.UI.WinForms.GunaTextBox txtCheckInStart;
        private Guna.UI.WinForms.GunaTextBox txtCheckInEnd;
        private Guna.UI.WinForms.GunaButton btnAdd;
        private Guna.UI.WinForms.GunaButton btnUpdate;
        private Guna.UI.WinForms.GunaButton btnDelete;
        private Guna.UI.WinForms.GunaButton btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}