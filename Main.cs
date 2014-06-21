/**
 *      
 *      DinoDoc
 *      =======
 *
 *      The little friendly batch-upload tool designed for SharePoint Server and Windows SharePoint Services, enabling you to easily 
 *      upload multiple files and folders with a single click!
 *      For more information about DinoDoc and about SharePoint development: http://spdino.wordpress.com
 *
 *
 *      DinoDoc Features
 *      ================
 *
 *      You simply need to point to the source where your files are located (Source Path) and type the name of your SharePoint Server followed by the
 *      site collection name and/or site destination and hit the button "Upload", them sit back and relax while DinoDoc takes care of the rest for you!
 *      
 *      It will rename files and folders incompatible with SharePoint naming standards, so you don't need to worry about incompatibility issues, 
 *      and it will also recreate the same file system structure from your local source on the destination server.
 *      
 *      All operations are logged in your screen and you can revisit everything, if DinoDoc renamed a file or folder you can review and find the 
 *      new name of the file/folder on your SharePoint server.
 * 
 *      
 * 
 *      
 * 
 * 
 *      Author............: Alex Gonsales - aagons@yahoo.com
 *      
 *                          http://spdino.wordpress.com                          
 *                          http://dinodoc.codeplex.com
 *                          
 *                          
 *      Current Version...: 1.0 ALPHA
 * 
 *                          
 *      Comments..........: DinoDoc can be used without any restriction or infrigment to any copyright law, alterations and modifications to this 
 *                          code should always include the original author of DinoDoc (Alex Gonsales) and also include a special note about the 
 *                          author of "SharePoint Bulk Document Up Loader" (Bowsil Ameen), the existent software was based on the work of Ameen
 *                          and this author strongly encourages you to visit his project since my work would not be possible without his contribution
 *                          to the developer's community.
 *                          
 *                          My special note for the developers out there, please share this code and keep the names of everybody involved in this project,
 *                          and if you decide to remove the names of the authors in the end you will not bring any help to community, it is just stealing :)
 *                          
 *                          PLEASE SHARE THE CODE!!!
 *
 * 
 *      Special Notes.....: This tool was based on the existing work from Bowsil Ameen (bowsilameen@hotmail.com) http://spdocuploader.codeplex.com/
 *      
 */

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using DinoDoc.Properties;

namespace DinoDoc
{
    struct LastActionProcessed
    {
        public string[] ListRow;
        public string ListMsg;
        public string ListDir;

        public string ComputedFileFolder;

        public int ComputedFiles;
        public int ComputedFolders;

        public int TotalFolders;
        public int TotalFiles;
        public int TotalFilesRenamed;
        public int TotalFilesSkipped;
        public int TotalFilesOverwritten;
        public int TotalFailures;

        public string Status;
        public string LogStatus;
        public Font   LogSelectionFont;
        public Color  LogSelectionColor;

        public bool OperationAborted;
    }

    public partial class frmMain : Form
    {
        LastActionProcessed Last;

        /// <summary>
        /// Enables a control to be double buffered to prevent flickering
        /// </summary>
        /// <param name="c">Control Name</param>
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx

            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        // ====================================================================================================== Form Events

        /// <summary>
        /// Main routine of the program
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            SetDoubleBuffered(lvStatus);
            SetDoubleBuffered(LogStatus);
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Settings.Default.WindowMaximized)
            {
                WindowState = FormWindowState.Maximized;
                Location = Settings.Default.WindowLocation;
                Size = Settings.Default.WindowSize;
            }
            else if (Settings.Default.WindowMinimized)
            {
                WindowState = FormWindowState.Minimized;
                Location = Settings.Default.WindowLocation;
                Size = Settings.Default.WindowSize;
            }
            else
            {
                Location = Settings.Default.WindowLocation;
                Size = Settings.Default.WindowSize;
            }

