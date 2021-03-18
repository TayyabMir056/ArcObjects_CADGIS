namespace CADtoGIS_Test1
{
    partial class Form_BrowseCADFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BrowseCADFile));
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.button_Open = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Output = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBox_repairGeom = new System.Windows.Forms.CheckBox();
            this.pictureBox_tempGDB = new System.Windows.Forms.PictureBox();
            this.label_tempGDB = new System.Windows.Forms.Label();
            this.textBox_tempGDB = new System.Windows.Forms.TextBox();
            this.Additional = new System.Windows.Forms.Label();
            this.textBox_commaSeparated = new System.Windows.Forms.TextBox();
            this.label_Ignore = new System.Windows.Forms.Label();
            this.Default = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tempGDB)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Enabled = false;
            this.textBox_FilePath.Location = new System.Drawing.Point(86, 12);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.Size = new System.Drawing.Size(237, 20);
            this.textBox_FilePath.TabIndex = 0;
            this.textBox_FilePath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(295, 241);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(59, 23);
            this.button_Open.TabIndex = 1;
            this.button_Open.Text = "Open";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(329, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(232, 241);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(57, 23);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input CAD file :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output File :";
            // 
            // textBox_Output
            // 
            this.textBox_Output.Enabled = false;
            this.textBox_Output.Location = new System.Drawing.Point(86, 37);
            this.textBox_Output.Name = "textBox_Output";
            this.textBox_Output.Size = new System.Drawing.Size(237, 20);
            this.textBox_Output.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(329, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // checkBox_repairGeom
            // 
            this.checkBox_repairGeom.AutoSize = true;
            this.checkBox_repairGeom.Location = new System.Drawing.Point(5, 63);
            this.checkBox_repairGeom.Name = "checkBox_repairGeom";
            this.checkBox_repairGeom.Size = new System.Drawing.Size(192, 17);
            this.checkBox_repairGeom.TabIndex = 8;
            this.checkBox_repairGeom.Text = "Repair Geometry before Converting";
            this.checkBox_repairGeom.UseVisualStyleBackColor = true;
            this.checkBox_repairGeom.Visible = false;
            this.checkBox_repairGeom.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox_tempGDB
            // 
            this.pictureBox_tempGDB.Enabled = false;
            this.pictureBox_tempGDB.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_tempGDB.Image")));
            this.pictureBox_tempGDB.Location = new System.Drawing.Point(329, 81);
            this.pictureBox_tempGDB.Name = "pictureBox_tempGDB";
            this.pictureBox_tempGDB.Size = new System.Drawing.Size(25, 22);
            this.pictureBox_tempGDB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tempGDB.TabIndex = 11;
            this.pictureBox_tempGDB.TabStop = false;
            this.pictureBox_tempGDB.Visible = false;
            // 
            // label_tempGDB
            // 
            this.label_tempGDB.AutoSize = true;
            this.label_tempGDB.Enabled = false;
            this.label_tempGDB.Location = new System.Drawing.Point(2, 86);
            this.label_tempGDB.Name = "label_tempGDB";
            this.label_tempGDB.Size = new System.Drawing.Size(83, 13);
            this.label_tempGDB.TabIndex = 10;
            this.label_tempGDB.Text = "Temporary GDB";
            this.label_tempGDB.Visible = false;
            this.label_tempGDB.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox_tempGDB
            // 
            this.textBox_tempGDB.Enabled = false;
            this.textBox_tempGDB.Location = new System.Drawing.Point(86, 83);
            this.textBox_tempGDB.Name = "textBox_tempGDB";
            this.textBox_tempGDB.Size = new System.Drawing.Size(237, 20);
            this.textBox_tempGDB.TabIndex = 9;
            this.textBox_tempGDB.Visible = false;
            // 
            // Additional
            // 
            this.Additional.AutoSize = true;
            this.Additional.Location = new System.Drawing.Point(2, 221);
            this.Additional.Name = "Additional";
            this.Additional.Size = new System.Drawing.Size(53, 13);
            this.Additional.TabIndex = 13;
            this.Additional.Text = "Additional";
            // 
            // textBox_commaSeparated
            // 
            this.textBox_commaSeparated.Location = new System.Drawing.Point(91, 215);
            this.textBox_commaSeparated.Name = "textBox_commaSeparated";
            this.textBox_commaSeparated.Size = new System.Drawing.Size(263, 20);
            this.textBox_commaSeparated.TabIndex = 12;
            // 
            // label_Ignore
            // 
            this.label_Ignore.AutoSize = true;
            this.label_Ignore.Enabled = false;
            this.label_Ignore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ignore.Location = new System.Drawing.Point(2, 109);
            this.label_Ignore.Name = "label_Ignore";
            this.label_Ignore.Size = new System.Drawing.Size(141, 13);
            this.label_Ignore.TabIndex = 14;
            this.label_Ignore.Text = "Ignore Layers to import:";
            // 
            // Default
            // 
            this.Default.AutoSize = true;
            this.Default.Enabled = false;
            this.Default.Location = new System.Drawing.Point(2, 125);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(41, 13);
            this.Default.TabIndex = 15;
            this.Default.Text = "Default";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "(Comma Separated)";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "GRID",
            "ROAD",
            "WELL",
            "BOUNDARY",
            "ELECTRICITY"});
            this.checkedListBox1.Location = new System.Drawing.Point(91, 125);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(171, 79);
            this.checkedListBox1.TabIndex = 18;
            // 
            // Form_BrowseCADFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 272);
            this.ControlBox = false;
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Default);
            this.Controls.Add(this.label_Ignore);
            this.Controls.Add(this.Additional);
            this.Controls.Add(this.textBox_commaSeparated);
            this.Controls.Add(this.pictureBox_tempGDB);
            this.Controls.Add(this.label_tempGDB);
            this.Controls.Add(this.textBox_tempGDB);
            this.Controls.Add(this.checkBox_repairGeom);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.textBox_FilePath);
            this.Name = "Form_BrowseCADFile";
            this.Text = "Import CAD to GIS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tempGDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_FilePath;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Output;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox_repairGeom;
        private System.Windows.Forms.PictureBox pictureBox_tempGDB;
        private System.Windows.Forms.Label label_tempGDB;
        private System.Windows.Forms.TextBox textBox_tempGDB;
        private System.Windows.Forms.Label Additional;
        private System.Windows.Forms.TextBox textBox_commaSeparated;
        private System.Windows.Forms.Label label_Ignore;
        private System.Windows.Forms.Label Default;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}