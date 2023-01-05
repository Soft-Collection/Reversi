namespace Reversi
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.think1MoveForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.think2MovesForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.think3MovesForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.think4MovesForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.think5MovesForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel1,
            this.statusBarLabel2,
            this.statusBarLabel3,
            this.statusBarLabel4,
            this.statusBarLabel5,
            this.statusBarLabel6});
            this.statusBar.Location = new System.Drawing.Point(0, 405);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(381, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            // 
            // statusBarLabel1
            // 
            this.statusBarLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBarLabel1.ForeColor = System.Drawing.Color.Red;
            this.statusBarLabel1.Name = "statusBarLabel1";
            this.statusBarLabel1.Size = new System.Drawing.Size(47, 17);
            this.statusBarLabel1.Text = "Status:";
            // 
            // statusBarLabel2
            // 
            this.statusBarLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.statusBarLabel2.ForeColor = System.Drawing.Color.Red;
            this.statusBarLabel2.Name = "statusBarLabel2";
            this.statusBarLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // statusBarLabel3
            // 
            this.statusBarLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.statusBarLabel3.ForeColor = System.Drawing.Color.Blue;
            this.statusBarLabel3.Name = "statusBarLabel3";
            this.statusBarLabel3.Size = new System.Drawing.Size(66, 17);
            this.statusBarLabel3.Text = "Computer:";
            // 
            // statusBarLabel4
            // 
            this.statusBarLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.statusBarLabel4.ForeColor = System.Drawing.Color.Blue;
            this.statusBarLabel4.Name = "statusBarLabel4";
            this.statusBarLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // statusBarLabel5
            // 
            this.statusBarLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.statusBarLabel5.ForeColor = System.Drawing.Color.Green;
            this.statusBarLabel5.Name = "statusBarLabel5";
            this.statusBarLabel5.Size = new System.Drawing.Size(50, 17);
            this.statusBarLabel5.Text = "Human:";
            // 
            // statusBarLabel6
            // 
            this.statusBarLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.statusBarLabel6.ForeColor = System.Drawing.Color.Green;
            this.statusBarLabel6.Name = "statusBarLabel6";
            this.statusBarLabel6.Size = new System.Drawing.Size(0, 17);
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(381, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuBar";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.think1MoveForwardToolStripMenuItem,
            this.think2MovesForwardToolStripMenuItem,
            this.think3MovesForwardToolStripMenuItem,
            this.think4MovesForwardToolStripMenuItem,
            this.think5MovesForwardToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // think1MoveForwardToolStripMenuItem
            // 
            this.think1MoveForwardToolStripMenuItem.Name = "think1MoveForwardToolStripMenuItem";
            this.think1MoveForwardToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.think1MoveForwardToolStripMenuItem.Text = "Think 1 move forward";
            this.think1MoveForwardToolStripMenuItem.Click += new System.EventHandler(this.think1MoveForwardToolStripMenuItem_Click);
            // 
            // think2MovesForwardToolStripMenuItem
            // 
            this.think2MovesForwardToolStripMenuItem.Name = "think2MovesForwardToolStripMenuItem";
            this.think2MovesForwardToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.think2MovesForwardToolStripMenuItem.Text = "Think 2 moves forward";
            this.think2MovesForwardToolStripMenuItem.Click += new System.EventHandler(this.think2MovesForwardToolStripMenuItem_Click);
            // 
            // think3MovesForwardToolStripMenuItem
            // 
            this.think3MovesForwardToolStripMenuItem.Name = "think3MovesForwardToolStripMenuItem";
            this.think3MovesForwardToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.think3MovesForwardToolStripMenuItem.Text = "Think 3 moves forward";
            this.think3MovesForwardToolStripMenuItem.Click += new System.EventHandler(this.think3MovesForwardToolStripMenuItem_Click);
            // 
            // think4MovesForwardToolStripMenuItem
            // 
            this.think4MovesForwardToolStripMenuItem.Name = "think4MovesForwardToolStripMenuItem";
            this.think4MovesForwardToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.think4MovesForwardToolStripMenuItem.Text = "Think 4 moves forward";
            this.think4MovesForwardToolStripMenuItem.Click += new System.EventHandler(this.think4MovesForwardToolStripMenuItem_Click);
            // 
            // think5MovesForwardToolStripMenuItem
            // 
            this.think5MovesForwardToolStripMenuItem.Name = "think5MovesForwardToolStripMenuItem";
            this.think5MovesForwardToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.think5MovesForwardToolStripMenuItem.Text = "Think 5 moves forward";
            this.think5MovesForwardToolStripMenuItem.Click += new System.EventHandler(this.think5MovesForwardToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpTopicsToolStripMenuItem,
            this.visitWebSiteToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpTopicsToolStripMenuItem
            // 
            this.helpTopicsToolStripMenuItem.Name = "helpTopicsToolStripMenuItem";
            this.helpTopicsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.helpTopicsToolStripMenuItem.Text = "Help Topics";
            this.helpTopicsToolStripMenuItem.Click += new System.EventHandler(this.helpTopicsToolStripMenuItem_Click);
            // 
            // visitWebSiteToolStripMenuItem
            // 
            this.visitWebSiteToolStripMenuItem.Name = "visitWebSiteToolStripMenuItem";
            this.visitWebSiteToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.visitWebSiteToolStripMenuItem.Text = "Visit Web Site";
            this.visitWebSiteToolStripMenuItem.Click += new System.EventHandler(this.visitWebSiteToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 427);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SoftCollection Reversi";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFrm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseClick);
            this.Move += new System.EventHandler(this.MainFrm_Move);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpTopicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel4;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel5;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel6;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem think1MoveForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem think2MovesForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem think3MovesForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem think4MovesForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem think5MovesForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitWebSiteToolStripMenuItem;
    }
}

