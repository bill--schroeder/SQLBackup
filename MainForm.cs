using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zealocity;

namespace SQLBackup
{
    public partial class MainForm : Form
    {
        LoggingClass Logging = new LoggingClass();


        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion Constructor


        #region MainForm_Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            SQLFunctions sqlFunctions = new SQLFunctions();
            string message = string.Empty;

            message = "Starting program";
            LogMessage(message);

            // populate the sql instances on the network
            SourceInstance.Items.Clear();
            DestinationInstance.Items.Clear();
            string[] SQLInstances = sqlFunctions.FindSQLInstances();
            for (int i = 0; i < SQLInstances.Length; i++)
            {
                SourceInstance.Items.Add(SQLInstances[i]);
                DestinationInstance.Items.Add(SQLInstances[i]);
            }

            sqlFunctions = null;

            this.SourceInstance.Text = Properties.Settings.Default.SourceInstanceName;
            
            this.DestinationInstance.Text = Properties.Settings.Default.RestoreInstance;

            // set the backup location
            SetBackupPath();

            // set the default restore path
            SetRestorePath();

            // is compression enabled
            this.Compression.Checked = Properties.Settings.Default.UseCompression;
            if (Properties.Settings.Default.UseCompression)
            {
                message = "Compression Enabled!";
                LogMessage(message);
            }

            // is auto restore enabled
            this.AutoRestore.Checked = Properties.Settings.Default.AutoRestore;
            if (Properties.Settings.Default.AutoRestore)
            {
                message = "AutoRestore Enabled!";
                LogMessage(message);
            }

            this.Text = Application.ProductName + " - " + Application.ProductVersion;
            this.Show();
            Application.DoEvents();

            // should the program autorun
            if (Properties.Settings.Default.AutoRun)
            {
                this.WindowState = FormWindowState.Minimized;

                message = "******* AutoRun Enabled! *******";
                LogMessage(message);

                BackupDatabase();

                ExitProgram();
            }
        }
        #endregion MainForm_Load


        #region BackupDatabase
        private void BackupDatabase()
        {
            string message = string.Empty;

            if(SourceDatabase.Text.Trim().Equals(string.Empty))
            {
                // backup every database on the server

                // log start
                message = "Starting multiple database backups";
                LogMessage(message);

                SQLFunctions sqlFunctions = new SQLFunctions();

                string[] SQLDatabases = sqlFunctions.GetSQLDatabases(SourceInstance.Text, true);
                for (int i = 0; i < SQLDatabases.Length - 1; i++)
                {
                    BackupDatabase(SourceInstance.Text.Trim(), SQLDatabases[i].Trim());
                }

                // log finish
                message = "Finished multiple database backups";
                LogMessage(message);

                sqlFunctions = null;
            }
            else
            {
                // backup a single database
                BackupDatabase(SourceInstance.Text.Trim(), SourceDatabase.Text.Trim());

                // should we auto restore
                if (this.AutoRestore.Checked && Properties.Settings.Default.AddDateTimeStamp == false)
                {
                    this.DestinationDatabase.Text = this.SourceDatabase.Text.Trim();

                    RestoreDatabase();
                }       // should we auto restore
            }
        }

        private void BackupDatabase(string ServerName, string DatabaseName)
        {
            SQLFunctions sqlFunctions = new SQLFunctions();
            string message = string.Empty;
            string destinationPath = string.Empty;
            string Return = string.Empty;

            // set the backup type
            sqlFunctions.BackupType = SetBackupType();

            // log start
            message = "Starting " + sqlFunctions.BackupType + " database backup: " + ServerName + "." + DatabaseName;
            LogMessage(message);

            // set the backup path
            sqlFunctions.DestinationPath = SetBackupPath();

            // start backup
            Return = sqlFunctions.BackupDatabase(ServerName, DatabaseName);

            // log backup status
            message = "Backup status: " + Return;
            LogMessage(message);

            // was the backup successful
            if (Return.ToUpper().StartsWith("SUCCESS"))
            {
                SetCompression();

                // should we compress this file
                if (Properties.Settings.Default.UseCompression)
                {
                    destinationPath = Return.Split('|')[1];

                    Compress(destinationPath);

                    if (Return.ToUpper().StartsWith("SUCCESS"))
                    {
                        // delete the non-zipped backup file
                        System.IO.File.Delete(destinationPath);
                    }
                }       // should we compress this file
            }       // was the backup successful

            // log finish
            message = "Finished database backup: " + ServerName + "." + DatabaseName + " " + Return;
            LogMessage(message);

            //// should we auto restore
            //if (this.AutoRestore.Checked && Properties.Settings.Default.AddDateTimeStamp == false)
            //{
            //    RestoreDatabase();
            //}       // should we auto restore

            sqlFunctions = null;
        }
        #endregion BackupDatabase


