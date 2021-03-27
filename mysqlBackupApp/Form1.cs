using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace mysqlBackupApp
{
    public struct Databaseler
    {
        public Databaseler(string dbnamex, string filenamex)
        {
            dbname = dbnamex;
            filename = filenamex;
        }

        public string dbname { get; set; }
        public string filename { get; set; }
    }

    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlBackup mb;
        Timer timer1;
        BackgroundWorker bwExport;

        string _currentTableName = "";
        int _totalRowsInCurrentTable = 0;
        int _totalRowsInAllTables = 0;
        int _currentRowIndexInCurrentTable = 0;
        int _currentRowIndexInAllTable = 0;
        int _totalTables = 0;
        int _currentTableIndex = 0;

        bool cancel = false;

        string dumpPath = "C:\\Users\\USERNAME\\Desktop\\backupdb\\";
        string constringraw = "server=IPVEYADOMAIN;user=DB_USER;pwd=DB_PASS;";
        static string ApplicationName = "Quickstart";

        string dumpFile = "";
        int sira = 0;

        static string[] Scopes = { DriveService.Scope.Drive,
                           DriveService.Scope.DriveAppdata,
                           DriveService.Scope.DriveFile,
                           DriveService.Scope.DriveMetadataReadonly,
                           DriveService.Scope.DriveReadonly,
                           DriveService.Scope.DriveScripts };
        
        List<string> dosyalar = new List<string>();
        int dosyalarsayac = 0;

        public Form1()
        {
            InitializeComponent();
            
            mb = new MySqlBackup();
            mb.ExportProgressChanged += mb_ExportProgressChanged;

            timer1 = new Timer();
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;

            bwExport = new BackgroundWorker();
            bwExport.DoWork += bwExport_DoWork;
            bwExport.RunWorkerCompleted += bwExport_RunWorkerCompleted;

            string[] args = Environment.GetCommandLineArgs();
            if(args.Length > 1)
            if (args[1] == "-silent")
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                clickProcess();
            }
        }

        void bwExport_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                mb.ExportToFile(dumpFile);
            }
            catch (Exception ex)
            {
                cancel = true;
                CloseConnection();
                System.IO.File.AppendAllText(dumpPath + "log.txt", ex.ToString() + " | " + dumpFile + " | " + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + Environment.NewLine);
            }
        }

        void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }

            if (cmd != null)
                cmd.Dispose();
        }

        void mb_ExportProgressChanged(object sender, ExportProgressArgs e)
        {
            if (cancel)
            {
                // Calling mb to halt
                mb.StopAllProcess();
                return;
            }

            _currentRowIndexInAllTable = (int)e.CurrentRowIndexInAllTables;
            _currentRowIndexInCurrentTable = (int)e.CurrentRowIndexInCurrentTable;
            _currentTableIndex = e.CurrentTableIndex;
            _currentTableName = e.CurrentTableName;
            _totalRowsInAllTables = (int)e.TotalRowsInAllTables;
            _totalRowsInCurrentTable = (int)e.TotalRowsInCurrentTable;
            _totalTables = e.TotalTables;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (cancel)
            {
                timer1.Stop();
                return;
            }

            pbTable.Maximum = _totalTables;
            if (_currentTableIndex <= pbTable.Maximum)
                pbTable.Value = _currentTableIndex;

            pbRowInCurTable.Maximum = _totalRowsInCurrentTable;
            if (_currentRowIndexInCurrentTable <= pbRowInCurTable.Maximum)
                pbRowInCurTable.Value = _currentRowIndexInCurrentTable;

            pbRowInAllTable.Maximum = _totalRowsInAllTables;
            if (_currentRowIndexInAllTable <= pbRowInAllTable.Maximum)
                pbRowInAllTable.Value = _currentRowIndexInAllTable;

            lbCurrentTableName.Text = "Current Processing Table = " + _currentTableName;
            lbRowInCurTable.Text = pbRowInCurTable.Value + " of " + pbRowInCurTable.Maximum;
            lbRowInAllTable.Text = pbRowInAllTable.Value + " of " + pbRowInAllTable.Maximum;
            lbTableCount.Text = _currentTableIndex + " of " + _totalTables;
        }

        void bwExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseConnection();

            if (cancel)
            {
                System.IO.File.AppendAllText(dumpPath + "log.txt", "Cancel by user. | " + dumpFile + " | " + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + Environment.NewLine);
            }
            else
            {
                if (mb.LastError == null)
                {
                    pbRowInAllTable.Value = pbRowInAllTable.Maximum;
                    pbRowInCurTable.Value = pbRowInCurTable.Maximum;
                    pbTable.Value = pbTable.Maximum;
                    this.Refresh();
                    using (var zip = ZipFile.Open(dumpFile.Substring(0, dumpFile.Length - 3) + "zip", ZipArchiveMode.Create))
                        zip.CreateEntryFromFile(dumpFile, Path.GetFileName(dumpFile));

                    System.IO.File.Delete(dumpFile);
                    System.IO.File.AppendAllText(dumpPath+"log.txt", "Completed | "+ dumpFile + " | " + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + Environment.NewLine);                  
                }
                else
                    System.IO.File.AppendAllText(dumpPath + "log.txt", "Completed with error(s)." + Environment.NewLine + Environment.NewLine + mb.LastError.ToString() + " | " + dumpFile + " | " + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + Environment.NewLine);
            }           
            timer1.Stop();
            clickProcess();
        }
        public void clickProcess()
        {
            List<Databaseler> veri = new List<Databaseler>();
            foreach (var x in txtDbNames.Text.Split(','))
            {
                veri.Add(new Databaseler
                {
                    dbname = x,
                    filename = dumpPath + x + "-" + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + ".sql"
                });
            }
            

            int iterationsize = veri.Count;
            if(sira < iterationsize)
            { 
            dumpFile = veri[sira].filename;
            string constring = constringraw + "database=" + veri[sira].dbname + ";";

            // Important Additional Connection Options
            constring += "charset=utf8;convertzerodatetime=true;";

            // Reset variables to initial state
            cancel = false;
            _currentTableName = "";
            _totalRowsInCurrentTable = 0;
            _totalRowsInAllTables = 0;
            _currentRowIndexInCurrentTable = 0;
            _currentRowIndexInAllTable = 0;
            _totalTables = 0;
            _currentTableIndex = 0;

            // Initialize MySqlConnection and MySqlCommand components
            conn = new MySqlConnection(constring);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();

            // Start the Timer here
            timer1.Start();

                //var dictionaryTables = new Dictionary<string, string>();
                //dictionaryTables.Add("vipLogin", "SELECT * FROM vipLogin ORDER BY id DESC LIMIT 1000");
                //mb.ExportInfo.TablesToBeExportedDic = dictionaryTables;

                var excludetables = new List<string>();
                foreach (var x in txtExcludes.Text.Split(','))
                {
                    excludetables.Add(x);
                }
                
                mb.ExportInfo.ExcludeTables = excludetables;

                //mb.ExportInfo.IntervalForProgressReport = 50;

                // This option is required for progress report.
                //mb.ExportInfo.GetTotalRowsBeforeExport = true;
                // However, it might takes some times to retrieve the total rows if
                // your database contains thousands millions of rows.

                mb.Command = cmd;
            sira++;
            bwExport.RunWorkerAsync();
            }
            else
            {
                googleDriveupload();
            }

        }
        private void backupDB_Click(object sender, EventArgs e)
        {
            constringraw = txtConstr.Text;
            dumpPath = txtBackupPath.Text;
            clickProcess();          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            cancel = true;
        }

        public void getFileList()
        {
            DirectoryInfo d = new DirectoryInfo(dumpPath);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.zip"); //Getting Text files
            
            foreach (FileInfo file in Files)
            {
                if(file.CreationTime > DateTime.Now.AddHours(-2))
                {
                    dosyalar.Add(file.FullName);
                }
                
            }
        }
        public void googleDriveupload()
        {
            getFileList();
            foreach (string dosya in dosyalar)
            {          
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    System.Threading.CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(dosya),
                Parents = new List<string> { "1OOOlXhLuthbR4LzCTfDpGyOIoygcQwrN" }
                //1eo_DM2_qwJ3avhRrEliL07kofy4t6REp  unlimited
                //1OOOlXhLuthbR4LzCTfDpGyOIoygcQwrN normal benim tempdosyalar folder adı
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(dosya,
                                    System.IO.FileMode.Open))
            {
                request = service.Files.Create(
                    fileMetadata, stream, "application/zip");
                request.Fields = "id";
                request.Upload();
            }
            var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);
            }
            dosyalar.Clear();
            Environment.Exit(0);
        }

        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
