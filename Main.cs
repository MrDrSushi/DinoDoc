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
using System.Net;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Win32;

using System.Security;
using System.Security.Permissions;

using System.Threading;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Security.Principal;
using System.Runtime.InteropServices;
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
        public int TotalFailures;

        public string LogStatus;
        public Font   LogSelectionFont;
        public Color  LogSelectionColor;
    }

    public partial class frmMain : Form
    {
        LastActionProcessed Last;

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

                StatusLabel.Text = "Computing " + Last.ComputedFiles.ToString() + " files..." + Last.ComputedFiles.ToString();

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
        /// Returns the File Size from a local file 
        /// </summary>
        /// <param name="FileNameAndLocation">File Name and its Location</param>
        /// <returns>File Size</returns>        
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
        /// Returns the File Size from a file located on a remote server
        /// </summary>
        /// <param name="FileNameAndLocation">file location</param>
        /// <returns>long File Size</returns>
        public long GetRemoteFileSize(string FileNameAndLocation)
        {
            WebHeaderCollection headers;
            HttpWebResponse response;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(FileNameAndLocation);

            //
            //   Send the credentials before calling for the response()
            //

            if (rdDefault.Checked == true)
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

            request.Method = "HEAD";

            try
            {
                response = request.GetResponse() as HttpWebResponse;

                headers = response.Headers;

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
        /// Returns the file's date from a local file
        /// </summary>
        /// <param name="FileNameAndLocation"></param>
        /// <returns></returns>
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
        /// Returns the date from a file located on remote server
        /// </summary>
        /// <param name="FileNameAndLocation"></param>
        /// <returns></returns>
        public DateTime GetRemoteFileDate(string FileNameAndLocation)
        {
            WebHeaderCollection headers;
            HttpWebResponse response;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(FileNameAndLocation);

            //
            //   Send the credentials before calling for the response()
            //

            if (rdDefault.Checked == true)
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

            request.Method = "HEAD";

            try
            {
                response = request.GetResponse() as HttpWebResponse;

                headers = response.Headers;

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
        /// <param name="remoteFolderName"></param>
        /// <returns></returns>
        public HttpStatusCode CreateWebDAVFolder(string remoteFolderName)
        {
            remoteFolderName = remoteFolderName.Replace("\\", "/");

            Uri myURI = new Uri(remoteFolderName);

            WebRequest request = WebRequest.Create(myURI);          // WebRequest request = (WebRequest)WebRequest.Create(myUri);

            //
            //  Determine the authentication mode
            //

            if (rdDefault.Checked == true)
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

            // request.Credentials = CredentialCache.DefaultCredentials;

            request.Method = "MKCOL";

            HttpStatusCode statusCode;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    statusCode = httpResponse.StatusCode;

                    //Console.WriteLine(httpResponse.StatusCode);
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    if (response != null)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;

                        //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);

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
                WebRequest request;

                string originalName = System.IO.Path.GetFileName(remoteFile);
                string fixedName = FixName(originalName);

                //
                //  This will create the request to where we want to send the file to (URL Request)
                //

                request = WebRequest.Create(txtDestinationURL.Text);

                //
                //  Check file name compatibility comparing  "OriginalName vs FixedName"
                //

                if (originalName != fixedName)
                {
                    string newFileRenamed = System.IO.Path.GetDirectoryName(remoteFile);

                    newFileRenamed = newFileRenamed.Replace(@"\", @"/");
                    newFileRenamed = newFileRenamed.Replace(@":/", @"://");

                    request = WebRequest.Create(newFileRenamed + @"/" + fixedName);

                    //
                    // Let's keep the count of renamed files
                    //

                    Last.TotalFilesRenamed++;

                    #region Simulation Mode

                    /*
                     *     to be implemented
                     * 

                    //
                    //   Simulation Mode? YES or NO?
                    //

                    if (!Options_SimulationMode)
                    {
                        //
                        //   Check if the user allowed files to be overwritten
                        //
                        if (Options_OverwriteFiles)
                        {
                            //
                            //   Check File Size and Date or individually...
                            // 
                            if (Options_OverwriteFiles_FileSize && Options_OverwriteFiles_FileDate)
                            {
                                //
                                //   Will use OR or AND according to the settings from the registry
                                //
                                if (Options_OverwriteFiles_LogicalAND)
                                {
                                    if (GetLocalFileSize(localFile) != GetRemoteFileSize(remoteFile) && GetLocalFileDate(localFile) != GetRemoteFileDate(remoteFile))
                                    {
                                        request = WebRequest.Create(newFileRenamed + @"/" + fixedName);
                                    }
                                }
                                else
                                {
                                    if (GetLocalFileSize(localFile) != GetRemoteFileSize(remoteFile) || GetLocalFileDate(localFile) != GetRemoteFileDate(remoteFile))
                                    {
                                        request = WebRequest.Create(newFileRenamed + @"/" + fixedName);
                                    }
                                }
                            }
                            else if (Options_OverwriteFiles_FileSize)
                            {
                                if (GetLocalFileSize(localFile) != GetRemoteFileSize(remoteFile))
                                {
                                    request = WebRequest.Create(newFileRenamed + @"/" + fixedName);
                                }
                            }
                            else if (Options_OverwriteFiles_FileDate)
                            {
                                if (GetRemoteFileDate(remoteFile) != GetLocalFileDate(localFile))
                                {
                                    request = WebRequest.Create(newFileRenamed + @"/" + fixedName);
                                }
                            }
                        }
                    }
                    else
                    {
                        request = null;
                    }
                    
                    *
                    * 
                    */

                    #endregion

                }
                else
                {
                    //
                    //  simulation mode = on/off ?
                    //

                    if (!Settings.Default.OptionsSimulationMode)
                    {
                        request = WebRequest.Create(remoteFile);
                    }
                    else
                    {
                        request = null;
                    }
                }

                //
                //  This will define the Content Type for the request
                //

                //    request.ContentType = "application/x-www-form-urlencoded";   //  I'M NOT USING THIS THING RIGHT NOW!!!!

                request.Method = Settings.Default.OptionsAuthenticationMethod;    // POST or PUT, will be determined by program options                

                //
                //  Connection Time-out, right now is internal and I plan to make it available in the Options dialog later
                //

                request.Timeout = 30000;

                //
                //  Determine the Credentials used for authentication
                //

                if (rdDefault.Checked == true)
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
                    request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f"); // request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "t");
                }

                #region Old WebRequest Transfer (not in use for now)
                /*************  old no longer working

                //
                //   Defines the real length of the request to be sent
                //


                // 1st = open the source file
                FileStream streamSourceFile = File.OpenRead(localFile);

                // 2nd = loads the buffer by determining the length from the source
                byte[] bufferSourceFile = new byte[streamSourceFile.Length];

                // 3rd = read from the source file into the buffer according to the lenght of the file
                streamSourceFile.Read(bufferSourceFile, 0, bufferSourceFile.Length); //   bufferSourceFile.Length);

                // 4th = the lenght of the content is the size of the buffer
                request.ContentLength = bufferSourceFile.Length;
                

                //
                //  Writes the file to its destination
                //

                BinaryWriter writer = new BinaryWriter(request.GetRequestStream());   // new BinaryWriter(request.GetRequestStream());

                writer.Write(bufferSourceFile, 0, bufferSourceFile.Length);  // Write(bufferSourceFile, 0, bufferSourceFile.Length);
                writer.Close();
                
                * 
                * 
                ****************************/
                #endregion


                //
                //  Provides the user feedback about the last file operation
                //

                if (originalName != fixedName)
                {
                    //
                    //  I will replace the standard ListView by the amazing ObjectListView, which will be more useful to display the progress for long operations
                    //  whne I'm uploading really big files, I can use the for-loop to indicate a dedicate progress bar for invidual files while the use watchs the updates on the screen
                    //
                    //  FileOperations item = new FileOperations(localFile, System.IO.Path.GetFileName(localFile), fixedName.Replace("\\", "/"), "New");
                    //  lvStatus.AddObject(item);
                    // 

                    string[] liRow = { System.IO.Path.GetFileName(localFile), fixedName.Replace("\\", "/"), "New and Renamed" };

                    lvStatus.Invoke((MethodInvoker)delegate()
                        {
                            lvStatus.Items.Add(localFile).SubItems.AddRange(liRow);
                        }
                    );

                    //lvStatus.Items.Add(localFile).SubItems.AddRange(liRow);

                    byte[] fileBuffer = new byte[1024];                                                                     // Create buffer to transfer file                
                    using (Stream stream = request.GetRequestStream())                                                      // Write the contents of the local file to the request stream.
                    {
                        using (FileStream fsUploadStream = File.Open(localFile, FileMode.Open, FileAccess.Read))            // Load the content from local file to stream
                        {
                            int startBuffer = fsUploadStream.Read(fileBuffer, 0, fileBuffer.Length);                        // Get the start point
                            for (int i = startBuffer; i > 0; i = fsUploadStream.Read(fileBuffer, 0, fileBuffer.Length))
                            {
                                stream.Write(fileBuffer, 0, i);
                            }
                        }
                    }

                }
                else
                {
                    //
                    //  I will replace the standard ListView by the amazing ObjectListView, which will be more useful to display the progress for long operations
                    //  whne I'm uploading really big files, I can use the for-loop to indicate a dedicate progress bar for invidual files while the use watchs the updates on the screen
                    //
                    //  FileOperations item = new FileOperations(localFile, System.IO.Path.GetFileName(localFile), fixedName.Replace("\\", "/"), "New");
                    //  lvStatus.AddObject(item);
                    // 

                    string[] liRow = { System.IO.Path.GetFileName(localFile), remoteFile.Replace("\\", "/"), "New" };
                   
                    lvStatus.Invoke((MethodInvoker)delegate()
                        {
                          lvStatus.Items.Add(localFile).SubItems.AddRange(liRow);
                        }
                    );

                    //lvStatus.Items.Add(localFile).SubItems.AddRange(liRow);

                    byte[] fileBuffer = new byte[1024];                                                                     // Create buffer to transfer file                
                    using (Stream stream = request.GetRequestStream())                                                      // Write the contents of the local file to the request stream.
                    {
                        using (FileStream fsUploadStream = File.Open(localFile, FileMode.Open, FileAccess.Read))            // Load the content from local file to stream
                        {
                            int startBuffer = fsUploadStream.Read(fileBuffer, 0, fileBuffer.Length);                        // Get the start point
                            for (int i = startBuffer; i > 0; i = fsUploadStream.Read(fileBuffer, 0, fileBuffer.Length))
                            {
                                stream.Write(fileBuffer, 0, i);
                            }
                        }
                    }
                }

                WebResponse response = request.GetResponse(); // upload the file

                response.Close(); // close the connection

                Last.LogStatus = "OK = " + localFile + "\n";
                
                //LogStatus.AppendText("OK = " + localFile + "\n");
            }
            catch (Exception ex)
            {
                string[] liRow = { System.IO.Path.GetFileName(localFile), remoteFile.Replace("\\", "/"), "failure" };

                lvStatus.Invoke((MethodInvoker)delegate()
                    {
                        lvStatus.Items.Add(localFile).SubItems.AddRange(liRow);
                    }
                );
                
                Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                Last.LogSelectionColor = Color.Red;
                Last.LogStatus = "\nfailure = " + localFile + " --- " + ex.Message + "\n\n";


                //lvStatus.Items.Add(localFile).SubItems.AddRange(liRow);

                //LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                //LogStatus.SelectionColor = Color.Red;

                //LogStatus.AppendText("\nfailure = " + localFile + " --- " + ex.Message + "\n\n");

                //LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                //LogStatus.SelectionColor = Color.Black;

                Last.TotalFailures++;
            }
        }
        
        /// <summary>
        /// Used to start the Upload process, which will compute, create folders (CreateWebDavFolder) and upload files (UploadDocument)
        /// </summary>
        /// <param name="SourceDir">source location</param>
        /// <param name="TargetDir">target location</param>
        /// <param name="recursionLvl">recursivity level (default = 0)</param>
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
                        break;
                    }

                    Last.TotalFiles++;
                    Last.ComputedFileFolder = "file: " + fileName;

                    backgroundWorker.ReportProgress(Last.TotalFiles + Last.TotalFolders); 

                    UploadDocument(fileName, TargetDir + @"/" + System.IO.Path.GetFileName(fileName));                    
                }

                //
                // Recurse into subdirectories of this directory.
                //

                string[] subdirEntries = Directory.GetDirectories(SourceDir);

                foreach (string subdir in subdirEntries)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        break;
                    }

                    if ((File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                    {
                        Last.TotalFolders++;
                       
                        HttpStatusCode resultCode;

                        string FixedName = FixName(System.IO.Path.GetFileName(subdir));
                        string DirName = FixName(System.IO.Path.GetFileName(subdir));

                        Last.ComputedFileFolder = "folder: " + DirName;

                        backgroundWorker.ReportProgress(Last.TotalFiles + Last.TotalFolders); 

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


                            //string[] liRow = { "", System.IO.Path.GetFileName(DirName), "Folder Already Exists" };

                            //lvStatus.Items.Add(DirName).SubItems.AddRange(liRow);

                            //LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            //LogStatus.SelectionColor = Color.Blue;

                            //LogStatus.AppendText(
                            //                        "\n" + new string('-', 28 + DirName.Length) + "\n" +
                            //                        "---- FOLDER ALREADY EXISTS: " + DirName + "\n" +
                            //                        new string('-', 28 + DirName.Length) + "\n\n"
                            //);

                            //LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            //LogStatus.SelectionColor = Color.Black;
                        }
                        else
                        {
                            if (DirName != FixedName)
                            {
                                string[] liRow = { "", TargetDir + @"/" + System.IO.Path.GetFileName(DirName), "New Folder and Renamed" };

                                Last.ListMsg = "";
                                Last.ListDir = subdir;
                                Last.ListRow = liRow;

                                //lvStatus.Items.Add(subdir).SubItems.AddRange(liRow);
                            }
                            else
                            {
                                string[] liRow = { "", TargetDir + @"/" + System.IO.Path.GetFileName(DirName), "New Folder" };

                                Last.ListMsg = "";
                                Last.ListDir = subdir;
                                Last.ListRow = liRow;

                                //lvStatus.Items.Add(subdir).SubItems.AddRange(liRow);
                            }

                            Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            Last.LogSelectionColor = Color.Blue;
                            Last.LogStatus = "\n" + new string('-', 18 + DirName.Length) + "\n" +
                                             "---- NEW FOLDER: " + DirName + "\n" +
                                             new string('-', 18 + DirName.Length) + "\n\n";


                            //LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            //LogStatus.SelectionColor = Color.Blue;

                            //LogStatus.AppendText(
                            //                       "\n" + new string('-', 18 + DirName.Length) + "\n" +
                            //                       "---- NEW FOLDER: " + DirName + "\n" +
                            //                       new string('-', 18 + DirName.Length) + "\n\n"
                            //);

                            //LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                            //LogStatus.SelectionColor = Color.Black;
                        }

                        Uploader(subdir, TargetDir + @"/" + DirName, recursionLvl + 1);
                    }
                }
            }

            if (backgroundWorker.CancellationPending)
            {
                return;
            }
        }

        private void btSourceFolder_Click(object sender, EventArgs e)
        {
            if (txtSourcePath.Text.Length > 0)
            {
                flSourceDig.SelectedPath = txtSourcePath.Text;
            }

            flSourceDig.ShowDialog();
            txtSourcePath.Text = flSourceDig.SelectedPath;
        }

        private void rdProvide_CheckedChanged(object sender, EventArgs e)
        {
            txtUserPassword.Enabled = true;
            txtUserName.Enabled = true;
            txtUserDomain.Enabled = true;
        }

        private void rdDefault_CheckedChanged(object sender, EventArgs e)
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
                // disable controls to prevent unwanted interactions that may affect the current task

                txtSourcePath.Enabled = false;
                txtDestinationURL.Enabled = false;
                btSourceFolder.Enabled = false;
                grpboxAuthentication.Enabled = false;
                ContextMenuLog.Enabled = false;

                MenuTools_Options.Enabled = false;
                
                // reset the struct 

                Last.LogStatus = "";
                Last.LogSelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
                Last.LogSelectionColor = Color.Black;

                Last.ComputedFiles = 0;
                Last.ComputedFolders = 0;
                Last.ComputedFileFolder = "";

                Last.TotalFolders = 0;
                Last.TotalFiles = 0;
                Last.TotalFilesRenamed = 0;
                Last.TotalFailures = 0;

                Last.ListDir = "";
                Last.ListRow = null; 

                // modify the button enabling it to CANCEL the operation

                btUpload.Text = "Cancel";
                btUpload.Image = ((System.Drawing.Image)(Properties.Resources.Upload_Cancel_48x48));
                
                //  start uploading files

                ComputeItems(txtSourcePath.Text.Trim(), 0);

                StripProgressBar.Visible = true;
                StripProgressBar.Maximum = Last.ComputedFiles + Last.ComputedFolders;

                backgroundWorker.RunWorkerAsync(); //    Uploader(txtSourcePath.Text.Trim(), txtDestinationURL.Text.Trim(), 0);
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
            LogStatus.SelectionColor = Color.Black;


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

            //



            LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
            LogStatus.SelectionColor = Color.DarkBlue;

            LogStatus.AppendText(
                    "\n\nImport Process Completed at " + String.Format("{0:MM-dd-yyyy - hh:mm:ss}", System.DateTime.Now) + "\n\n" +

                    "Folders Processed...: " + Last.TotalFolders.ToString() + "\n" +
                    "Files Processed.....: " + Last.TotalFiles.ToString() + "\n" +
                    "Files Renamed.......: " + Last.TotalFilesRenamed.ToString() + "\n" +
                    "Failures............: " + Last.TotalFailures.ToString() + "\n"
            );

            LogStatus.SelectionFont = new Font("Lucida Console", 9f, FontStyle.Regular);
            LogStatus.SelectionColor = Color.Black; ;

            TextWriter tw = new StreamWriter("Last Operation.rtf");

            tw.WriteLine(LogStatus.Text);
            tw.Close();

            StatusLabel.Text = "Dishes are done!";

            btSourceFolder.Enabled = true;

            btUpload.Text = "Upload";
            btUpload.Image = ((System.Drawing.Image)(Properties.Resources.Upload_Green_48x48));
        }        
    }
}