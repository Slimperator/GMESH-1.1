namespace Prototype
{
    partial class Form1
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
            this.checkCoherenceButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBreaksButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Controls.Add(this.checkCoherenceButton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.checkBreaksButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(520, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 248);
            this.panel1.TabIndex = 4;
            // 
            // checkCoherenceButton
            // 
            this.checkCoherenceButton.Location = new System.Drawing.Point(212, 178);
            this.checkCoherenceButton.Name = "checkCoherenceButton";
            this.checkCoherenceButton.Size = new System.Drawing.Size(98, 27);
            this.checkCoherenceButton.TabIndex = 8;
            this.checkCoherenceButton.Text = "Проверить";
            this.checkCoherenceButton.UseVisualStyleBackColor = true;
            this.checkCoherenceButton.Click += new System.EventHandler(this.checkCoherenceButton_Click);
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
            // checkBreaksButton
            // 
            this.checkBreaksButton.Location = new System.Drawing.Point(33, 178);
            this.checkBreaksButton.Name = "checkBreaksButton";
            this.checkBreaksButton.Size = new System.Drawing.Size(98, 27);
            this.checkBreaksButton.TabIndex = 9;
            this.checkBreaksButton.Text = "Проверить";
            this.checkBreaksButton.UseVisualStyleBackColor = true;
            this.checkBreaksButton.Click += new System.EventHandler(this.checkBreaksButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(47, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Разрывы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(209, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Согласованность";
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(474, 354);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(520, 319);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(369, 136);
            this.textBox2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 494);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem contourToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem meshToolStripMenuItem1;
        private System.Windows.Forms.Button checkBreaksButton;
        private System.Windows.Forms.Button checkCoherenceButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meshToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
    }
}

