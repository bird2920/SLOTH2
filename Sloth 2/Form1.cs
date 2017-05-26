#region Usings
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
#endregion

namespace Sloth_2
{
    public partial class Form1 : Form
    {
        string checkedRadio = "0";
        string inputPath = Properties.Settings.Default.InputPath;
        string outputPath = Properties.Settings.Default.OutputPath;
        static Regex reg = new Regex(":");
        string[,] UndoString;

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new Size(633, Screen.PrimaryScreen.WorkingArea.Height);

            tbInputPath.Text = inputPath;
            tbOutputPath.Text = outputPath;
            tbDateModifiedYear.Text = DateTime.Today.Year.ToString();

            //Sloth_Header();
        }

        #region Buttons
        void InputPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.InputPath = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();

                tbInputPath.Text = Properties.Settings.Default.InputPath;
            }
        }

        void OutputPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.OutputPath = folderBrowserDialog2.SelectedPath;
                Properties.Settings.Default.Save();

                tbOutputPath.Text = Properties.Settings.Default.OutputPath;
            }
        }

        void Expand_Click(object sender, EventArgs e)
        {
            if (ActiveForm.Width < 633)
            {
                ActiveForm.Width = 633;
            }
            else
            {
                ActiveForm.Width = 537;
            }
        }

        void ClearLog_Click(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
        }

        void GO_Click(object sender, EventArgs e)
        {
            Validate_and_Start();
        }

        void cbRecursive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRecursive.Checked == true)
            {
                MessageBox.Show("WARNING: This will get files from all sub directories" + Environment.NewLine +
                                "                        NOT just the parent folder.");
            }
        }

        #region Radio Buttons

        void ByExtension_CheckedChanged(object sender, EventArgs e)
        {
            checkedRadio = "1";
            tbSplitChar.Enabled = false;
            tbDateModifiedYear.Enabled = false;
            tbDateModifiedYear.Visible = false;
        }

        void ByDate_CheckedChanged(object sender, EventArgs e)
        {
            checkedRadio = "2";
            tbSplitChar.Enabled = false;
            tbDateModifiedYear.Enabled = false;
            tbDateModifiedYear.Visible = false;
        }

        void BySeparator_CheckedChanged(object sender, EventArgs e)
        {
            checkedRadio = "3";
            tbSplitChar.Enabled = true;
            tbDateModifiedYear.Enabled = false;
            tbDateModifiedYear.Visible = false;
        }

        void ByLastAccessed_CheckedChanged(object sender, EventArgs e)
        {
            checkedRadio = "4";
            //Expand_Click(null, null);
            tbDateModifiedYear.Enabled = true;
            tbSplitChar.Enabled = false;
            tbDateModifiedYear.Visible = true;
        }

        void ByDateTaken_CheckedChanged(object sender, EventArgs e)
        {
            checkedRadio = "5";
            tbSplitChar.Enabled = false;
            tbDateModifiedYear.Enabled = false;
            tbDateModifiedYear.Visible = false;
        }

        void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            checkedRadio = "6";
            tbSplitChar.Enabled = false;
            tbDateModifiedYear.Enabled = false;
            tbDateModifiedYear.Visible = false;
        }
        #endregion

        #endregion

        #region Logic
        //TODO:Add header to log file
        void Sloth_Header()
        {
            lbLog.Items.Add(" SSSSS   LL        OOOOO   TTTTTTT HH   HH");
            lbLog.Items.Add("SS       LL      OO     OO   TTT   HH   HH B");
            lbLog.Items.Add(" SSSSS   LL      OO     OO   TTT   HHHHHHH I");
            lbLog.Items.Add("     SS  LL       OO   OO    TTT   HH   HH R");
            lbLog.Items.Add(" SSSSS   LLLLLLL   OOOOO     TTT   HH   HH D");
            lbLog.Items.Add("---------------------------------------");
            lbLog.Items.Add("Sloth File Organizer \r\n");
            lbLog.Items.Add("---------------------------------------");
        }

        void Validate_and_Start()
        {
            Log_Window("****************************************************");
            Log_Window("Begin");
            Log_Window("--------------------------");

            try
            {
                if (ValidatePaths(tbInputPath.Text, tbOutputPath.Text) == 2)
                {
                    Log_Window("Getting Files");
                    FileInfo[] files;

                    files = GetFiles(tbInputPath.Text, tbPattern.Text);

                    if (files.Length > 0)
                    {
                        MoveFile_ProcessStart(files, tbOutputPath.Text, checkedRadio, tbSplitChar.Text);
                    }
                    else
                    {
                        Log_Window("Nothing to move");
                    }
                }
                else
                {
                    Log_Window("One or more paths do not exist. Check both of your paths");
                }
            }
            catch (Exception ex)
            {
                Log_Window(ex.Message);
            }

            Log_Window("End");
        }

        #region MoveFile
        void MoveFile_ProcessStart(FileInfo[] files, string path2, string folderType, string splitCharacter)
        {
            //Start File Move
            Log_Window("Start File Move...");
            Log_Window($"Files found: {files.Length}");
            Log_Window("--------------------------");

            if (!Directory.Exists(path2))
            {
                path2 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads" + "\\" + "Sloth";
            }

            MoveFile_Logic(files, path2, folderType, splitCharacter);

            Log_Window("--------------------------");
            Log_Window("End File Move");
        }

        void MoveFile_Logic(FileInfo[] files, string path2, string folderType, string splitCharacter)
        {
            DirectoryInfo directory;
            int count = 1;

            Update_Progress($"Files Found: {files.Length}");

            foreach (var file in files)
            {
                if (file.Extension == ".lnk") continue;
                if (file.Extension == string.Empty) continue;

                Log_Window("Moving file " + file.FullName);

                try
                {
                    switch (folderType)
                    {
                        case "1":
                            directory = Directory.CreateDirectory(path2
                                + "\\"
                                + file.Extension.Substring(1));
                            MoveFile_Move(file, directory);
                            Update_Progress($"Files Moved: {count++} of {files.Length}");
                            break;
                        case "2":
                            directory = Directory.CreateDirectory(Directory_ByDate(path2, file.CreationTime));
                            MoveFile_Move(file, directory);
                            Update_Progress($"Files Moved: {count++} of {files.Length}");
                            break;
                        case "3":
                            if (!file.Name.Contains(splitCharacter))
                            {
                                directory = Directory.CreateDirectory(path2 + "\\" + file.Extension.Substring(1));
                                MoveFile_Move(file, directory);
                                Update_Progress($"Files Moved: {count++} of {files.Length}");
                            }
                            else
                            {
                                var newFolderName = file.Name.Substring(0, file.Name.IndexOf(splitCharacter, StringComparison.CurrentCulture));
                                directory = Directory.CreateDirectory(path2 + "\\" + newFolderName);
                                MoveFile_Move(file, directory);
                                Update_Progress($"Files Moved: {count++} of {files.Length}");
                            }
                            break;
                        case "4":
                            if (file.LastWriteTimeUtc.Year <= Convert.ToInt32(tbDateModifiedYear.Text))
                            {
                                directory = Directory.CreateDirectory(Directory_ByDate(path2, file.LastWriteTimeUtc));
                                MoveFile_Move(file, directory);
                                Update_Progress($"Files Moved: {count++} of {files.Length}");
                            }
                            else
                            {
                                Log_Window($"{file.Name} LastAccess Year > {tbDateModifiedYear.Text}");
                                //Log_Window("File not moved");
                            }
                            break;
                        case "5":

                            DateTime DateTaken;
                            if (file.FullName.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                                file.FullName.EndsWith(".jpeg", StringComparison.CurrentCultureIgnoreCase) ||
                                file.FullName.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) ||
                                file.FullName.EndsWith(".tif", StringComparison.CurrentCultureIgnoreCase) ||
                                file.FullName.EndsWith(".tiff", StringComparison.CurrentCultureIgnoreCase) ||
                                file.FullName.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                                file.FullName.EndsWith(".bmp", StringComparison.CurrentCultureIgnoreCase))
                            {
                                DateTaken = GetDateTakenFromImage(file.FullName);
                                directory = Directory.CreateDirectory(Directory_ByDate(path2, DateTaken));

                                MoveFile_Move(file, directory);
                                Update_Progress($"Files Moved: {count++} of {files.Length}");
                            }
                            else
                            {
                                Log_Window($"Not an image {file.Name}");
                            }
                            break;
                        case "6":
                            directory = Directory.CreateDirectory(path2);

                            MoveFile_Move(file, directory);
                            Update_Progress($"Files Moved: {count++} of {files.Length}");
                            break;
                        default:
                            directory = Directory.CreateDirectory(path2 + "\\" + file.Extension.Substring(1));
                            MoveFile_Move(file, directory);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Log_Window("--------------------------");
                    Log_Window(ex.Message);
                }
            }

            if (cbDeleteEmptyDir.Checked == true)
            {

                if (Properties.Settings.Default.InputPath == path2)
                {
                    DeleteEmptyDirs(Properties.Settings.Default.InputPath);
                }
                else
                {
                    DeleteEmptyDirs(Properties.Settings.Default.InputPath);
                    DeleteEmptyDirs(path2);
                }
            }

            Log_Window($"Files Moved: {count - 1}");
        }

        void MoveFile_Move(FileInfo file, DirectoryInfo directory)
        {
            if (!File.Exists(directory.FullName + "\\" + file.Name))
            {
                File.Move(file.FullName, directory.FullName + "\\" + file.Name);
                //TODO:Fix this - the below method doesn't exist yet. Trying to vette it out
                //CreateUndoArray(file.Directory, directory.FullName + file.Name);

                //Log_Window("Moved");
            }
            else
            {
                Log_Window("File already exists:");
                Log_Window(file.FullName);
            }
        }
        #endregion

        string Directory_ByDate(string path, DateTime date)
        {
            var dateDirectory = path + "\\"
                                + Convert.ToString(date.Year)
                                + "\\"
                                + Convert.ToString(date.Month)
                                + "\\"
                                + "Day "
                                + Convert.ToString(date.Day);

            return dateDirectory;
        }

        public static DateTime GetDateTakenFromImage(string path)
        {
            //retrieves the datetime WITHOUT loading the whole image
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image myImage = Image.FromStream(fs, false, false))
            {
                PropertyItem propItem = myImage.GetPropertyItem(36867);
                var dateTaken = reg.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                return DateTime.Parse(dateTaken);
            }
        }

        FileInfo[] GetFiles(string path, string pattern)
        {
            //If the input path doesn't exist, use the default downloads directory
            if (!Directory.Exists(path))
            {
                tbInputPath.Text = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
            }

            var info = new DirectoryInfo(tbInputPath.Text);

            Debug.Assert(pattern != null, "pattern != null");

            FileInfo[] files;

            //If recursive checked, search all folder and sub folders
            if (cbRecursive.Checked == true)
            {
                files = info.GetFiles(pattern, SearchOption.AllDirectories).OrderBy(p => p.CreationTime).ToArray();
            }
            //Otherwise just search parent folder
            else
            {
                files = info.GetFiles(pattern).OrderBy(p => p.CreationTime).ToArray();
            }

            //Prints files ready for move to log window
            foreach (var file in files)
            {
                Log_Window(file.FullName);
            }

            return files;
        }

        int ValidatePaths(string path1, string path2)
        {

            var returnvalue = 0;

            var InputExists = Directory.Exists(path1);
            var OutputExists = Directory.Exists(path2);

            if (!InputExists)
                Directory.CreateDirectory(path1);
            Log_Window("Input path exists");

            returnvalue++;
            if (!OutputExists)
                Directory.CreateDirectory(path2);
            Log_Window("Output path exists");
            returnvalue++;

            return returnvalue;
        }

        void PathChange_SaveProperties(object sender, EventArgs e)
        {
            Properties.Settings.Default.InputPath = tbInputPath.Text;
            Properties.Settings.Default.OutputPath = tbOutputPath.Text;

            Properties.Settings.Default.Save();
        }

        void Log_Window(string value)
        {
            lbLog.Items.Add(DateTime.Now + "   " + value);
            lbLog.TopIndex = lbLog.Items.Count - 1;
        }

        void Update_Progress(string value)
        {
            lblProgress.Text = value;
            lblProgress.Refresh();
        }

        void WriteLogFile(object sender, EventArgs e)
        {
            var LogPath = tbOutputPath.Text + "\\Sloth_"
                + DateTime.Today.Year
                + DateTime.Today.Month
                + DateTime.Today.Day
                + "_"
                + DateTime.Now.Hour
                + DateTime.Now.Minute
                + DateTime.Now.Second
                + ".txt";

            //Create empty list
            List<string> data = new List<string>();

            //Fill the list
            foreach (var line in lbLog.Items)
            {
                //Convert listbox items from object to string
                data.Add(line.ToString());
            }

            File.WriteAllLines(LogPath, data);

            Process.Start(LogPath);
        }

        static void DeleteEmptyDirs(string dir)
        {
            if (string.IsNullOrEmpty(dir))
                throw new ArgumentException("Starting directory is a null reference or an empty string", dir);

            try
            {
                foreach (var d in Directory.EnumerateDirectories(dir))
                {
                    DeleteEmptyDirs(d);
                }

                var entries = Directory.EnumerateFileSystemEntries(dir);

                if (!entries.Any())
                {
                    try
                    {
                        Directory.Delete(dir);
                    }
                    catch (UnauthorizedAccessException) { }
                    catch (DirectoryNotFoundException) { }
                }
            }
            catch (UnauthorizedAccessException) { }
        }



        void UndoMove(string outPath, string inPath)
        {
            
            var currentDir = outPath; 
            var originalDir = inPath;

            var files = GetFiles(currentDir, null);

            if (files.Length > 0)
            {
                MoveFile_ProcessStart(files, originalDir, "6", null);
            }
            else
            {
                Log_Window("Nothing to move");
            }

        }
    #endregion

    #region BackgroundWorker - Future release
    void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        int PerformHeavyOperation(int i)
        {
            Thread.Sleep(250);
            return i * 1000;
        }
        #endregion

    }
}
