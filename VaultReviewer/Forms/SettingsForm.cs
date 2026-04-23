using VaultReviewer.Core;
using ReviewEngine = VaultReviewer.Core.VaultReviewer;

namespace VaultReviewer.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly ReviewEngine mVaultReviewer;

        public SettingsForm(ReviewEngine vaultReviewer)
        {
            mVaultReviewer = vaultReviewer;
            InitializeComponent();
            txtUserName.Text       = mVaultReviewer.GetUserName();
            nudReviewsPerDay.Value = mVaultReviewer.GetReviewsPerDay();
            lstIgnored.Items.AddRange(mVaultReviewer.GetIgnoredPaths().ToArray<object>());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mVaultReviewer.SaveConfig((int)nudReviewsPerDay.Value, txtUserName.Text.Trim());
            mVaultReviewer.SaveIgnoredPaths(lstIgnored.Items.Cast<string>().ToList());
            Close();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK && !lstIgnored.Items.Contains(dlg.SelectedPath))
                lstIgnored.Items.Add(dlg.SelectedPath);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "Markdown|*.md|All files|*.*" };
            if (dlg.ShowDialog() == DialogResult.OK && !lstIgnored.Items.Contains(dlg.FileName))
                lstIgnored.Items.Add(dlg.FileName);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstIgnored.SelectedItem != null)
                lstIgnored.Items.Remove(lstIgnored.SelectedItem);
        }
    }
}
