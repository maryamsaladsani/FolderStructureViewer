namespace WinFormsApp1
{
    partial class GUI
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
            browseBtn = new Button();
            treeBtn = new Button();
            barChartBtn = new Button();
            treeView1 = new TreeView();
            visualizationPanel = new Panel();
            SuspendLayout();
            // 
            // browseBtn
            // 
            browseBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            browseBtn.Location = new Point(38, 548);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(245, 43);
            browseBtn.TabIndex = 0;
            browseBtn.Text = "Browse ";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // treeBtn
            // 
            treeBtn.Location = new Point(296, 81);
            treeBtn.Name = "treeBtn";
            treeBtn.Size = new Size(137, 42);
            treeBtn.TabIndex = 1;
            treeBtn.Text = "Tree";
            treeBtn.UseVisualStyleBackColor = true;
            treeBtn.Click += treeBtn_Click;
            // 
            // barChartBtn
            // 
            barChartBtn.Location = new Point(439, 82);
            barChartBtn.Name = "barChartBtn";
            barChartBtn.Size = new Size(137, 41);
            barChartBtn.TabIndex = 2;
            barChartBtn.Text = "BarChart";
            barChartBtn.UseVisualStyleBackColor = true;
            barChartBtn.Click += barChartBtn_Click;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.Location = new Point(38, 81);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(245, 461);
            treeView1.TabIndex = 3;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // visualizationPanel
            // 
            visualizationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            visualizationPanel.AutoScroll = true;
            visualizationPanel.BorderStyle = BorderStyle.FixedSingle;
            visualizationPanel.Location = new Point(296, 128);
            visualizationPanel.Name = "visualizationPanel";
            visualizationPanel.Size = new Size(876, 463);
            visualizationPanel.TabIndex = 4;
            visualizationPanel.Paint += visualizationPanel_Paint;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 649);
            Controls.Add(barChartBtn);
            Controls.Add(visualizationPanel);
            Controls.Add(treeBtn);
            Controls.Add(treeView1);
            Controls.Add(browseBtn);
            Name = "GUI";
            Text = "Folder Visualizer";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button browseBtn;
        private Button treeBtn;
        private Button barChartBtn;
        private TreeView treeView1;
        private Panel visualizationPanel;
    }
}
