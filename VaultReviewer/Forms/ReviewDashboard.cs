using System.Runtime.InteropServices;
using Microsoft.Win32;
using VaultReviewer.Core;
using ReviewEngine = VaultReviewer.Core.VaultReviewer;

namespace VaultReviewer.Forms
{
    public partial class ReviewDashboard : Form
    {
        [DllImport("user32.dll")] static extern bool ReleaseCapture();
        [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HTCAPTION = 0x2;

        ReviewEngine mVaultReviewer;

        public ReviewDashboard()
        {
            if (!IsOnStartup())
                RegisterStartup();

            InitializeComponent();
            mVaultReviewer = new ReviewEngine(this);
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;
        }

        private bool IsOnStartup()
        {
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
            return key?.GetValue("VaultReviewer") != null;
        }

        private void RegisterStartup()
        {
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            key?.SetValue("VaultReviewer", Application.ExecutablePath);
        }

        public void SetVaultPath(Action<string> onVaultIsSet)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();

            using var dialog = new FolderBrowserDialog { Description = "Select your Obsidian vault folder" };
            if (dialog.ShowDialog() == DialogResult.OK)
                onVaultIsSet(dialog.SelectedPath);
        }

        public void PopulateReviews(VaultReviewerData data)
        {
            panelContent.Controls.Clear();

            const int itemHeight = 36;
            const int spacing = 6;

            for (int i = 0; i < data.PathsToReviewToday.Count; i++)
            {
                string name = Path.GetFileNameWithoutExtension(data.PathsToReviewToday[i].DocPath);

                var cb = new CheckBox
                {
                    Text = name,
                    Checked = data.PathsToReviewToday[i].IsReviewed,
                    ForeColor = Color.FromArgb(205, 214, 244),
                    Font = new Font("Segoe UI", 10F),
                    AutoSize = false,
                    Width = panelContent.ClientSize.Width - panelContent.Padding.Horizontal - 8,
                    Height = itemHeight,
                    Location = new Point(8, i * (itemHeight + spacing)),
                    Cursor = Cursors.Hand,
                };

                int index = i;
                cb.CheckedChanged += (_, _) => mVaultReviewer.MarkAsreviwed(index, cb.Checked);
                panelContent.Controls.Add(cb);
            }

            int contentHeight = data.PathsToReviewToday.Count * (itemHeight + spacing) + panelContent.Padding.Vertical;
            ClientSize = new Size(ClientSize.Width, panelHeader.Height + contentHeight);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => OpenWindow();

        private void menuItemOpen_Click(object sender, EventArgs e) => OpenWindow();

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using var settings = new SettingsForm(mVaultReviewer);
            settings.ShowDialog(this);
            RefreshTitle();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            Hide();
        }

        private void menuItemQuit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void ReviewDashboard_Load(object sender, EventArgs e)
        {
            panelHeader.MouseDown += DragWindow;
            lblTitle.MouseDown    += DragWindow;
            RefreshTitle();
        }

        private void RefreshTitle() => lblTitle.Text = mVaultReviewer.GetDisplayTitle();

        private void DragWindow(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var pen = new Pen(Color.FromArgb(49, 50, 68), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

        private void OpenWindow()
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Activate();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ShowInTaskbar = false;
                Hide();
            }
            base.OnFormClosing(e);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
