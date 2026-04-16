using Microsoft.Win32;

namespace VaultReviewer
{
    public partial class Form1 : Form
    {
        VaultReviewer mVaultReviewer;
        public Form1()
        {
            if(!IsOnStartup())
            {
                RegisterStartup();
            }

            mVaultReviewer = new VaultReviewer(this);
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;
        }
        
        private bool IsOnStartup()
        {
            string appName = "VaultReviewer";

            RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                false
            );

            return key.GetValue(appName) != null;
        }

        private void RegisterStartup()
        {
            string appName = "VaultReviewer";
            string exePath = Application.ExecutablePath;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                true
            );

            key.SetValue(appName, exePath);
        }

        public void SetVaultPath(Action<string> OnVaultIsSeted)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Selecione a pasta do Vault";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string pastaSelecionada = dialog.SelectedPath;
                    OnVaultIsSeted(pastaSelecionada);
                }
            }
        }

        public void PopulateReviews(VaultReviewerData Data)
        {
            int yPosition = 20;
            for (int i = 0; i < Data.PathsToReviewToday.Count; i++)
            {
                string name = Path.GetFileNameWithoutExtension(Data.PathsToReviewToday[i].DocPath);
                CheckBox checkBox = new CheckBox();
                checkBox.Text = name;
                checkBox.Location = new Point(20, yPosition + i * yPosition);
                checkBox.AutoSize = true;
                checkBox.Checked = Data.PathsToReviewToday[i].IsReviewed;
                int index = i; // Capture the current value of i for use in the lambda
                checkBox.CheckedChanged += (sender, e) =>
                {
                    mVaultReviewer.MarkAsreviwed(index, checkBox.Checked);
                };
                Controls.Add(checkBox);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Activate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Activate();
        }

        private void menuItemQuit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                ShowInTaskbar = false;
            }

            base.OnFormClosing(e);
        }
    }
}