            tvcSource.Width = Settings.Default.TreeViewSource;
            tvcFile.Width = Settings.Default.TreeViewFile;
            tvcTarget.Width = Settings.Default.TreeViewTarget;
            tvcStatus.Width = Settings.Default.TreeViewStatus;
        }

        /// <summary>
        /// Performs the closing and will store the window location and dimensions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Settings.Default.WindowLocation = RestoreBounds.Location;
                Settings.Default.WindowSize = RestoreBounds.Size;
                Settings.Default.WindowMaximized = true;
                Settings.Default.WindowMinimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowLocation = Location;
                Settings.Default.WindowSize = Size;
                Settings.Default.WindowMaximized = false;
                Settings.Default.WindowMinimized = false;
            }
            else
            {
                Settings.Default.WindowLocation = RestoreBounds.Location;
                Settings.Default.WindowSize = RestoreBounds.Size;
                Settings.Default.WindowMaximized = false;
                Settings.Default.WindowMinimized = true;
            }                      

            Settings.Default.TreeViewSource = tvcSource.Width;
            Settings.Default.TreeViewFile = tvcFile.Width;
            Settings.Default.TreeViewTarget = tvcTarget.Width;
            Settings.Default.TreeViewStatus = tvcStatus.Width;

            Settings.Default.Save();
        }

        // ====================================================================================================== General Functions

        /// <summary>
        /// Classify and count the items to be uploaded, this sorts out the total of files and folders
        /// </summary>
        /// <param name="SourceDir">Source Folder to be uploaded to SharePoint</param>
        /// <param name="recursionLvl">The level of recursion (deep dive)</param>
        public void ComputeItems(string SourceDir, int recursionLvl)
        {
            const int HowDeepToScan = 999999999;

            if (recursionLvl <= HowDeepToScan)
            {
                string[] fileEntries = Directory.GetFiles(SourceDir);

                Last.ComputedFiles += fileEntries.Count();

                StatusLabel.Text = "Discovering items... " + Last.ComputedFiles.ToString() + "... found";

                string[] subdirEntries = Directory.GetDirectories(SourceDir);

                foreach (string subdir in subdirEntries)
                {
                    if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                    {
                        // Last.ComputedFolders += subdirEntries.Count();

                        Last.ComputedFolders++;

                        StatusLabel.Text = "Computing " + Last.ComputedFolders.ToString() + " folders...";

                        ComputeItems(subdir, recursionLvl + 1);
                    }
                }
            }

        }

        /// <summary>
        /// Returns the File Size from a local file 
        /// </summary>
        /// <param name="FileNameAndLocation">The file name and local location</param>
        /// <returns>returns File Size</returns>        
        public long GetLocalFileSize(string FileNameAndLocation)
        {
            try
            {
                if (File.Exists(FileNameAndLocation))
                {
                    FileInfo fInfo = new FileInfo(FileNameAndLocation);

                    return fInfo.Length;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the file's date from a local file
        /// </summary>
        /// <param name="FileNameAndLocation">The file name and local location</param>
        /// <returns>returns the file date and time</returns>
        public DateTime GetLocalFileDate(string FileNameAndLocation)
        {
            // i need to include some special file i/o checking

            if (File.Exists(FileNameAndLocation))
            {
                return File.GetCreationTime(FileNameAndLocation);
            }
            else
            {
                return new DateTime(1900, 1, 1);
            }
        }

        /// <summary>
        /// Desconstructs the original file name replacing the illegal characters and reconstructs a new file name using "_" 
        /// </summary>
        /// <param name="FileName">Original File Name</param>
        /// <returns>Returns the new File Name compatible with SharePoint standards</returns>
        private static string FixName(string FileName)
        {
            //
            // list of invalid characters:     ~ " # % & * : < > ? / \ { | }
            //            

            RegexOptions none = RegexOptions.None;
            Regex regex = new Regex("[\"#%&*:.<>?\\\\{|}~\\r\\n]", none);

            string replacement = "_";
            string FileExtension = System.IO.Path.GetExtension(FileName);
            string txtExp = regex.Replace(System.IO.Path.GetFileNameWithoutExtension(FileName), replacement);

            int length = 0;

            if (txtExp.Length > 0x7f)
            {
                length = 0x7f;
            }
            else
            {
                length = txtExp.Length;
            }

            return txtExp.Substring(0, length) + FileExtension;
        }

        /// <summary>
        /// Checks if a files exists on the remote server
        /// </summary>
        /// <param name="FileNameAndLocation">The current Web Request in use pointing to the remote file on the server</param>
        /// <returns>Returns True if the file is found, False otherwise</returns>
        public bool CheckRemoteFileExists(string FileNameAndLocation)
        {
            try
            {
                WebRequest request = WebRequest.Create(FileNameAndLocation);

                request.Method = "HEAD";
                request.Timeout = Decimal.ToInt32(Settings.Default.OptionsTimeOut * 10000);

                if (Settings.Default.OptionsUseClaimsAuthentication)
                {
                    request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                }

                if (rdCredentialsDefault.Checked == true)
                {
                    request.Credentials = CredentialCache.DefaultCredentials;
                }
                else if ((txtUserName.Text.Length > 0) && (txtUserPassword.Text.Length > 0))
                {
                    request.Credentials = new System.Net.NetworkCredential(txtUserName.Text.Trim(), txtUserPassword.Text.Trim(), txtUserDomain.Text.Trim());
                }

                request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

                var response = request.GetResponse() as HttpWebResponse;

                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch (WebException)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the File Size from a file located on a remote server
        /// </summary>
        /// <param name="FileNameAndLocation">The file name and remote location</param>
        /// <returns>returns the File Size</returns>
        public long GetRemoteFileSize(string FileNameAndLocation)
        {            
            WebRequest request = WebRequest.Create(FileNameAndLocation);

            request.Method = "HEAD";
            request.Timeout = Decimal.ToInt32(Settings.Default.OptionsTimeOut * 10000);

            if (Settings.Default.OptionsUseClaimsAuthentication)
            {
                request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            }

            if (rdCredentialsDefault.Checked == true)
            {
                request.Credentials = CredentialCache.DefaultCredentials;
            }
            else if ((txtUserName.Text.Length > 0) && (txtUserPassword.Text.Length > 0))
            {
                request.Credentials = new System.Net.NetworkCredential(txtUserName.Text.Trim(), txtUserPassword.Text.Trim(), txtUserDomain.Text.Trim());
            }

            try
            {
                WebResponse response = request.GetResponse();    // as HttpWebResponse;
                WebHeaderCollection headers = response.Headers;

                if (response != null)
                {
                    response.Close();
                    return Convert.ToInt32(headers["Content-Length"]);
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the date from a file located on remote server
        /// </summary>
        /// <param name="FileNameAndLocation">The file name and remote location</param>
        /// <returns></returns>
        public DateTime GetRemoteFileDate(string FileNameAndLocation)
        {
            WebRequest request = WebRequest.Create(FileNameAndLocation);

            request.Method = "HEAD";
            request.Timeout = Decimal.ToInt32(Settings.Default.OptionsTimeOut * 10000);

            if (Settings.Default.OptionsUseClaimsAuthentication)
            {
                request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            }

            if (rdCredentialsDefault.Checked == true)
            {
                request.Credentials = CredentialCache.DefaultCredentials;
            }
            else if ((txtUserName.Text.Length > 0) && (txtUserPassword.Text.Length > 0))
            {
                request.Credentials = new System.Net.NetworkCredential(txtUserName.Text.Trim(), txtUserPassword.Text.Trim(), txtUserDomain.Text.Trim());
            };


            try
            {
                WebResponse response = request.GetResponse();    // as HttpWebResponse;
                WebHeaderCollection headers = response.Headers;

                if (response != null)
                {
                    response.Close();
                    return Convert.ToDateTime(headers["Last-Modified"]);
                }
                else
                {
                    return new DateTime(1900, 1, 1);
                }
            }
            catch
            {
                return new DateTime(1900, 1, 1);
            }
        }

        /// <summary>
        /// CreateWebDAVFolder - this function will create a new folder in a site collection
        /// </summary>
        /// <param name="FileNameAndLocation"></param>
        /// <returns></returns>
        public HttpStatusCode CreateWebDAVFolder(string FileNameAndLocation)
        {
            FileNameAndLocation = FileNameAndLocation.Replace("\\", "/");

            Uri myURI = new Uri(FileNameAndLocation);

            WebRequest request = WebRequest.Create(myURI);

            //
            //  Timeout
            //

            request.Timeout = Decimal.ToInt32(Settings.Default.OptionsTimeOut * 10000);

            //
            //  Determine the authentication mode
            //

            if (rdCredentialsDefault.Checked == true)
            {
                request.Credentials = CredentialCache.DefaultCredentials;
            }
            else if ((txtUserName.Text.Length > 0) && (txtUserPassword.Text.Length > 0))
            {
                request.Credentials = new System.Net.NetworkCredential(txtUserName.Text.Trim(), txtUserPassword.Text.Trim(), txtUserDomain.Text.Trim());
            }

            //
            //   Use Claims Authentication
            //

            if (Settings.Default.OptionsUseClaimsAuthentication)
            {
                request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            }

            request.Method = "MKCOL";            

            HttpStatusCode statusCode;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    statusCode = httpResponse.StatusCode;
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    if (response != null)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;

                        //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);+

                        using (Stream data = response.GetResponseStream())
                        {
                            string text = new StreamReader(data).ReadToEnd();
                            //Console.WriteLine(text);
                        }

                        statusCode = httpResponse.StatusCode;
                    }
                    else
                    {
                        statusCode = HttpStatusCode.ServiceUnavailable;
                    }
                }
            }

            return statusCode;
        }

        /// <summary>
        /// Upload a file to the remote location
        /// </summary>
        /// <param name="localFile">source file</param>
        /// <param name="remoteFile">remote destination</param>
        public void UploadDocument(string localFile, string remoteFile)
        {
            try
            {
                //
                //  Start the Request for the Upload  
                //

                WebRequest request;

                request = WebRequest.Create(remoteFile);

                //
                //  Defines POST or PUT, determined by program options
                //

                request.Method = Settings.Default.OptionsAuthenticationMethod;

                //
                //  Connection Time-out, right now is internal and I plan to make it available in the Options dialog later
                //

                request.Timeout = Decimal.ToInt32(Settings.Default.OptionsTimeOut * 10000);

                //
                //  Determine the Credentials used for authentication
                //

                if (rdCredentialsDefault.Checked == true)
                {
                    request.Credentials = CredentialCache.DefaultCredentials;
                }
                else if ((txtUserName.Text.Length > 0) && (txtUserPassword.Text.Length > 0))
                {
                    request.Credentials = new System.Net.NetworkCredential(txtUserName.Text.Trim(), txtUserPassword.Text.Trim(), txtUserDomain.Text.Trim());
                }

                //
                //   Use Claims Authentication
                //

                if (Settings.Default.OptionsUseClaimsAuthentication)
                {
                    // request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "t");
                    request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f"); 
                }                

                //
                //  Prcoess the upload
                //
                
                string[] liRow = { System.IO.Path.GetFileName(localFile), remoteFile, Last.Status };

                lvStatus.Invoke((MethodInvoker)delegate()
                    {
                        lvStatus.Items.Add(localFile).SubItems.AddRange(liRow);
                    }
                );
                
                byte[] fileBuffer = new byte[1024];                                                                       // Create buffer to transfer file

                using (Stream stream = request.GetRequestStream())                                                        // Gets the request stream
                {
                    using (FileStream fsUploadStream = File.Open(localFile, FileMode.Open, FileAccess.Read))              // Load the content from local file to stream
                    {
                        int startBuffer = fsUploadStream.Read(fileBuffer, 0, fileBuffer.Length);                          // Get the start point

                        for (int i = startBuffer; i > 0; i = fsUploadStream.Read(fileBuffer, 0, fileBuffer.Length))       // Loops through the stream
                        {
                            stream.Write(fileBuffer, 0, i);                                                               // Performs the writing
                        }
                    }
                }

                //
                //  Gets the response
                //

                WebResponse response = request.GetResponse();

                //
                //  Close the connection
                //

                response.Close();

                //
                //  Log the operation
                //

                Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                Last.LogSelectionColor = Color.DarkBlue;
                Last.LogStatus = "OK      = " + localFile + "\n";
            }
            catch (Exception ex)
            {
                lvStatus.Invoke((MethodInvoker)delegate()
                    {
                        lvStatus.Items[lvStatus.Items.Count - 1].SubItems[2].Text = ex.Message;
                        lvStatus.Items[lvStatus.Items.Count - 1].SubItems[3].Text = "failure";
                    }
                );

                Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                Last.LogSelectionColor = Color.Red;
                Last.LogStatus = "\nfailure = " + localFile + " --- " + ex.Message + "\n\n";

                Last.TotalFailures++;
            }

            backgroundWorker.ReportProgress(Last.TotalFiles + Last.TotalFolders);
        }
        
        /// <summary>
        /// Used to start the Upload process, which will compute, create folders (CreateWebDavFolder) and upload files (UploadDocument)
        /// </summary>
        /// <param name="SourceDir">Source location</param>
        /// <param name="TargetDir">Target location</param>
        /// <param name="recursionLvl">Recursivity level (default = 0)</param>
        public void Uploader(string SourceDir, string TargetDir, int recursionLvl)
        {
            const int HowDeepToScan = 999999999;            

            if (recursionLvl <= HowDeepToScan)
            {
                //
                // Process the list of files found in the directory. 
                //

                string[] fileEntries = Directory.GetFiles(SourceDir);

                foreach (string fileName in fileEntries)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        Last.OperationAborted = true;
                        break;
                    }

                    Last.TotalFiles++;
                    Last.ComputedFileFolder = "file: " + fileName;
                    
                    //
                    //   This will determine how to handle according to Program Options
                    //
                    //      - Overwrite Options
                    //      - Handling of Renamed File using the FixName() function               
                    //

                    string OriginalFileName = System.IO.Path.GetFileName(fileName);
                    string FixedFileName = FixName(OriginalFileName);

                    string RemotePath = System.IO.Path.GetDirectoryName(fileName);

                    RemotePath = RemotePath.Replace(@"\", @"/");
                    RemotePath = RemotePath.Replace(@":/", @"://");

                    string remoteFile = TargetDir + @"/" + System.IO.Path.GetFileName(FixedFileName);

                    //  - test for program options

                    /*
                    if (Settings.Default.OptionsOverwriteFiles)
                    {
                        if (Settings.Default.OptionsOverwriteLogicalOperator == "AND")
                        {
                            long RemoteFileSize = GetRemoteFileSize("file");
                            long LocalFileSize = GetLocalFileSize("file");
                            
                            DateTime RemoteFileDate = GetRemoteFileDate("file");
                            DateTime LocalFileDate =  GetLocalFileDate("file");

                            if (RemoteFileSize != LocalFileSize  &&  RemoteFileDate != LocalFileDate)
                            {

                            }
                        }
                        else
                        {

                        }
                    }
                    */

                    //  - regular functional portion

                    if (Settings.Default.OptionsOverwriteFiles)
                    {
                        if (CheckRemoteFileExists(remoteFile))
                        {
                            Last.TotalFilesOverwritten++;
                            Last.Status = "Overwritten";
                        }
                        else
                        {
                            Last.Status = OriginalFileName != FixedFileName ? "New and Renamed" : "New";
                        }

                        Last.TotalFilesRenamed = OriginalFileName == FixedFileName ? Last.TotalFilesRenamed : Last.TotalFilesRenamed + 1;

                        //
                        //  Determines the Simulation mode
                        //

                        if (Settings.Default.OptionsSimulationMode)
                        {
                            string[] liRow = { System.IO.Path.GetFileName(fileName), remoteFile, Last.Status };

                            lvStatus.Invoke((MethodInvoker)delegate()
                                {
                                    lvStatus.Items.Add(fileName).SubItems.AddRange(liRow);
                                }
                            );

                            Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            Last.LogSelectionColor = Color.DarkBlue;
                            Last.LogStatus = "OK      = " + fileName + "\n";

                            backgroundWorker.ReportProgress(Last.TotalFiles + Last.TotalFolders);
                        }
                        else
                        {
                            UploadDocument(fileName, remoteFile);
                        }
                    }
                    else
                    {
                        if (CheckRemoteFileExists(remoteFile))
                        {
                            Last.Status = "Skipped";
                            Last.TotalFilesSkipped++;

                            string[] liRow = { System.IO.Path.GetFileName(fileName), remoteFile, Last.Status };

                            lvStatus.Invoke((MethodInvoker)delegate()
                                {
                                    lvStatus.Items.Add(fileName).SubItems.AddRange(liRow);
                                }
                            );

                            Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            Last.LogSelectionColor = Color.DarkBlue;
                            Last.LogStatus = "skipped = " + fileName + "\n";

                            backgroundWorker.ReportProgress(Last.TotalFiles + Last.TotalFolders);
                        }
                        else
                        {                            
                            Last.Status = OriginalFileName != FixedFileName ? "New and Renamed" : "New";
                            Last.TotalFilesRenamed = OriginalFileName == FixedFileName ? Last.TotalFilesRenamed : Last.TotalFilesRenamed + 1;

                            //
                            //  Determines the Simulation mode
                            //

                            if (Settings.Default.OptionsSimulationMode)
                            {
                                string[] liRow = { System.IO.Path.GetFileName(fileName), remoteFile, Last.Status };

                                lvStatus.Invoke((MethodInvoker)delegate()
                                    {
                                        lvStatus.Items.Add(fileName).SubItems.AddRange(liRow);
                                    }
                                );

                                Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                                Last.LogSelectionColor = Color.DarkBlue;
                                Last.LogStatus = "OK      = " + fileName + "\n";

                                backgroundWorker.ReportProgress(Last.TotalFiles + Last.TotalFolders);
                            }
                            else
                            {
                                UploadDocument(fileName, remoteFile);
                            }
                        }                        
                    }
                }

                //
                // Recurse into subdirectories of this directory.
                //

                string[] subdirEntries = Directory.GetDirectories(SourceDir);

                foreach (string subdir in subdirEntries)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        Last.OperationAborted = true;
                        break;
                    }

                    if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                    {
                        Last.TotalFolders++;
                       
                        HttpStatusCode resultCode;

                        string FixedName = FixName(System.IO.Path.GetFileName(subdir));
                        string DirName = FixName(System.IO.Path.GetFileName(subdir));

                        Last.ComputedFileFolder = "folder: " + DirName;                        

                        resultCode = CreateWebDAVFolder(TargetDir + @"/" + DirName);

                        if (resultCode == HttpStatusCode.MethodNotAllowed)
                        {
                            string[] liRow = { "", System.IO.Path.GetFileName(DirName), "Folder Already Exists" };

                            Last.ListMsg = "";
                            Last.ListDir = DirName;
                            Last.ListRow = liRow;

                            Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            Last.LogSelectionColor = Color.Blue;
                            Last.LogStatus = "\n" + new string('-', 28 + DirName.Length) + "\n" +
                                             "---- FOLDER ALREADY EXISTS: " + DirName + "\n" +
                                             new string('-', 28 + DirName.Length) + "\n\n";
                        }
                        else
                        {
                            if (DirName != FixedName)
                            {
                                string[] liRow = { "", TargetDir + @"/" + System.IO.Path.GetFileName(DirName), "New Folder and Renamed" };

                                Last.ListMsg = "";
                                Last.ListDir = subdir;
                                Last.ListRow = liRow;
                            }
                            else
                            {
                                string[] liRow = { "", TargetDir + @"/" + System.IO.Path.GetFileName(DirName), "New Folder" };

                                Last.ListMsg = "";
                                Last.ListDir = subdir;
                                Last.ListRow = liRow;
                            }

                            Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            Last.LogSelectionColor = Color.Blue;
                            Last.LogStatus = "\n" + new string('-', 18 + DirName.Length) + "\n" +
                                             "---- NEW FOLDER: " + DirName + "\n" +
                                             new string('-', 18 + DirName.Length) + "\n\n";
                        }

                        backgroundWorker.ReportProgress(Last.TotalFiles + Last.TotalFolders); 

                        Uploader(subdir, TargetDir + @"/" + DirName, recursionLvl + 1);
                    }
                }                
            }

            if (backgroundWorker.CancellationPending)
            {
                Last.OperationAborted = true;
                return;
            }
        }

        // ====================================================================================================== UI Controls

        private void btSourceFolder_Click(object sender, EventArgs e)
        {
            if (txtSourcePath.Text.Length > 0)
            {
                flSourceDig.SelectedPath = txtSourcePath.Text;
            }

            flSourceDig.ShowDialog();
            txtSourcePath.Text = flSourceDig.SelectedPath;
        }

        private void rdCredentialsSupply_CheckedChanged(object sender, EventArgs e)
        {
            txtUserPassword.Enabled = true;
            txtUserName.Enabled = true;
            txtUserDomain.Enabled = true;
        }

        private void rdCredentialsDefault_CheckedChanged(object sender, EventArgs e)
        {
            txtUserPassword.Enabled = false;
            txtUserName.Enabled = false;
            txtUserDomain.Enabled = false;
        }
        
        // ====================================================================================================== Menus

        private void MenuFile_ClearLogs_Clicks(object sender, EventArgs e)
        {
            StatusLabel.Text = "";

            StripProgressBar.Visible = false;
            StripProgressBar.Maximum = 0;
            StripProgressBar.Value = 0;

            lvStatus.Items.Clear();
            LogStatus.Clear();
        }

        private void MenuFile_SaveLog_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "DinoDoc Import " + String.Format("{0:MM-dd-yyyy}", System.DateTime.Now);

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LogStatus.SaveFile(saveFileDialog.FileName);

                StringBuilder sbItems = new StringBuilder();

                foreach (ColumnHeader lvColumns in lvStatus.Columns)
                {
                    sbItems.Append(lvColumns.Text + ",");
                }

                sbItems.AppendLine();

                foreach (ListViewItem lvItems in lvStatus.Items)
                {
                    foreach (ListViewItem.ListViewSubItem lvStrings in lvItems.SubItems)
                    {
                        if (lvStrings.Text.Trim() == string.Empty)
                            sbItems.Append(" ,");
                        else
                            sbItems.Append(lvStrings.Text + ",");
                    }
                    sbItems.AppendLine();
                }

                StreamWriter sw = new StreamWriter(System.IO.Path.GetDirectoryName(saveFileDialog.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(saveFileDialog.FileName) + ".csv");
                sw.Write(sbItems.ToString());
                sw.Close();
            }
        }

        private void MenuFile_Print_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon!");
        }

        private void MenuFile_PrintPreview_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon!");
        }

        private void MenuFile_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuTools_Options_Click(object sender, EventArgs e)
        {
            frmOptions Form_Options = new frmOptions();
            Form_Options.ShowDialog();
        }

        private void MenuHelp_About_Click(object sender, EventArgs e)
        {
            frmAbout Form_About = new frmAbout();
            Form_About.ShowDialog();
        }

        // ====================================================================================================== Button Upload
               
        private void btUpload_Click(object sender, EventArgs e)
        {            
            if (btUpload.Text == "Cancel")
            {
                backgroundWorker.CancelAsync();
                return;
            }

            if (txtDestinationURL.Text.Length > 0 && txtSourcePath.Text.Length > 0)
            {
                // 
                //  TO-DO:  
                //
                //  1) regex to validate the URL:  '/^(https?|http):\/\/.+$/igm'  = catches the url at any format for http/https
                //

                if (!Uri.IsWellFormedUriString(txtDestinationURL.Text.Trim(), UriKind.RelativeOrAbsolute))
                {

                }
                
                // disable controls to prevent unwanted interactions that may affect the current task                

                txtSourcePath.Enabled = false;
                txtDestinationURL.Enabled = false;
                btSourceFolder.Enabled = false;
                grpboxAuthentication.Enabled = false;
                ContextMenuLog.Enabled = false;

                MenuTools_Options.Enabled = false;
                MenuFile_ClearLogs.Enabled = false;
                MenuFile_SaveLog.Enabled = false;
                MenuFile_Print.Enabled = false;
                MenuFile_PrintPreview.Enabled = false;
                MenuFile_Exit.Enabled = false;
                MenuHelp_About.Enabled = false;
                
                // reset the struct 

                Last.OperationAborted = false;
                Last.LogStatus = "";
                Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                Last.LogSelectionColor = Color.Blue;

                Last.ComputedFiles = 0;
                Last.ComputedFolders = 0;
                Last.ComputedFileFolder = "";

                Last.TotalFolders = 0;
                Last.TotalFiles = 0;
                Last.TotalFilesRenamed = 0;
                Last.TotalFilesSkipped = 0;
                Last.TotalFilesOverwritten = 0;
                Last.TotalFailures = 0;

                Last.ListDir = "";
                Last.ListRow = null; 

                // modify the button enabling it to CANCEL the operation

                btUpload.Text = "Cancel";
                btUpload.Image = ((System.Drawing.Image)(Properties.Resources.Upload_Cancel_48x48));
                
                //
                //  Returns Feedback for UI:
                //
                //  - Compute the files
                //  - Feeds the Progress Bar with numbers
                //  - Fires the log
                //

                ComputeItems(txtSourcePath.Text.Trim(), 0);

                StripProgressBar.Visible = true;
                StripProgressBar.Maximum = Last.ComputedFiles + Last.ComputedFolders;

                LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                LogStatus.SelectionColor = Color.DarkBlue;

                if (Settings.Default.OptionsSimulationMode)
                {
                    LogStatus.AppendText("\n\nSimulation Import Process started at " + System.DateTime.Now.ToString() + "\n\n");
                }
                else
                {
                    LogStatus.AppendText("\n\nImport Process started at " + System.DateTime.Now.ToString() + "\n\n");
                }

                //
                //  start uploading files
                //

                backgroundWorker.RunWorkerAsync();
            }
        }

        // ====================================================================================================== Background Worker

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            Uploader(txtSourcePath.Text.Trim(), txtDestinationURL.Text.Trim(), 0);            
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LogStatus.SelectionFont = Last.LogSelectionFont;
            LogStatus.SelectionColor = Last.LogSelectionColor;

            LogStatus.AppendText(Last.LogStatus);

            LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
            LogStatus.SelectionColor = Color.Blue;

            StatusLabel.Text = "Item: " + e.ProgressPercentage.ToString() + " of " + (Last.ComputedFiles + Last.ComputedFolders).ToString() + "  -  Processing " + Last.ComputedFileFolder;
            
            StripProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // enable controls back to normal

            txtSourcePath.Enabled = true;
            txtDestinationURL.Enabled = true;
            btSourceFolder.Enabled = true;
            grpboxAuthentication.Enabled = true;
            ContextMenuLog.Enabled = true;

            MenuTools_Options.Enabled = true;
            MenuFile_ClearLogs.Enabled = true;
            MenuFile_SaveLog.Enabled = true;
            MenuFile_Print.Enabled = true;
            MenuFile_PrintPreview.Enabled = true;
            MenuFile_Exit.Enabled = true;
            MenuHelp_About.Enabled = true;

            // wrap up everything!

            LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
            LogStatus.SelectionColor = Color.DarkBlue;

            LogStatus.AppendText(
                    // "\n\nImport Process Completed at " + String.Format("{0:MM-dd-yyyy - hh:mm:ss}", System.DateTime.Now) + "\n\n" +

                    "\n\n" + (Settings.Default.OptionsSimulationMode ? "SIMULATION" : "Import") + " process Completed at " + System.DateTime.Now.ToString() + "\n\n" +

                    "Folders Processed...: " + Last.TotalFolders.ToString() + "\n" +
                    "Files Processed.....: " + Last.TotalFiles.ToString() + "\n" +
                    "Files Renamed.......: " + Last.TotalFilesRenamed.ToString() + "\n" +
                    "Files Skipped.......: " + Last.TotalFilesSkipped.ToString() + "\n" +
                    "Files Overwritten...: " + Last.TotalFilesOverwritten + "\n" +
                    "Failures............: " + Last.TotalFailures.ToString() + "\n"
            );

            LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
            LogStatus.SelectionColor = Color.Blue; ;

            TextWriter tw = new StreamWriter("Last Operation.rtf");

            tw.WriteLine(LogStatus.Text);
            tw.Close();

            StripProgressBar.Visible = false;            

            btSourceFolder.Enabled = true;

            btUpload.Text = "Upload";
            btUpload.Image = ((System.Drawing.Image)(Properties.Resources.Upload_Green_48x48));

            if (Last.OperationAborted)
            {
                StatusLabel.Text = "The last operation was cancelled!";
            }
            else
            {
                StatusLabel.Text = "Dishes are done!";
            }
        }        
    }
}