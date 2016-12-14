﻿namespace GMESH_Visualizer
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
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pentagonOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decomposeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decomposeOnTrianglesAndTetragonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decomposeWithStarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MESHDisplay = new System.Windows.Forms.PictureBox();
            this.MeshInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.ImageErrorType = new System.Windows.Forms.DataGridViewImageColumn();
            this.ErrorInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MESHDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeshInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pentagonOptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contourToolStripMenuItem,
            this.meshToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // contourToolStripMenuItem
            // 
            this.contourToolStripMenuItem.Name = "contourToolStripMenuItem";
            this.contourToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.contourToolStripMenuItem.Text = "Contour";
            this.contourToolStripMenuItem.Click += new System.EventHandler(this.contourToolStripMenuItem_Click);
            // 
            // meshToolStripMenuItem
            // 
            this.meshToolStripMenuItem.Name = "meshToolStripMenuItem";
            this.meshToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.meshToolStripMenuItem.Text = "Mesh";
            this.meshToolStripMenuItem.Click += new System.EventHandler(this.meshToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // pentagonOptionsToolStripMenuItem
            // 
            this.pentagonOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decomposeToolStripMenuItem,
            this.decomposeOnTrianglesAndTetragonToolStripMenuItem,
            this.decomposeWithStarToolStripMenuItem});
            this.pentagonOptionsToolStripMenuItem.Name = "pentagonOptionsToolStripMenuItem";
            this.pentagonOptionsToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.pentagonOptionsToolStripMenuItem.Text = "Pentagon Options";
            // 
            // decomposeToolStripMenuItem
            // 
            this.decomposeToolStripMenuItem.Name = "decomposeToolStripMenuItem";
            this.decomposeToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.decomposeToolStripMenuItem.Text = "Decompose  on triangles";
            // 
            // decomposeOnTrianglesAndTetragonToolStripMenuItem
            // 
            this.decomposeOnTrianglesAndTetragonToolStripMenuItem.Name = "decomposeOnTrianglesAndTetragonToolStripMenuItem";
            this.decomposeOnTrianglesAndTetragonToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.decomposeOnTrianglesAndTetragonToolStripMenuItem.Text = "Decompose on triangles and tetragon";
            // 
            // decomposeWithStarToolStripMenuItem
            // 
            this.decomposeWithStarToolStripMenuItem.Name = "decomposeWithStarToolStripMenuItem";
            this.decomposeWithStarToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.decomposeWithStarToolStripMenuItem.Text = "Decompose with star";
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(60, 431);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(76, 24);
            this.buildButton.TabIndex = 1;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(156, 431);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(76, 24);
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
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(520, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 148);
            this.panel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(47, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Качество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(47, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Информация о контуре";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox4.Location = new System.Drawing.Point(212, 75);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(212, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MESHDisplay
            // 
            this.MESHDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MESHDisplay.Location = new System.Drawing.Point(12, 41);
            this.MESHDisplay.Name = "MESHDisplay";
            this.MESHDisplay.Size = new System.Drawing.Size(474, 354);
            this.MESHDisplay.TabIndex = 5;
            this.MESHDisplay.TabStop = false;
            this.MESHDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.MESHDisplay_Paint);
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
            this.MeshInfoDataGridView.Location = new System.Drawing.Point(520, 207);
            this.MeshInfoDataGridView.Name = "MeshInfoDataGridView";
            this.MeshInfoDataGridView.ReadOnly = true;
            this.MeshInfoDataGridView.Size = new System.Drawing.Size(369, 248);
            this.MeshInfoDataGridView.TabIndex = 6;
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
            // GmeshVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 494);
            this.Controls.Add(this.MeshInfoDataGridView);
            this.Controls.Add(this.MESHDisplay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GmeshVisualizer";
            this.Text = "GMESH Visualizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MESHDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeshInfoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pentagonOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decomposeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decomposeOnTrianglesAndTetragonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decomposeWithStarToolStripMenuItem;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem contourToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem meshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meshToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox MESHDisplay;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.DataGridView MeshInfoDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn ImageErrorType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorInfo;
    }
}
