namespace SQLBackup
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
            this.ExitProgram();

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Backup = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.Unzip = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AutoRestore = new System.Windows.Forms.CheckBox();
            this.Compression = new System.Windows.Forms.CheckBox();
            this.BackupFileBrowse = new System.Windows.Forms.Button();
            this.BackupLocation = new System.Windows.Forms.TextBox();
            this.SourceDatabase = new System.Windows.Forms.ComboBox();
            this.SourceInstance = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DefaultDatabasePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Restore = new System.Windows.Forms.Button();
            this.RestoreFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ZipFileBrowse = new System.Windows.Forms.Button();
            this.Zip = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RestoreFileBrowse = new System.Windows.Forms.Button();
            this.RestoreDefaultBrowse = new System.Windows.Forms.Button();
            this.DestinationDatabase = new System.Windows.Forms.ComboBox();
            this.DestinationInstance = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zealocity2006ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wwwzealocitycomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Instance Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Source Database Name";
            // 
            // Backup
            // 
            this.Backup.Location = new System.Drawing.Point(26, 211);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(75, 23);
            this.Backup.TabIndex = 5;
            this.Backup.Text = "Backup";
            this.Backup.UseVisualStyleBackColor = true;
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(541, 432);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 5;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Full File Name";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(21, 43);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(559, 20);
            this.FileName.TabIndex = 13;
            this.toolTip1.SetToolTip(this.FileName, "Select a file to manually zip or unzip");
            // 
            // Unzip
            // 
            this.Unzip.Location = new System.Drawing.Point(471, 72);
            this.Unzip.Name = "Unzip";
            this.Unzip.Size = new System.Drawing.Size(75, 23);
            this.Unzip.TabIndex = 16;
            this.Unzip.Text = "UnZip";
            this.Unzip.UseVisualStyleBackColor = true;
            this.Unzip.Click += new System.EventHandler(this.Unzip_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AutoRestore);
            this.groupBox1.Controls.Add(this.Compression);
            this.groupBox1.Controls.Add(this.BackupFileBrowse);
            this.groupBox1.Controls.Add(this.BackupLocation);
            this.groupBox1.Controls.Add(this.SourceDatabase);
            this.groupBox1.Controls.Add(this.SourceInstance);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Backup);
            this.groupBox1.Location = new System.Drawing.Point(6, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 244);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Backup";
            // 
            // AutoRestore
            // 
            this.AutoRestore.AutoSize = true;
            this.AutoRestore.Location = new System.Drawing.Point(21, 175);
            this.AutoRestore.Name = "AutoRestore";
            this.AutoRestore.Size = new System.Drawing.Size(128, 17);
            this.AutoRestore.TabIndex = 4;
            this.AutoRestore.Text = "Restore After Backup";
            this.AutoRestore.UseVisualStyleBackColor = true;
            // 
            // Compression
            // 
            this.Compression.AutoSize = true;
            this.Compression.Location = new System.Drawing.Point(21, 152);
            this.Compression.Name = "Compression";
            this.Compression.Size = new System.Drawing.Size(108, 17);
            this.Compression.TabIndex = 3;
            this.Compression.Text = "Use Compression";
            this.toolTip1.SetToolTip(this.Compression, "Select this to enabled compression of the backup file");
            this.Compression.UseVisualStyleBackColor = true;
            // 
            // BackupFileBrowse
            // 
            this.BackupFileBrowse.AutoSize = true;
            this.BackupFileBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackupFileBrowse.BackgroundImage")));
            this.BackupFileBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackupFileBrowse.Location = new System.Drawing.Point(272, 126);
            this.BackupFileBrowse.Name = "BackupFileBrowse";
            this.BackupFileBrowse.Size = new System.Drawing.Size(26, 23);
            this.BackupFileBrowse.TabIndex = 14;
            this.BackupFileBrowse.UseVisualStyleBackColor = true;
            this.BackupFileBrowse.Click += new System.EventHandler(this.BackupFileBrowse_Click);
            // 
            // BackupLocation
            // 
            this.BackupLocation.Location = new System.Drawing.Point(21, 126);
            this.BackupLocation.Name = "BackupLocation";
            this.BackupLocation.Size = new System.Drawing.Size(255, 20);
            this.BackupLocation.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BackupLocation, "Select the path of where the sql backup file should be created");
            // 
            // SourceDatabase
            // 
            this.SourceDatabase.FormattingEnabled = true;
            this.SourceDatabase.Location = new System.Drawing.Point(21, 82);
            this.SourceDatabase.Name = "SourceDatabase";
            this.SourceDatabase.Size = new System.Drawing.Size(267, 21);
            this.SourceDatabase.TabIndex = 1;
            this.toolTip1.SetToolTip(this.SourceDatabase, "Select a database to backup or leave empty to backup every database");
            // 
            // SourceInstance
            // 
            this.SourceInstance.FormattingEnabled = true;
            this.SourceInstance.Location = new System.Drawing.Point(21, 42);
            this.SourceInstance.Name = "SourceInstance";
            this.SourceInstance.Size = new System.Drawing.Size(265, 21);
            this.SourceInstance.TabIndex = 0;
            this.toolTip1.SetToolTip(this.SourceInstance, "Select a server to backup a database from");
            this.SourceInstance.SelectedIndexChanged += new System.EventHandler(this.SourceInstance_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Backup Location";
            // 
            // DefaultDatabasePath
            // 
            this.DefaultDatabasePath.Location = new System.Drawing.Point(8, 125);
            this.DefaultDatabasePath.Name = "DefaultDatabasePath";
            this.DefaultDatabasePath.Size = new System.Drawing.Size(256, 20);
            this.DefaultDatabasePath.TabIndex = 8;
            this.toolTip1.SetToolTip(this.DefaultDatabasePath, "Select the folder where you would like the database to be restored to or leave bl" +
                    "ank to use the default location");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Default Database Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Restore Database Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Restore Instance Name";
            // 
            // Restore
            // 
            this.Restore.Location = new System.Drawing.Point(18, 210);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(75, 23);
            this.Restore.TabIndex = 12;
            this.Restore.Text = "Restore";
            this.Restore.UseVisualStyleBackColor = true;
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // RestoreFileName
            // 
            this.RestoreFileName.Location = new System.Drawing.Point(8, 165);
            this.RestoreFileName.Name = "RestoreFileName";
            this.RestoreFileName.Size = new System.Drawing.Size(256, 20);
            this.RestoreFileName.TabIndex = 10;
            this.toolTip1.SetToolTip(this.RestoreFileName, "Select the sql backup file");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Restore File Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ZipFileBrowse);
            this.groupBox2.Controls.Add(this.Zip);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.FileName);
            this.groupBox2.Controls.Add(this.Unzip);
            this.groupBox2.Location = new System.Drawing.Point(6, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 109);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compression";
            // 
            // ZipFileBrowse
            // 
            this.ZipFileBrowse.AutoSize = true;
            this.ZipFileBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ZipFileBrowse.BackgroundImage")));
            this.ZipFileBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ZipFileBrowse.Location = new System.Drawing.Point(575, 43);
            this.ZipFileBrowse.Name = "ZipFileBrowse";
            this.ZipFileBrowse.Size = new System.Drawing.Size(26, 23);
            this.ZipFileBrowse.TabIndex = 14;
            this.ZipFileBrowse.UseVisualStyleBackColor = true;
            this.ZipFileBrowse.Click += new System.EventHandler(this.ZipFileBrowse_Click);
            // 
            // Zip
            // 
            this.Zip.Location = new System.Drawing.Point(334, 72);
            this.Zip.Name = "Zip";
            this.Zip.Size = new System.Drawing.Size(75, 23);
            this.Zip.TabIndex = 15;
            this.Zip.Text = "Zip";
            this.Zip.UseVisualStyleBackColor = true;
            this.Zip.Click += new System.EventHandler(this.Zip_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RestoreFileBrowse);
            this.groupBox3.Controls.Add(this.RestoreDefaultBrowse);
            this.groupBox3.Controls.Add(this.DestinationDatabase);
            this.groupBox3.Controls.Add(this.DestinationInstance);
            this.groupBox3.Controls.Add(this.Restore);
            this.groupBox3.Controls.Add(this.DefaultDatabasePath);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.RestoreFileName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(322, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 243);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database Restore";
            // 
            // RestoreFileBrowse
            // 
            this.RestoreFileBrowse.AutoSize = true;
            this.RestoreFileBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RestoreFileBrowse.BackgroundImage")));
            this.RestoreFileBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RestoreFileBrowse.Location = new System.Drawing.Point(259, 165);
            this.RestoreFileBrowse.Name = "RestoreFileBrowse";
            this.RestoreFileBrowse.Size = new System.Drawing.Size(26, 23);
            this.RestoreFileBrowse.TabIndex = 11;
            this.RestoreFileBrowse.UseVisualStyleBackColor = true;
            this.RestoreFileBrowse.Click += new System.EventHandler(this.RestoreFileBrowse_Click_1);
            // 
            // RestoreDefaultBrowse
            // 
            this.RestoreDefaultBrowse.AutoSize = true;
            this.RestoreDefaultBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RestoreDefaultBrowse.BackgroundImage")));
            this.RestoreDefaultBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RestoreDefaultBrowse.Location = new System.Drawing.Point(259, 125);
            this.RestoreDefaultBrowse.Name = "RestoreDefaultBrowse";
            this.RestoreDefaultBrowse.Size = new System.Drawing.Size(26, 23);
            this.RestoreDefaultBrowse.TabIndex = 9;
            this.RestoreDefaultBrowse.UseVisualStyleBackColor = true;
            this.RestoreDefaultBrowse.Click += new System.EventHandler(this.RestoreDefaultBrowse_Click);
            // 
            // DestinationDatabase
            // 
            this.DestinationDatabase.FormattingEnabled = true;
            this.DestinationDatabase.Location = new System.Drawing.Point(7, 81);
            this.DestinationDatabase.Name = "DestinationDatabase";
            this.DestinationDatabase.Size = new System.Drawing.Size(267, 21);
            this.DestinationDatabase.TabIndex = 7;
            this.toolTip1.SetToolTip(this.DestinationDatabase, "Select a database to restore to");
            // 
            // DestinationInstance
            // 
            this.DestinationInstance.FormattingEnabled = true;
            this.DestinationInstance.Location = new System.Drawing.Point(8, 41);
            this.DestinationInstance.Name = "DestinationInstance";
            this.DestinationInstance.Size = new System.Drawing.Size(266, 21);
            this.DestinationInstance.TabIndex = 6;
            this.toolTip1.SetToolTip(this.DestinationInstance, "Select a server to restore a database to");
            this.DestinationInstance.SelectedIndexChanged += new System.EventHandler(this.DestinationInstance_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zealocity2006ToolStripMenuItem,
            this.wwwzealocitycomToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // zealocity2006ToolStripMenuItem
            // 
            this.zealocity2006ToolStripMenuItem.Name = "zealocity2006ToolStripMenuItem";
            this.zealocity2006ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.zealocity2006ToolStripMenuItem.Text = "Zealocity 2006";
            // 
            // wwwzealocitycomToolStripMenuItem
            // 
            this.wwwzealocitycomToolStripMenuItem.Name = "wwwzealocitycomToolStripMenuItem";
            this.wwwzealocitycomToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.wwwzealocitycomToolStripMenuItem.Text = "www.zealocity.com";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(600, 17);
            this.toolStripStatusLabel1.Text = "idle";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 417);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLBackup";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Backup;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Button Unzip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Zip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BackupLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Restore;
        private System.Windows.Forms.TextBox RestoreFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DefaultDatabasePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox SourceInstance;
        private System.Windows.Forms.ComboBox DestinationInstance;
        private System.Windows.Forms.ComboBox DestinationDatabase;
        private System.Windows.Forms.ComboBox SourceDatabase;
        private System.Windows.Forms.Button ZipFileBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BackupFileBrowse;
        private System.Windows.Forms.Button RestoreDefaultBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button RestoreFileBrowse;
        private System.Windows.Forms.CheckBox Compression;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zealocity2006ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wwwzealocitycomToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox AutoRestore;
    }
}

