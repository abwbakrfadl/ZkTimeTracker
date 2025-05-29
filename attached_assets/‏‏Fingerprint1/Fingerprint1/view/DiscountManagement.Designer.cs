using System.Windows.Forms;

namespace Fingerprint1.view
{
    partial class DiscountManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountManagement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDiscountAmount = new Guna.UI.WinForms.GunaTextBox();
            this.btnCreateData = new Guna.UI.WinForms.GunaButton();
            this.txtConditionName = new Guna.UI.WinForms.GunaTextBox();
            this.dataGridView = new Guna.UI.WinForms.GunaDataGridView();
            this.btnDeleteData = new Guna.UI.WinForms.GunaButton();
            this.btnUpdate = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiscountAmount.BaseColor = System.Drawing.Color.White;
            this.txtDiscountAmount.BorderColor = System.Drawing.Color.Silver;
            this.txtDiscountAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscountAmount.FocusedBaseColor = System.Drawing.Color.White;
            this.txtDiscountAmount.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtDiscountAmount.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDiscountAmount.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtDiscountAmount.Location = new System.Drawing.Point(363, 201);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.PasswordChar = '\0';
            this.txtDiscountAmount.SelectedText = "";
            this.txtDiscountAmount.Size = new System.Drawing.Size(275, 44);
            this.txtDiscountAmount.TabIndex = 39;
            // 
            // btnCreateData
            // 
            this.btnCreateData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateData.AnimationHoverSpeed = 0.07F;
            this.btnCreateData.AnimationSpeed = 0.03F;
            this.btnCreateData.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnCreateData.BorderColor = System.Drawing.Color.Black;
            this.btnCreateData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreateData.FocusedColor = System.Drawing.Color.Empty;
            this.btnCreateData.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCreateData.ForeColor = System.Drawing.Color.White;
            this.btnCreateData.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateData.Image")));
            this.btnCreateData.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCreateData.Location = new System.Drawing.Point(779, 33);
            this.btnCreateData.Name = "btnCreateData";
            this.btnCreateData.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnCreateData.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCreateData.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCreateData.OnHoverImage = null;
            this.btnCreateData.OnPressedColor = System.Drawing.Color.Black;
            this.btnCreateData.Size = new System.Drawing.Size(174, 53);
            this.btnCreateData.TabIndex = 40;
            this.btnCreateData.Text = "انشاء البيانات ";
            this.btnCreateData.Click += new System.EventHandler(this.btnCreateData_Click);
            // 
            // txtConditionName
            // 
            this.txtConditionName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtConditionName.BaseColor = System.Drawing.Color.White;
            this.txtConditionName.BorderColor = System.Drawing.Color.Silver;
            this.txtConditionName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConditionName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtConditionName.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtConditionName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConditionName.Font = new System.Drawing.Font("Cairo ExtraBold", 10.8F, System.Drawing.FontStyle.Bold);
            this.txtConditionName.Location = new System.Drawing.Point(363, 151);
            this.txtConditionName.Name = "txtConditionName";
            this.txtConditionName.PasswordChar = '\0';
            this.txtConditionName.SelectedText = "";
            this.txtConditionName.Size = new System.Drawing.Size(275, 44);
            this.txtConditionName.TabIndex = 41;
            // 
            // dataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView.Location = new System.Drawing.Point(0, 365);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 26;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(992, 331);
            this.dataGridView.TabIndex = 42;
            this.dataGridView.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView.ThemeStyle.HeaderStyle.Height = 4;
            this.dataGridView.ThemeStyle.ReadOnly = false;
            this.dataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView.ThemeStyle.RowsStyle.Height = 26;
            this.dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gunaDataGridView1_CellClick);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteData.AnimationHoverSpeed = 0.07F;
            this.btnDeleteData.AnimationSpeed = 0.03F;
            this.btnDeleteData.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnDeleteData.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteData.FocusedColor = System.Drawing.Color.Empty;
            this.btnDeleteData.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDeleteData.ForeColor = System.Drawing.Color.White;
            this.btnDeleteData.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteData.Image")));
            this.btnDeleteData.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDeleteData.Location = new System.Drawing.Point(564, 33);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnDeleteData.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDeleteData.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDeleteData.OnHoverImage = null;
            this.btnDeleteData.OnPressedColor = System.Drawing.Color.Black;
            this.btnDeleteData.Size = new System.Drawing.Size(174, 53);
            this.btnDeleteData.TabIndex = 43;
            this.btnDeleteData.Text = " حذف البيانات ";
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.AnimationHoverSpeed = 0.07F;
            this.btnUpdate.AnimationSpeed = 0.03F;
            this.btnUpdate.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnUpdate.BorderColor = System.Drawing.Color.Black;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpdate.FocusedColor = System.Drawing.Color.Empty;
            this.btnUpdate.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUpdate.Location = new System.Drawing.Point(363, 266);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnUpdate.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUpdate.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUpdate.OnHoverImage = null;
            this.btnUpdate.OnPressedColor = System.Drawing.Color.Black;
            this.btnUpdate.Size = new System.Drawing.Size(275, 53);
            this.btnUpdate.TabIndex = 44;
            this.btnUpdate.Text = "تعديل الحاله";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.gunaLabel1.Location = new System.Drawing.Point(698, 162);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(94, 32);
            this.gunaLabel1.TabIndex = 45;
            this.gunaLabel1.Text = "اسم الحالة";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold);
            this.gunaLabel2.Location = new System.Drawing.Point(694, 201);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(101, 32);
            this.gunaLabel2.TabIndex = 46;
            this.gunaLabel2.Text = "مبلغ الخصم";
            // 
            // DiscountManagement
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(992, 745);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDeleteData);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtConditionName);
            this.Controls.Add(this.btnCreateData);
            this.Controls.Add(this.txtDiscountAmount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DiscountManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة الخصومات";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaTextBox txtDiscountAmount;
        private Guna.UI.WinForms.GunaButton btnCreateData;
        private Guna.UI.WinForms.GunaTextBox txtConditionName;
        private Guna.UI.WinForms.GunaDataGridView dataGridView;
        private Guna.UI.WinForms.GunaButton btnDeleteData;
        private Guna.UI.WinForms.GunaButton btnUpdate;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
    }
}