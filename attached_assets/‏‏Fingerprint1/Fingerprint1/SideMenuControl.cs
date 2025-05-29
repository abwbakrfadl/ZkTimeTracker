using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fingerprint1.view;

namespace Fingerprint1
{

    //public class SideMenuControl : UserControl
    //{
    //    private FlowLayoutPanel menuPanel;
    //    private Panel logoPanel;
    //    private Label logoLabel;
    //    private bool isExpanded = true;
    //    private const int EXPANDED_WIDTH = 250;
    //    private const int COLLAPSED_WIDTH = 50;
    //    private Color primaryColor = Color.FromArgb(31, 30, 68);
    //    private Color secondaryColor = Color.FromArgb(40, 38, 80);
    //    private Color highlightColor = Color.FromArgb(50, 48, 90);

    //    public SideMenuControl()
    //    {
    //        InitializeComponent();
    //        SetupMenu();
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.BackColor = primaryColor;
    //        this.Dock = DockStyle.Left;
    //        this.Width = EXPANDED_WIDTH;

    //        logoPanel = new Panel
    //        {
    //            Height = 100,
    //            Dock = DockStyle.Top,
    //            BackColor = secondaryColor
    //        };

    //        logoLabel = new Label
    //        {
    //            Text = "نظام الحضور",
    //            ForeColor = Color.White,
    //            Font = new Font("Cairo", 16, FontStyle.Bold),
    //            Dock = DockStyle.Fill,
    //            TextAlign = ContentAlignment.MiddleCenter
    //        };

    //        menuPanel = new FlowLayoutPanel
    //        {
    //            Dock = DockStyle.Fill,
    //            AutoScroll = true,
    //            Padding = new Padding(5),
    //            BackColor = primaryColor
    //        };

    //        logoPanel.Controls.Add(logoLabel);
    //        this.Controls.Add(menuPanel);
    //        this.Controls.Add(logoPanel);
    //    }

    //    private void SetupMenu()
    //    {
    //        AddMenuItem("الرئيسية", "home", () => OpenForm(typeof(Fingerprint1.MainForm1)));
    //        AddMenuItem("الموظفين", "users", () => OpenForm(typeof(Fingerprint1.view.AddZKTeco)));
    //        AddMenuItem("الحضور والانصراف", "attendance", () => OpenForm(typeof(Fingerprint1.view.AttendanceStatusForm)));
    //        AddMenuItem("التقارير", "reports", () => OpenForm(typeof(Fingerprint1.view.DeductionReportForm)));
    //        AddMenuItem("الإعدادات", "settings", () => OpenForm(typeof(Fingerprint1.view.MonthlyReportForm)));
    //    }

    //    private void AddMenuItem(string text, string iconName, Action clickAction)
    //    {
    //        var btn = new Button
    //        {
    //            Text = "  " + text,
    //            TextAlign = ContentAlignment.MiddleLeft,
    //            Font = new Font("Cairo", 12),
    //            ForeColor = Color.White,
    //            BackColor = primaryColor,
    //            FlatStyle = FlatStyle.Flat,
    //            Height = 45,
    //            Width = EXPANDED_WIDTH - 10,
    //            ImageAlign = ContentAlignment.MiddleLeft,
    //            Padding = new Padding(10, 0, 0, 0),
    //            Cursor = Cursors.Hand
    //        };

    //        btn.FlatAppearance.BorderSize = 0;
    //        btn.FlatAppearance.MouseOverBackColor = highlightColor;
    //        btn.Click += (s, e) => clickAction?.Invoke();

    //        // Load icon if exists
    //        try
    //        {
    //            btn.Image = Image.FromFile($@"Icons\{iconName}.png");
    //            btn.ImageAlign = ContentAlignment.MiddleLeft;
    //        }
    //        catch { }

    //        menuPanel.Controls.Add(btn);
    //    }

    //    private void OpenForm(Type formType)
    //    {
    //        Form form = (Form)Activator.CreateInstance(formType);
    //        form.Show();
    //    }

    //    public void ToggleMenu()
    //    {
    //        isExpanded = !isExpanded;
    //        this.Width = isExpanded ? EXPANDED_WIDTH : COLLAPSED_WIDTH;

    //        foreach (Control ctrl in menuPanel.Controls)
    //        {
    //            if (ctrl is Button btn)
    //            {
    //                btn.Text = isExpanded ? "  " + btn.Tag?.ToString() : "";
    //                btn.Width = isExpanded ? EXPANDED_WIDTH - 10 : COLLAPSED_WIDTH - 10;
    //            }
    //        }
    //    }
    //}
}

