using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zealocity;
using System.Runtime.InteropServices;

namespace SQLBackup
{
    class SQLFunctions
    {
        #region Member Variables

        [DllImport("odbc32.dll")]
        private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);
        [DllImport("odbc32.dll")]
        private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);
        [DllImport("odbc32.dll")]
        private static extern short SQLFreeHandle(short hType, IntPtr handle);
        [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
        private static extern short SQLBrowseConnect(IntPtr hconn, StringBuilder inString,
            short inStringLength, StringBuilder outString, short outStringLength,
            out short outLengthNeeded);

        private const short SQL_HANDLE_ENV = 1;
        private const short SQL_HANDLE_DBC = 2;
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_SUCCESS = 0;

        private const short SQL_NEED_DATA = 99;
        private const short DEFAULT_RESULT_SIZE = 1024;
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

        #endregion Member Variables


        #region Properties

        public string BackupType = string.Empty;
        public string DestinationPath = string.Empty;
        public string DefaultDatabasePath = string.Empty;
        
        #endregion Properties


        #region AddDumpDevice
        private string AddDumpDevice(string ServerName, string DatabaseName, string BackupDevice)
        {
            DatabaseClass database = new DatabaseClass();
            string destinationPath = string.Empty;
            string SQLQuery = string.Empty;
            string Return = string.Empty;

            database.ServerName = ServerName;
            database.DatabaseName = "master";

            try
            {
                if (DestinationPath.Trim().Equals(string.Empty))
                    destinationPath = @"C:\" + DatabaseName + @"\" + BackupDevice + ".bak";
                else
                    destinationPath = DestinationPath + DatabaseName + @"\" + BackupDevice + ".bak";

                System.IO.Directory.CreateDirectory(destinationPath.Substring(0, destinationPath.LastIndexOf(@"\")));

                SQLQuery = "EXEC sp_addumpdevice 'DISK','" + BackupDevice + @"','" + destinationPath + "'";
                database.RunSQLStatement(SQLQuery);

                Return = destinationPath;
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                throw ex;
            }
            finally
            {
                database = null;
            }

            return Return;
        }
        #endregion AddDumpDevice


        #region DropDumpDevice
        private bool DropDumpDevice(string ServerName, string BackupDevice)
        {
            DatabaseClass database = new DatabaseClass();
            string SQLQuery = string.Empty;
            bool Return = false;

            database.ServerName = ServerName;
            database.DatabaseName = "master";

            try
            {
                SQLQuery = "EXEC sp_dropdevice [" + BackupDevice + "]";
                database.RunSQLStatement(SQLQuery);

                Return = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                database = null;
            }

            return Return;
        }
        #endregion DropDumpDevice


        #region BackupDatabase
        public string BackupDatabase(string ServerName, string DatabaseName)
        {
            DatabaseClass database = new DatabaseClass();
            string BackupDevice = string.Empty;
            string SQLQuery = string.Empty;
            string destinationPath = string.Empty;
            string Return = string.Empty;

            database.ServerName = ServerName;
            database.DatabaseName = "master";

            try
            {
                BackupDevice = DatabaseName + "_" + this.BackupType + "_SQLBackup";

                destinationPath = AddDumpDevice(ServerName, DatabaseName, BackupDevice);

                SQLQuery = "BACKUP DATABASE [" + DatabaseName + "] TO [" + BackupDevice + "] ";
                SQLQuery += "WITH DESCRIPTION = '" + this.BackupType + " SQL Backup', STATS, INIT, SKIP ";
                if (this.BackupType.Trim().ToLower().StartsWith("diff"))
                    SQLQuery += ", DIFFERENTIAL ";
                database.RunSQLStatement(SQLQuery, Properties.Settings.Default.SQLTimeOut);

                Return = "Success!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                Return = "ERROR: " + error;
            }
            finally
            {
                DropDumpDevice(ServerName, BackupDevice);

                database = null;
            }

            return Return + "|" + destinationPath;
        }
        #endregion BackupDatabase

        
        #region RestoreDatabase
        public string RestoreDatabase(string ServerName, string DatabaseName, string RestoreFile)
        {
            DatabaseClass database = new DatabaseClass();
            DataSet dataSet = null;
            string SQLQuery = string.Empty;
            string destinationPath = string.Empty;
            string BackupDevice = string.Empty;
            string DatabasePath = string.Empty;
            string DatabaseFiles = string.Empty;
            string[] Files;
            string Return = string.Empty;

            database.ServerName = ServerName;
            database.DatabaseName = "master";

            try
            {
                if(DatabaseName.Trim().Equals(string.Empty))
                {
                    int Index = RestoreFile.IndexOf('_');
                    DatabaseName = RestoreFile.Substring(0, Index);
                }

                BackupDevice = DatabaseName + "_" + this.BackupType + "_SQLBackup";

                destinationPath = AddDumpDevice(ServerName, DatabaseName, BackupDevice);

                // get the list of files in the backup file
                SQLQuery = "RESTORE FILELISTONLY FROM [" + BackupDevice + "]";
                dataSet = database.RunSelectStatement(SQLQuery);
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    DatabaseFiles += dr["LogicalName"].ToString().Trim() + "|";
                }
                Files = DatabaseFiles.Split('|');

                // get database path
                if (DefaultDatabasePath.Equals(string.Empty))
                    DatabasePath = GetSQLDatabasePath(ServerName, DatabaseName);
                else
                    DatabasePath = DefaultDatabasePath;

                // restore the database
                SQLQuery = "RESTORE DATABASE [" + DatabaseName + "] FROM [" + BackupDevice + "] WITH RECOVERY, STATS, REPLACE";
                if(!DatabasePath.Equals(string.Empty))
                    SQLQuery += ", MOVE '" + Files[0] + "' TO '" + DatabasePath + Files[0] + ".MDF', MOVE '" + Files[1] + "' TO '" + DatabasePath + Files[1] + ".LDF'";
                database.RunSQLStatement(SQLQuery, Properties.Settings.Default.SQLTimeOut);

                Return = "Success!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                Return = "ERROR: " + error;
            }
            finally
            {
                DropDumpDevice(ServerName, BackupDevice);

                dataSet = null;
                database = null;
            }

            return Return + "|" + destinationPath;
        }
        #endregion RestoreDatabase


        #region GetSQLDatabasePath
        public string GetSQLDatabasePath(string ServerName, string DatabaseName)
        {
            DatabaseClass database = new DatabaseClass();
            DataSet dataSet = null;
            string SQLQuery = string.Empty;
            string Return = string.Empty;

            database.ServerName = ServerName;
            database.DatabaseName = "master";

            try
            {
                // get database path
                try
                {
                    SQLQuery = "SELECT GroupID, FileName FROM [" + DatabaseName + "]..sysfiles ORDER BY GroupID";
                    dataSet = database.RunSelectStatement(SQLQuery);
                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        if (dr["FileName"].ToString().Trim().ToUpper().EndsWith(".MDF"))
                            Return = dr["FileName"].ToString().Trim();
                    }
                }
                catch
                {
                    // ignore this error
                }

                if (Return.Equals(string.Empty))
                {
                    SQLQuery = "SELECT GroupID, FileName FROM master..sysfiles ORDER BY GroupID";
                    dataSet = database.RunSelectStatement(SQLQuery);
                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        if (dr["FileName"].ToString().Trim().ToUpper().EndsWith(".MDF"))
                            Return = dr["FileName"].ToString().Trim();
                    }
                }

                Return = Return.Substring(0, Return.LastIndexOf(@"\") + 1);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                dataSet = null;
                database = null;
            }

            return Return;
        }
        #endregion GetSQLDatabasePath


        #region FindSQLInstances
        public string[] FindSQLInstances()
        {
            string[] retval = null;
            string txt = string.Empty;
            IntPtr henv = IntPtr.Zero;
            IntPtr hconn = IntPtr.Zero;
            StringBuilder inString = new StringBuilder(SQL_DRIVER_STR);
            StringBuilder outString = new StringBuilder(DEFAULT_RESULT_SIZE);
            short inStringLength = (short)inString.Length;
            short lenNeeded = 0;

            try
            {
                if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, henv, out henv))
                {
                    if (SQL_SUCCESS == SQLSetEnvAttr(henv, SQL_ATTR_ODBC_VERSION, (IntPtr)SQL_OV_ODBC3, 0))
                    {
                        if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, henv, out hconn))
                        {
                            if (SQL_NEED_DATA == SQLBrowseConnect(hconn, inString, inStringLength, outString,
                                DEFAULT_RESULT_SIZE, out lenNeeded))
                            {
                                if (DEFAULT_RESULT_SIZE < lenNeeded)
                                {
                                    outString.Capacity = lenNeeded;
                                    if (SQL_NEED_DATA != SQLBrowseConnect(hconn, inString, inStringLength, outString,
                                        lenNeeded, out lenNeeded))
                                    {
                                        throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
                                    }
                                }
                                txt = outString.ToString();
                                int start = txt.IndexOf("{") + 1;
                                int len = txt.IndexOf("}") - start;
                                if ((start > 0) && (len > 0))
                                {
                                    txt = txt.Substring(start, len);
                                }
                                else
                                {
                                    txt = string.Empty;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;

//                //Throw away any error if we are not in debug mode
//#if (DEBUG)
//                MessageBox.Show(ex.Message, "Acquire SQL Servier List Error");
//#endif
                txt = string.Empty;
            }
            finally
            {
                if (hconn != IntPtr.Zero)
                {
                    SQLFreeHandle(SQL_HANDLE_DBC, hconn);
                }
                if (henv != IntPtr.Zero)
                {
                    SQLFreeHandle(SQL_HANDLE_ENV, hconn);
                }
            }

            if (txt.Length > 0)
            {
                retval = txt.Split(",".ToCharArray());
            }

            return retval;
        }
        #endregion FindSQLInstances


        #region GetSQLDatabases
        public string[] GetSQLDatabases(string ServerName, bool JustUserDatabases)
        {
            DatabaseClass database = new DatabaseClass();
            DataSet dataSet = null;
            string SQLQuery = string.Empty;
            string Databases = string.Empty;
            string[] Return;

            database.ServerName = ServerName;
            database.DatabaseName = "master";

            try
            {
                // get the databases
                SQLQuery = "SELECT Name FROM sysdatabases ";
                if (JustUserDatabases == true)
                    SQLQuery += " WHERE dbid > 4";
                SQLQuery += " ORDER BY Name";
                dataSet = database.RunSelectStatement(SQLQuery);
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Databases += dr["Name"].ToString().Trim() + "|";
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                dataSet = null;
                database = null;
            }

            Return = Databases.Split('|');

            return Return;
        }
        #endregion GetSQLDatabases

    }

}
