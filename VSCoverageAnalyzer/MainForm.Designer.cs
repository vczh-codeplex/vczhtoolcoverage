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
            this.SuspendLayout();
            // 
            // listViewResults
            // 
            this.listViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewResults.Location = new System.Drawing.Point(12, 12);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(591, 546);
            this.listViewResults.SmallImageList = this.imageListComponent;
            this.listViewResults.TabIndex = 0;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 570);
            this.Controls.Add(this.listViewResults);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS Coverage Analyzer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ImageList imageListComponent;
    }
}

