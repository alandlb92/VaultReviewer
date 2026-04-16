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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mVaultReviewer.SaveConfig((int)nudReviewsPerDay.Value, txtUserName.Text.Trim());
            Close();
        }
    }
}