        #region RestoreDatabase
        private void RestoreDatabase()
        {
            SQLFunctions sqlFunctions = new SQLFunctions();
            string message = string.Empty;
            string destinationPath = string.Empty;
            string backupLocation = string.Empty;
            string restoreFileName = string.Empty;
            string databaseName = string.Empty;
            string Return = string.Empty;

            // set the backup type
            sqlFunctions.BackupType = SetBackupType();

            // set the database name to restore
            databaseName = this.DestinationDatabase.Text.Trim();

            // set the backup path
            sqlFunctions.DestinationPath = SetBackupPath();
            backupLocation = sqlFunctions.DestinationPath + databaseName + @"\";

            // set the default database path
            sqlFunctions.DefaultDatabasePath = SetRestorePath();

            // set the restore file name
            if (this.RestoreFileName.Text.Trim().Equals(string.Empty))
                restoreFileName = databaseName + "_" + SetBackupType() + "_SQLBackup.bak";
            else
            {
                restoreFileName = this.RestoreFileName.Text.Trim();
                if(restoreFileName.ToUpper().EndsWith(".ZIP"))
                    restoreFileName = restoreFileName.Substring(0, restoreFileName.LastIndexOf("."));
            }

            // is compression enabled
            SetCompression();
            if (Properties.Settings.Default.UseCompression || restoreFileName.ToUpper().EndsWith(".ZIP"))
            {
                destinationPath = backupLocation + restoreFileName + ".zip";

                Decompress(destinationPath);
            }       // is compression enabled

            // log start
            message = "Starting database restore: " + this.DestinationInstance.Text.Trim() + "." + databaseName;
            LogMessage(message);

            // start restore
            Return = sqlFunctions.RestoreDatabase(this.DestinationInstance.Text.Trim(), databaseName, restoreFileName);

            // log status
            message = "Restore status: " + Return;
            LogMessage(message);

            // is compression enabled
            if (Properties.Settings.Default.UseCompression)
            {
                try
                {
                    // delete the unzipped backup file
                    System.IO.File.Delete(backupLocation + restoreFileName);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                    message = "ERROR deleting unzipped backup file: " + error;
                    LogMessage(message);
                }
            }

            // log finish
            message = "Finished database restore: " + this.DestinationInstance.Text.Trim() + "." + databaseName + " " + Return;
            LogMessage(message);
            message = "Finished database restore: " + this.DestinationInstance.Text.Trim() + "." + databaseName;
            LogMessage(message);

            sqlFunctions = null;
        }       // RestoreDatabase
        #endregion RestoreDatabase


        #region Compress
        private string Compress(string Filename)
        {
            CompressionClass compression = new CompressionClass();
            string message = string.Empty;
            string Return = string.Empty;

            // log start
            message = "Starting zip: " + Filename;
            LogMessage(message);

            //FileName.Text = @"F:\Backups\WebSearchIndex\WebSearchIndex_SQLBackup.bak";
            //FileName.Text = @"F:\Backups\test.txt";
            Return = compression.CompressFile(Filename);
            //message = compression.DecompressFile(this.FileName.Text.Trim() + ".zip");

            // log status
            message = "Zip status: " + Return;
            LogMessage(message);

            // log finish
            message = "Finished zipping: " + Filename;
            LogMessage(message);

            compression = null;

            return Return;
        }
        #endregion Compress


        #region Decompress
        private string Decompress(string Filename)
        {
            CompressionClass compression = new CompressionClass();
            string message = string.Empty;
            string Return = string.Empty;

            // log start
            message = "Starting unzip: " + Filename;
            LogMessage(message);

            Return = compression.DecompressFile(Filename);

            // log status
            message = "Unzip status: " + Return;
            LogMessage(message);

            // log finish
            message = "Finished unzipping: " + Filename;
            LogMessage(message);

            compression = null;

            return Return;
        }
        #endregion Decompress


        #region Private Methods
        private void LogMessage(string Message)
        {
            if(Properties.Settings.Default.EnableLogging)
                Logging.LogMessage(Application.StartupPath, Application.ProductName, Message);

            this.toolStripStatusLabel1.Text = Message;
            Application.DoEvents();
        }


        private bool SetCompression()
        {
            bool compression = Properties.Settings.Default.UseCompression;

            if (!this.Compression.Checked.Equals(compression))
            {
                //Properties.Settings.Default.UseCompression = this.Compression.Checked;
                Properties.Settings.Default.Save();
            }

            return this.Compression.Checked;
        }


        private string SetBackupType()
        {
            string Return = string.Empty;

            Return = Properties.Settings.Default.BackupType;
            if (Return.Trim().Equals(string.Empty))
                Return = "Complete";

            Properties.Settings.Default.Save();

            return Return;
        }


