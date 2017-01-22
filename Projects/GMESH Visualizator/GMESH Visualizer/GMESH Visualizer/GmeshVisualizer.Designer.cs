namespace GMESH_Visualizer
{
    partial class GmeshVisualizer
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contourToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.meshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MeshInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.ImageErrorType = new System.Windows.Forms.DataGridViewImageColumn();
            this.ErrorInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.MeshGradLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MESHDisplay = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeshInfoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MESHDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contourToolStripMenuItem1,
            this.meshToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // contourToolStripMenuItem1
            // 
            this.contourToolStripMenuItem1.Name = "contourToolStripMenuItem1";
            this.contourToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.contourToolStripMenuItem1.Text = "Contour";
            this.contourToolStripMenuItem1.Click += new System.EventHandler(this.contourToolStripMenuItem1_Click);
            // 
            // meshToolStripMenuItem1
            // 
            this.meshToolStripMenuItem1.Name = "meshToolStripMenuItem1";
            this.meshToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.meshToolStripMenuItem1.Text = "Mesh";
            this.meshToolStripMenuItem1.Click += new System.EventHandler(this.meshToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 402);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(866, 24);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MeshInfoDataGridView);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MeshGradLabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(509, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 354);
            this.panel1.TabIndex = 4;
            // 
            // MeshInfoDataGridView
            // 
            this.MeshInfoDataGridView.AllowUserToAddRows = false;
            this.MeshInfoDataGridView.AllowUserToDeleteRows = false;
            this.MeshInfoDataGridView.AllowUserToResizeColumns = false;
            this.MeshInfoDataGridView.AllowUserToResizeRows = false;
            this.MeshInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MeshInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageErrorType,
            this.ErrorInfo});
            this.MeshInfoDataGridView.Location = new System.Drawing.Point(0, 48);
            this.MeshInfoDataGridView.Name = "MeshInfoDataGridView";
            this.MeshInfoDataGridView.ReadOnly = true;
            this.MeshInfoDataGridView.Size = new System.Drawing.Size(369, 306);
            this.MeshInfoDataGridView.TabIndex = 6;
            this.MeshInfoDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MeshInfoDataGridView_RowEnter);
            // 
            // ImageErrorType
            // 
            this.ImageErrorType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImageErrorType.Frozen = true;
            this.ImageErrorType.HeaderText = "Type";
            this.ImageErrorType.Name = "ImageErrorType";
            this.ImageErrorType.ReadOnly = true;
            this.ImageErrorType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ErrorInfo
            // 
            this.ErrorInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ErrorInfo.HeaderText = "Error Info";
            this.ErrorInfo.Name = "ErrorInfo";
            this.ErrorInfo.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MESH Info";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MeshGradLabel
            // 
            this.MeshGradLabel.AutoSize = true;
            this.MeshGradLabel.Location = new System.Drawing.Point(82, 32);
            this.MeshGradLabel.Name = "MeshGradLabel";
            this.MeshGradLabel.Size = new System.Drawing.Size(27, 13);
            this.MeshGradLabel.TabIndex = 8;
            this.MeshGradLabel.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(3, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "MESH Quality";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MESHDisplay
            // 
            this.MESHDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MESHDisplay.Location = new System.Drawing.Point(12, 27);
            this.MESHDisplay.Name = "MESHDisplay";
            this.MESHDisplay.Size = new System.Drawing.Size(474, 354);
            this.MESHDisplay.TabIndex = 5;
            this.MESHDisplay.TabStop = false;
            this.MESHDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.MESHDisplay_Paint);
            this.MESHDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MESHDisplay_MouseClick);
            // 
            // GmeshVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 438);
            this.Controls.Add(this.MESHDisplay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GmeshVisualizer";
            this.Text = "GMESH Visualizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeshInfoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MESHDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem contourToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem meshToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox MESHDisplay;
        private System.Windows.Forms.DataGridView MeshInfoDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn ImageErrorType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorInfo;
        private System.Windows.Forms.Label MeshGradLabel;
    }
}

