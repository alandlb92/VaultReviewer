namespace VaultReviewer.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUserName      = new Label();
            txtUserName      = new TextBox();
            lblReviewsPerDay = new Label();
            nudReviewsPerDay = new NumericUpDown();
            lblIgnored       = new Label();
            lstIgnored       = new ListBox();
            btnAddFolder     = new Button();
            btnAddFile       = new Button();
            btnRemove        = new Button();
            btnSave          = new Button();
            ((System.ComponentModel.ISupportInitialize)nudReviewsPerDay).BeginInit();
            SuspendLayout();

            // lblUserName
            lblUserName.Text      = "Your name";
            lblUserName.ForeColor = Color.FromArgb(166, 173, 200);
            lblUserName.Font      = new Font("Segoe UI", 9.5F);
            lblUserName.AutoSize  = true;
            lblUserName.Location  = new Point(24, 28);

            // txtUserName
            txtUserName.Font        = new Font("Segoe UI", 10F);
            txtUserName.BackColor   = Color.FromArgb(49, 50, 68);
            txtUserName.ForeColor   = Color.FromArgb(205, 214, 244);
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Size        = new Size(130, 26);
            txtUserName.Location    = new Point(114, 25);

            // lblReviewsPerDay
            lblReviewsPerDay.Text      = "Reviews per day";
            lblReviewsPerDay.ForeColor = Color.FromArgb(166, 173, 200);
            lblReviewsPerDay.Font      = new Font("Segoe UI", 9.5F);
            lblReviewsPerDay.AutoSize  = true;
            lblReviewsPerDay.Location  = new Point(24, 66);

            // nudReviewsPerDay
            nudReviewsPerDay.Minimum     = 1;
            nudReviewsPerDay.Maximum     = 50;
            nudReviewsPerDay.Font        = new Font("Segoe UI", 10F);
            nudReviewsPerDay.BackColor   = Color.FromArgb(49, 50, 68);
            nudReviewsPerDay.ForeColor   = Color.FromArgb(205, 214, 244);
            nudReviewsPerDay.BorderStyle = BorderStyle.FixedSingle;
            nudReviewsPerDay.Size        = new Size(60, 26);
            nudReviewsPerDay.Location    = new Point(184, 63);

            // lblIgnored
            lblIgnored.Text      = "Ignored folders / files";
            lblIgnored.ForeColor = Color.FromArgb(166, 173, 200);
            lblIgnored.Font      = new Font("Segoe UI", 9.5F);
            lblIgnored.AutoSize  = true;
            lblIgnored.Location  = new Point(24, 105);

            // lstIgnored
            lstIgnored.BackColor            = Color.FromArgb(49, 50, 68);
            lstIgnored.ForeColor            = Color.FromArgb(205, 214, 244);
            lstIgnored.Font                 = new Font("Segoe UI", 9F);
            lstIgnored.BorderStyle          = BorderStyle.FixedSingle;
            lstIgnored.Size                 = new Size(238, 110);
            lstIgnored.Location             = new Point(24, 125);
            lstIgnored.HorizontalScrollbar  = true;
            lstIgnored.ScrollAlwaysVisible  = true;

            // btnAddFolder
            btnAddFolder.Text                              = "+ Folder";
            btnAddFolder.FlatStyle                         = FlatStyle.Flat;
            btnAddFolder.FlatAppearance.BorderColor        = Color.FromArgb(166, 173, 200);
            btnAddFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 50, 68);
            btnAddFolder.ForeColor                         = Color.FromArgb(166, 173, 200);
            btnAddFolder.Font                              = new Font("Segoe UI", 9F);
            btnAddFolder.Size                              = new Size(74, 26);
            btnAddFolder.Location                          = new Point(24, 242);
            btnAddFolder.Cursor                            = Cursors.Hand;
            btnAddFolder.Click                            += btnAddFolder_Click;

            // btnAddFile
            btnAddFile.Text                              = "+ File";
            btnAddFile.FlatStyle                         = FlatStyle.Flat;
            btnAddFile.FlatAppearance.BorderColor        = Color.FromArgb(166, 173, 200);
            btnAddFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 50, 68);
            btnAddFile.ForeColor                         = Color.FromArgb(166, 173, 200);
            btnAddFile.Font                              = new Font("Segoe UI", 9F);
            btnAddFile.Size                              = new Size(64, 26);
            btnAddFile.Location                          = new Point(104, 242);
            btnAddFile.Cursor                            = Cursors.Hand;
            btnAddFile.Click                            += btnAddFile_Click;

            // btnRemove
            btnRemove.Text                              = "Remove";
            btnRemove.FlatStyle                         = FlatStyle.Flat;
            btnRemove.FlatAppearance.BorderColor        = Color.FromArgb(243, 139, 168);
            btnRemove.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 50, 68);
            btnRemove.ForeColor                         = Color.FromArgb(243, 139, 168);
            btnRemove.Font                              = new Font("Segoe UI", 9F);
            btnRemove.Size                              = new Size(68, 26);
            btnRemove.Location                          = new Point(194, 242);
            btnRemove.Cursor                            = Cursors.Hand;
            btnRemove.Click                            += btnRemove_Click;

            // btnSave
            btnSave.Text                              = "Save";
            btnSave.FlatStyle                         = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderColor        = Color.FromArgb(137, 180, 250);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 50, 68);
            btnSave.ForeColor                         = Color.FromArgb(137, 180, 250);
            btnSave.Font                              = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.Size                              = new Size(80, 30);
            btnSave.Location                          = new Point(103, 280);
            btnSave.Cursor                            = Cursors.Hand;
            btnSave.Click                            += btnSave_Click;

            // SettingsForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(30, 30, 46);
            ClientSize          = new Size(286, 326);
            FormBorderStyle     = FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            MinimizeBox         = false;
            StartPosition       = FormStartPosition.CenterParent;
            Text                = "Settings";
            Controls.AddRange(new Control[] { lblUserName, txtUserName, lblReviewsPerDay, nudReviewsPerDay, lblIgnored, lstIgnored, btnAddFolder, btnAddFile, btnRemove, btnSave });
            ((System.ComponentModel.ISupportInitialize)nudReviewsPerDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label         lblUserName;
        private TextBox       txtUserName;
        private Label         lblReviewsPerDay;
        private NumericUpDown nudReviewsPerDay;
        private Label         lblIgnored;
        private ListBox       lstIgnored;
        private Button        btnAddFolder;
        private Button        btnAddFile;
        private Button        btnRemove;
        private Button        btnSave;
    }
}