        private string SetBackupPath()
        {
            if (this.BackupLocation.Text.Trim().Equals(string.Empty))
            {
                string backupLocation = Properties.Settings.Default.BackupLocation;
                if (backupLocation.Trim().Equals(string.Empty))
                    backupLocation = Application.StartupPath;
                this.BackupLocation.Text = backupLocation;
            }

            if (!BackupLocation.Text.EndsWith(@"\"))
                BackupLocation.Text += @"\";

            //Properties.Settings.Default.BackupLocation = BackupLocation.Text;
            Properties.Settings.Default.Save();

            return this.BackupLocation.Text;
        }


        private string SetRestorePath()
        {
            if (this.DefaultDatabasePath.Text.Trim().Equals(string.Empty))
            {
                string defaultDatabasePath = Properties.Settings.Default.DefaultDatabasePath;
                //if (defaultDatabasePath.Trim().Equals(string.Empty))
                    //defaultDatabasePath = Application.StartupPath;
                this.DefaultDatabasePath.Text = defaultDatabasePath;
            }

            if (!DefaultDatabasePath.Text.EndsWith(@"\") && DefaultDatabasePath.Text.Trim().Length > 1)
                DefaultDatabasePath.Text += @"\";

            //Properties.Settings.Default.DefaultDatabasePath = DefaultDatabasePath.Text;
            Properties.Settings.Default.Save();

            return this.DefaultDatabasePath.Text;
        }


        private void SaveSettings()
        {
            // save the settings
            SetCompression();
            SetBackupPath();
            SetRestorePath();
        }


        private void ExitProgram()
        {
            SaveSettings();

            //string message = "Ending program";
            //LogMessage(message);

            Application.DoEvents();
            Application.ExitThread();
            Application.Exit();
        }
        #endregion Private Methods


        #region Form Events

        #region Form Buttons

        private void Backup_Click(object sender, EventArgs e)
        {
            BackupDatabase();
        }


        private void Restore_Click(object sender, EventArgs e)
        {
            RestoreDatabase();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }


        private void Unzip_Click(object sender, EventArgs e)
        {
            Decompress(this.FileName.Text.Trim());
        }


        private void Zip_Click(object sender, EventArgs e)
        {
            Compress(this.FileName.Text.Trim());
        }


        private void ZipFileBrowse_Click(object sender, EventArgs e)
        {
            if (this.FileName.Text.Trim().Equals(string.Empty))
                this.openFileDialog1.FileName = Application.ExecutablePath;
            else
                this.openFileDialog1.FileName = this.FileName.Text;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr.ToString().ToUpper().Equals("OK"))
                this.FileName.Text = this.openFileDialog1.FileName.ToString();
        }


        private void BackupFileBrowse_Click(object sender, EventArgs e)
        {
            if (this.BackupLocation.Text.Trim().Equals(string.Empty))
                this.folderBrowserDialog1.SelectedPath = Application.StartupPath;
            else
                this.folderBrowserDialog1.SelectedPath = this.BackupLocation.Text;

            DialogResult dr = this.folderBrowserDialog1.ShowDialog();

            if (dr.ToString().ToUpper().Equals("OK"))
                this.BackupLocation.Text = this.folderBrowserDialog1.SelectedPath.ToString();
        }


        private void RestoreDefaultBrowse_Click(object sender, EventArgs e)
        {
            if (this.DefaultDatabasePath.Text.Trim().Equals(string.Empty))
                this.folderBrowserDialog1.SelectedPath = Application.StartupPath;
            else
                this.folderBrowserDialog1.SelectedPath = this.DefaultDatabasePath.Text;

            DialogResult dr = this.folderBrowserDialog1.ShowDialog();

            if (dr.ToString().ToUpper().Equals("OK"))
                this.DefaultDatabasePath.Text = this.folderBrowserDialog1.SelectedPath.ToString();
        }


        private void RestoreFileBrowse_Click_1(object sender, EventArgs e)
        {
            if (this.RestoreFileName.Text.Trim().Equals(string.Empty))
                this.openFileDialog1.FileName = Application.ExecutablePath;
            else
                this.openFileDialog1.FileName = this.RestoreFileName.Text;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr.ToString().ToUpper().Equals("OK"))
            {
                string file = this.openFileDialog1.FileName.ToString();
                int start = file.LastIndexOf(@"\") + 1;
                this.RestoreFileName.Text = file.Substring(start, file.Length - start);
            }
        }

        #endregion Form Buttons

        #region Menu Methods

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        #endregion Menu Methods

        private void SourceInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLFunctions sqlFunctions = new SQLFunctions();

            SourceDatabase.Items.Clear();
            string[] SQLDatabases = sqlFunctions.GetSQLDatabases(SourceInstance.Text, true);
            for (int i = 0; i < SQLDatabases.Length - 1; i++)
            {
                SourceDatabase.Items.Add(SQLDatabases[i]);
            }
            
            sqlFunctions = null;
        }

        private void DestinationInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLFunctions sqlFunctions = new SQLFunctions();

            DestinationDatabase.Items.Clear();
            string[] SQLDestinationDatabases = sqlFunctions.GetSQLDatabases(DestinationInstance.Text, true);
            for (int i = 0; i < SQLDestinationDatabases.Length - 1; i++)
            {
                DestinationDatabase.Items.Add(SQLDestinationDatabases[i]);
            }

            sqlFunctions = null;
        }
        #endregion Form Events

    }
}