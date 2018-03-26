namespace Debugger
{
  partial class MainScreen
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
      if (disposing)
        components?.Dispose();

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
      this.ControlStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reloadPluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.environmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.Tabs = new System.Windows.Forms.TabControl();
      this.FrontPage = new System.Windows.Forms.TabPage();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.ControlStrip.SuspendLayout();
      this.Tabs.SuspendLayout();
      this.FrontPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // ControlStrip
      // 
      this.ControlStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.environmentsToolStripMenuItem});
      this.ControlStrip.Location = new System.Drawing.Point(0, 0);
      this.ControlStrip.Name = "ControlStrip";
      this.ControlStrip.Size = new System.Drawing.Size(396, 24);
      this.ControlStrip.TabIndex = 0;
      this.ControlStrip.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadPluginsToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // reloadPluginsToolStripMenuItem
      // 
      this.reloadPluginsToolStripMenuItem.Name = "reloadPluginsToolStripMenuItem";
      this.reloadPluginsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.reloadPluginsToolStripMenuItem.Text = "Reload plugins";
      this.reloadPluginsToolStripMenuItem.Click += new System.EventHandler(this.ReloadPluginsToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.ShowShortcutKeys = false;
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.optionsToolStripMenuItem.Text = "Options";
      // 
      // environmentsToolStripMenuItem
      // 
      this.environmentsToolStripMenuItem.Name = "environmentsToolStripMenuItem";
      this.environmentsToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
      this.environmentsToolStripMenuItem.Text = "Environments";
      // 
      // Tabs
      // 
      this.Tabs.Controls.Add(this.FrontPage);
      this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Tabs.Location = new System.Drawing.Point(0, 24);
      this.Tabs.MinimumSize = new System.Drawing.Size(100, 100);
      this.Tabs.Name = "Tabs";
      this.Tabs.SelectedIndex = 0;
      this.Tabs.Size = new System.Drawing.Size(396, 517);
      this.Tabs.TabIndex = 1;
      // 
      // FrontPage
      // 
      this.FrontPage.BackColor = System.Drawing.Color.Black;
      this.FrontPage.Controls.Add(this.flowLayoutPanel1);
      this.FrontPage.Location = new System.Drawing.Point(4, 22);
      this.FrontPage.Name = "FrontPage";
      this.FrontPage.Padding = new System.Windows.Forms.Padding(3);
      this.FrontPage.Size = new System.Drawing.Size(388, 491);
      this.FrontPage.TabIndex = 0;
      this.FrontPage.Text = "FrontPage";
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoScroll = true;
      this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(382, 485);
      this.flowLayoutPanel1.TabIndex = 0;
      this.flowLayoutPanel1.Tag = "";
      // 
      // MainScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(396, 541);
      this.Controls.Add(this.Tabs);
      this.Controls.Add(this.ControlStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.ControlStrip;
      this.Name = "MainScreen";
      this.Text = "Supporter";
      this.ControlStrip.ResumeLayout(false);
      this.ControlStrip.PerformLayout();
      this.Tabs.ResumeLayout(false);
      this.FrontPage.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip ControlStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem environmentsToolStripMenuItem;
    private System.Windows.Forms.TabControl Tabs;
    private System.Windows.Forms.TabPage FrontPage;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.ToolStripMenuItem reloadPluginsToolStripMenuItem;
  }
}