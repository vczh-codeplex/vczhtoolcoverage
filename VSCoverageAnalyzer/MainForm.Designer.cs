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
            this.importFiltersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFiltersToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelAllFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMain.SuspendLayout();
            this.contextMenuResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewResults
            // 
            this.listViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewResults.ContextMenuStrip = this.contextMenuResults;
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.Location = new System.Drawing.Point(12, 27);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(591, 531);
            this.listViewResults.SmallImageList = this.imageListComponent;
            this.listViewResults.TabIndex = 0;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewResults_MouseDoubleClick);
            this.listViewResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewResults_ColumnClick);
            this.listViewResults.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewResults_KeyUp);
            // 
            // imageListComponent
            // 
            this.imageListComponent.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListComponent.ImageStream")));
            this.imageListComponent.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageListComponent.Images.SetKeyName(0, "Control_Form.bmp");
            this.imageListComponent.Images.SetKeyName(1, "VSObject_Module.bmp");
            this.imageListComponent.Images.SetKeyName(2, "VSObject_Namespace.bmp");
            this.imageListComponent.Images.SetKeyName(3, "VSObject_Class.bmp");
            this.imageListComponent.Images.SetKeyName(4, "VSObject_Method.bmp");
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
            this.toolStripSeparator1,
            this.importFiltersToolStripMenuItem1,
            this.exportFiltersToolStripMenuItem2,
            this.toolStripSeparator2,
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
            // importFiltersToolStripMenuItem1
            // 
            this.importFiltersToolStripMenuItem1.Name = "importFiltersToolStripMenuItem1";
            this.importFiltersToolStripMenuItem1.Size = new System.Drawing.Size(272, 22);
            this.importFiltersToolStripMenuItem1.Text = "Import Filters ...";
            this.importFiltersToolStripMenuItem1.Click += new System.EventHandler(this.importFiltersToolStripMenuItem1_Click);
            // 
            // exportFiltersToolStripMenuItem2
            // 
            this.exportFiltersToolStripMenuItem2.Name = "exportFiltersToolStripMenuItem2";
            this.exportFiltersToolStripMenuItem2.Size = new System.Drawing.Size(272, 22);
            this.exportFiltersToolStripMenuItem2.Text = "Export Filters ...";
            this.exportFiltersToolStripMenuItem2.Click += new System.EventHandler(this.exportFiltersToolStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(269, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(269, 6);
            // 
            // contextMenuResults
            // 
            this.contextMenuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.toolStripSeparator3,
            this.setFilterToolStripMenuItem,
            this.clearFilterToolStripMenuItem,
            this.setAllVisibleToolStripMenuItem,
            this.toolStripSeparator4,
            this.cancelAllFiltersToolStripMenuItem});
            this.contextMenuResults.Name = "contextMenuResults";
            this.contextMenuResults.Size = new System.Drawing.Size(193, 126);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // setFilterToolStripMenuItem
            // 
            this.setFilterToolStripMenuItem.Name = "setFilterToolStripMenuItem";
            this.setFilterToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.setFilterToolStripMenuItem.Text = "Set Filter ...";
            this.setFilterToolStripMenuItem.Click += new System.EventHandler(this.setFilterToolStripMenuItem_Click);
            // 
            // clearFilterToolStripMenuItem
            // 
            this.clearFilterToolStripMenuItem.Name = "clearFilterToolStripMenuItem";
            this.clearFilterToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.clearFilterToolStripMenuItem.Text = "Clear Filter";
            this.clearFilterToolStripMenuItem.Click += new System.EventHandler(this.clearFilterToolStripMenuItem_Click);
            // 
            // setAllVisibleToolStripMenuItem
            // 
            this.setAllVisibleToolStripMenuItem.Name = "setAllVisibleToolStripMenuItem";
            this.setAllVisibleToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.setAllVisibleToolStripMenuItem.Text = "Clear Filter Recursively";
            this.setAllVisibleToolStripMenuItem.Click += new System.EventHandler(this.setAllVisibleToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // cancelAllFiltersToolStripMenuItem
            // 
            this.cancelAllFiltersToolStripMenuItem.Name = "cancelAllFiltersToolStripMenuItem";
            this.cancelAllFiltersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cancelAllFiltersToolStripMenuItem.Text = "Cancel All Filters";
            this.cancelAllFiltersToolStripMenuItem.Click += new System.EventHandler(this.cancelAllFiltersToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(189, 6);
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
            this.contextMenuResults.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem importFiltersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportFiltersToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuResults;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cancelAllFiltersToolStripMenuItem;
    }
}

