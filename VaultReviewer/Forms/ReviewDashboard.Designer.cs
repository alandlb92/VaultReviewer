namespace VaultReviewer.Forms
{
    partial class ReviewDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewDashboard));
            notifyIcon1 = new NotifyIcon(components);
            trayContextMenu = new ContextMenuStrip(components);
            menuItemOpen = new ToolStripMenuItem();
            menuItemQuit = new ToolStripMenuItem();
            SuspendLayout();
            //
            // menuItemOpen
            //
            menuItemOpen.Text = "Open";
            menuItemOpen.Click += menuItemOpen_Click;
            //
            // menuItemQuit
            //
            menuItemQuit.Text = "Quit";
            menuItemQuit.Click += menuItemQuit_Click;
            //
            // trayContextMenu
            //
            trayContextMenu.Items.AddRange(new ToolStripItem[] { menuItemOpen, menuItemQuit });
            //
            // notifyIcon1
            //
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Vault Viewer";
            notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = trayContextMenu;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // ReviewDashboard
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(418, 130);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ReviewDashboard";
            Text = "Alan's Homework";
            Load += ReviewDashboard_Load;
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip trayContextMenu;
        private ToolStripMenuItem menuItemOpen;
        private ToolStripMenuItem menuItemQuit;
    }
}
