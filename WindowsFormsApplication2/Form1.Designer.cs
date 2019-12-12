namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.database1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.database2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDatabasePath1 = new System.Windows.Forms.Label();
            this.openDbButton1 = new System.Windows.Forms.Button();
            this.labelDatabasePath2 = new System.Windows.Forms.Label();
            this.openDbButton2 = new System.Windows.Forms.Button();
            this.databasePath1 = new System.Windows.Forms.TextBox();
            this.databasePath2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.openFileDialogDatabase1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogDatabase2 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(895, 449);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databasesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 31);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // databasesToolStripMenuItem
            // 
            this.databasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.databasesToolStripMenuItem.Name = "databasesToolStripMenuItem";
            this.databasesToolStripMenuItem.Size = new System.Drawing.Size(90, 31);
            this.databasesToolStripMenuItem.Text = "Databases";
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.compareToolStripMenuItem.Text = "Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.database1ToolStripMenuItem,
            this.database2ToolStripMenuItem});
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // database1ToolStripMenuItem
            // 
            this.database1ToolStripMenuItem.Name = "database1ToolStripMenuItem";
            this.database1ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.database1ToolStripMenuItem.Text = "Database 1";
            this.database1ToolStripMenuItem.Click += new System.EventHandler(this.database1ToolStripMenuItem_Click);
            // 
            // database2ToolStripMenuItem
            // 
            this.database2ToolStripMenuItem.Name = "database2ToolStripMenuItem";
            this.database2ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.database2ToolStripMenuItem.Text = "Database 2";
            this.database2ToolStripMenuItem.Click += new System.EventHandler(this.database2ToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.contactUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 31);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // contactUsToolStripMenuItem
            // 
            this.contactUsToolStripMenuItem.Name = "contactUsToolStripMenuItem";
            this.contactUsToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.contactUsToolStripMenuItem.Text = "Contact Us";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.46623F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.34378F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.18999F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.46623F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.34378F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.18999F));
            this.tableLayoutPanel2.Controls.Add(this.labelDatabasePath1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.openDbButton1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelDatabasePath2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.openDbButton2, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.databasePath1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.databasePath2, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(889, 44);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelDatabasePath1
            // 
            this.labelDatabasePath1.AutoSize = true;
            this.labelDatabasePath1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDatabasePath1.Location = new System.Drawing.Point(3, 5);
            this.labelDatabasePath1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelDatabasePath1.Name = "labelDatabasePath1";
            this.labelDatabasePath1.Size = new System.Drawing.Size(104, 39);
            this.labelDatabasePath1.TabIndex = 0;
            this.labelDatabasePath1.Text = "Database Location 1";
            // 
            // openDbButton1
            // 
            this.openDbButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openDbButton1.Location = new System.Drawing.Point(356, 3);
            this.openDbButton1.Name = "openDbButton1";
            this.openDbButton1.Size = new System.Drawing.Size(84, 38);
            this.openDbButton1.TabIndex = 2;
            this.openDbButton1.Text = "Open";
            this.openDbButton1.UseVisualStyleBackColor = true;
            this.openDbButton1.Click += new System.EventHandler(this.openDbButton1_Click);
            // 
            // labelDatabasePath2
            // 
            this.labelDatabasePath2.AutoSize = true;
            this.labelDatabasePath2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDatabasePath2.Location = new System.Drawing.Point(446, 5);
            this.labelDatabasePath2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelDatabasePath2.Name = "labelDatabasePath2";
            this.labelDatabasePath2.Size = new System.Drawing.Size(104, 39);
            this.labelDatabasePath2.TabIndex = 3;
            this.labelDatabasePath2.Text = "Database Location 2";
            // 
            // openDbButton2
            // 
            this.openDbButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openDbButton2.Location = new System.Drawing.Point(799, 3);
            this.openDbButton2.Name = "openDbButton2";
            this.openDbButton2.Size = new System.Drawing.Size(87, 38);
            this.openDbButton2.TabIndex = 5;
            this.openDbButton2.Text = "Open";
            this.openDbButton2.UseVisualStyleBackColor = true;
            this.openDbButton2.Click += new System.EventHandler(this.openDbButton2_Click);
            // 
            // databasePath1
            // 
            this.databasePath1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasePath1.Location = new System.Drawing.Point(113, 12);
            this.databasePath1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.databasePath1.Name = "databasePath1";
            this.databasePath1.Size = new System.Drawing.Size(237, 22);
            this.databasePath1.TabIndex = 6;
            this.databasePath1.Click += new System.EventHandler(this.databasePath1_Click);
            this.databasePath1.DoubleClick += new System.EventHandler(this.databasePath1_DoubleClick);
            // 
            // databasePath2
            // 
            this.databasePath2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasePath2.Location = new System.Drawing.Point(556, 12);
            this.databasePath2.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.databasePath2.Name = "databasePath2";
            this.databasePath2.Size = new System.Drawing.Size(237, 22);
            this.databasePath2.TabIndex = 7;
            this.databasePath2.Click += new System.EventHandler(this.databasePath2_Click);
            this.databasePath2.DoubleClick += new System.EventHandler(this.databasePath2_DoubleClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataGridView2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 88);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(889, 358);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(438, 352);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(447, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(439, 352);
            this.dataGridView2.TabIndex = 1;
            // 
            // openFileDialogDatabase1
            // 
            this.openFileDialogDatabase1.FileName = "openFileDialogDatabase1";
            // 
            // openFileDialogDatabase2
            // 
            this.openFileDialogDatabase2.FileName = "openFileDialogDatabase2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 449);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelDatabasePath1;
        private System.Windows.Forms.Button openDbButton1;
        private System.Windows.Forms.Label labelDatabasePath2;
        private System.Windows.Forms.Button openDbButton2;
        private System.Windows.Forms.TextBox databasePath1;
        private System.Windows.Forms.TextBox databasePath2;
        private System.Windows.Forms.OpenFileDialog openFileDialogDatabase1;
        private System.Windows.Forms.OpenFileDialog openFileDialogDatabase2;
        private System.Windows.Forms.ToolStripMenuItem databasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem database1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem database2ToolStripMenuItem;
    }
}

