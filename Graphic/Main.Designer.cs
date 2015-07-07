namespace Graphic
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePointsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.getConvexHullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsMenuItem
            // 
            this.actionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatePointsToolStripMenuItem1,
            this.getConvexHullToolStripMenuItem,
            this.generateTriangleToolStripMenuItem,
            this.verifyPointToolStripMenuItem});
            this.actionsMenuItem.Name = "actionsMenuItem";
            this.actionsMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsMenuItem.Text = "Actions";
            // 
            // generatePointsToolStripMenuItem1
            // 
            this.generatePointsToolStripMenuItem1.Name = "generatePointsToolStripMenuItem1";
            this.generatePointsToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.generatePointsToolStripMenuItem1.Text = "Generate Points";
            this.generatePointsToolStripMenuItem1.Click += new System.EventHandler(this.generatePointsToolStripMenuItem1_Click);
            // 
            // getConvexHullToolStripMenuItem
            // 
            this.getConvexHullToolStripMenuItem.Enabled = false;
            this.getConvexHullToolStripMenuItem.Name = "getConvexHullToolStripMenuItem";
            this.getConvexHullToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.getConvexHullToolStripMenuItem.Text = "Get Convex Hull";
            this.getConvexHullToolStripMenuItem.Click += new System.EventHandler(this.getConvexHullToolStripMenuItem_Click);
            // 
            // generateTriangleToolStripMenuItem
            // 
            this.generateTriangleToolStripMenuItem.Name = "generateTriangleToolStripMenuItem";
            this.generateTriangleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.generateTriangleToolStripMenuItem.Text = "Generate Triangle";
            this.generateTriangleToolStripMenuItem.Click += new System.EventHandler(this.generateTriangleToolStripMenuItem_Click);
            // 
            // verifyPointToolStripMenuItem
            // 
            this.verifyPointToolStripMenuItem.Enabled = false;
            this.verifyPointToolStripMenuItem.Name = "verifyPointToolStripMenuItem";
            this.verifyPointToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.verifyPointToolStripMenuItem.Text = "Verify Point";
            this.verifyPointToolStripMenuItem.Click += new System.EventHandler(this.verifyPointToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(184, 164);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ConvexHull";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePointsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getConvexHullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyPointToolStripMenuItem;

    }
}

