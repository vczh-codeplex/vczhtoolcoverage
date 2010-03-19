namespace VSCoverageAnalyzer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listViewResults = new System.Windows.Forms.ListView();
            this.imageListComponent = new System.Windows.Forms.ImageList(this.components);
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.coverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importVisualStudioUnittestResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewResults
            // 
            this.listViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.Location = new System.Drawing.Point(12, 27);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(591, 531);
            this.listViewResults.SmallImageList = this.imageListComponent;
            this.listViewResults.TabIndex = 0;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewResults_MouseDoubleClick);
            // 
            // imageListComponent
            // 
            this.imageListComponent.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListComponent.ImageStream")));
            this.imageListComponent.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageListComponent.Images.SetKeyName(0, "VSObject_Module.bmp");
            this.imageListComponent.Images.SetKeyName(1, "VSObject_Namespace.bmp");
            this.imageListComponent.Images.SetKeyName(2, "VSObject_Class.bmp");
            this.imageListComponent.Images.SetKeyName(3, "VSObject_Method.bmp");
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coverageToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(615, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // coverageToolStripMenuItem
            // 
            this.coverageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importVisualStudioUnittestResultToolStripMenuItem,
            this.selectColumnsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.coverageToolStripMenuItem.Name = "coverageToolStripMenuItem";
            this.coverageToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.coverageToolStripMenuItem.Text = "Coverage";
            // 
            // importVisualStudioUnittestResultToolStripMenuItem
            // 
            this.importVisualStudioUnittestResultToolStripMenuItem.Name = "importVisualStudioUnittestResultToolStripMenuItem";
            this.importVisualStudioUnittestResultToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.importVisualStudioUnittestResultToolStripMenuItem.Text = "Import Visual Studio Unittest Result ...";
            this.importVisualStudioUnittestResultToolStripMenuItem.Click += new System.EventHandler(this.importVisualStudioUnittestResultToolStripMenuItem_Click);
            // 
            // selectColumnsToolStripMenuItem
            // 
            this.selectColumnsToolStripMenuItem.Name = "selectColumnsToolStripMenuItem";
            this.selectColumnsToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.selectColumnsToolStripMenuItem.Text = "Select Columns ...";
            this.selectColumnsToolStripMenuItem.Click += new System.EventHandler(this.selectColumnsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dialogOpen
            // 
            this.dialogOpen.Filter = "Test Result(*.xml)|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 570);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS Coverage Analyzer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ImageList imageListComponent;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem coverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importVisualStudioUnittestResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dialogOpen;
    }
}

