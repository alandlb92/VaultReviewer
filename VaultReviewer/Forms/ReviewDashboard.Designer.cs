namespace VaultReviewer.Forms
{
    partial class ReviewDashboard
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewDashboard));
            notifyIcon1 = new NotifyIcon(components);
            trayContextMenu = new ContextMenuStrip(components);
            menuItemOpen = new ToolStripMenuItem();
            menuItemQuit = new ToolStripMenuItem();
            panelHeader = new Panel();
            lblTitle = new Label();
            btnSettings = new Button();
            btnClose = new Button();
            panelContent = new Panel();
            trayContextMenu.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = trayContextMenu;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Vault Reviewer";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // trayContextMenu
            // 
            trayContextMenu.Items.AddRange(new ToolStripItem[] { menuItemOpen, menuItemQuit });
            trayContextMenu.Name = "trayContextMenu";
            trayContextMenu.Size = new Size(104, 48);
            // 
            // menuItemOpen
            // 
            menuItemOpen.Name = "menuItemOpen";
            menuItemOpen.Size = new Size(103, 22);
            menuItemOpen.Text = "Open";
            menuItemOpen.Click += menuItemOpen_Click;
            // 
            // menuItemQuit
            // 
            menuItemQuit.Name = "menuItemQuit";
            menuItemQuit.Size = new Size(103, 22);
            menuItemQuit.Text = "Quit";
            menuItemQuit.Click += menuItemQuit_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(24, 24, 37);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnSettings);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(430, 50);
            panelHeader.TabIndex = 2;
            panelHeader.Paint += panelHeader_Paint;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(205, 214, 244);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(131, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Alan's Homework";
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(69, 71, 90);
            btnSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 50, 68);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 13F);
            btnSettings.ForeColor = Color.FromArgb(166, 173, 200);
            btnSettings.Location = new Point(340, 7);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(36, 36);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "⚙";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 60, 60);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 84, 84);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F);
            btnClose.ForeColor = Color.FromArgb(166, 173, 200);
            btnClose.Location = new Point(388, 7);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(36, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.FromArgb(30, 30, 46);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 50);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(16, 10, 16, 10);
            panelContent.Size = new Size(430, 0);
            panelContent.TabIndex = 1;
            // 
            // ReviewDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(430, 50);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReviewDashboard";
            Text = "Alan's Homework";
            Load += ReviewDashboard_Load;
            trayContextMenu.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        private NotifyIcon        notifyIcon1;
        private ContextMenuStrip  trayContextMenu;
        private ToolStripMenuItem menuItemOpen;
        private ToolStripMenuItem menuItemQuit;
        private Panel             panelHeader;
        private Label             lblTitle;
        private Button            btnSettings;
        private Button            btnClose;
        private Panel             panelContent;
    }
}
