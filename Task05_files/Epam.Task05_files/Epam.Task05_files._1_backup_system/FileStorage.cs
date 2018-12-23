using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task05_files._1_backup_system
{
    public static class FileStorage
    {
        private const string typeOfFiles = "*.txt";
        private const int BufferSize = 65536;

        //public const string StoragePath = Path.Combine(Environment.SystemDirectory, "MyStorage\\");
        //public const string StoragePath = @"MyStorage\";
        public const string StoragePath = @"C:\Users\5F\Desktop\MyStorage\";
        private const string FileHistory = "history.txt";
        private const string FileContent = "text.txt";
        //private const string FileWatcherDirectory = "watch to directory.txt";
        //private static string historyPathTxt = Path.Combine(StoragePath, FileHistory);
        //private static string watcherPathTxt = Path.Combine(StoragePath, FileWatcherDirectory);
        private static List<string> foldersInStorageList;

        private static string watchingPath;
        private static FileSystemWatcher watcher;

        public const string SeparatorForIndex = "_";
        public const string SeparatorForDate = "#";
        public const string SeparatorForNumberOfLine = "#";
        private const string HistoryTxtName = "history.txt";
        private const string TextTxtName = "text.txt";
        private const string CreateEventText = "created";
        private const string RenameEventText = "renamed";
        private const string ChangedEventText = "changed";
        private const string DeletedEventText = "deleted";
        //private const string DateMask = "yyyy-MM-dd-HH-mm-ss";
        private const string ErrorText = "Can not work with Storage";

        public static string WatchingPath
        {
            get
            {
                return watchingPath;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Path to folder is empty");
                }

                watchingPath = value;
            }
        }

        private static void SetSetttingsForWatcher()
        {
            watcher = new FileSystemWatcher();
            DateTime t = DateTime.Now;
            watcher.Path = watchingPath;
            watcher.Created += new FileSystemEventHandler(CreateEvent);
            watcher.Renamed += new RenamedEventHandler(RenameEvent);
            watcher.Deleted += new FileSystemEventHandler(DeleteEvent);
            watcher.Changed += new FileSystemEventHandler(ChangeEvent);
            watcher.Filter = typeOfFiles;
            watcher.InternalBufferSize = BufferSize;
            //MessageBox.Show(watcher.InternalBufferSize.ToString());
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            //watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            //watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        private static void FoldersInStorage()
        {
            foldersInStorageList = new List<string>();
            string[] tempString=Directory.GetDirectories(StoragePath);
            foreach (var item in tempString)
            {
                foldersInStorageList.Add(item);
            }
        }

        public static bool StartWatching()
        {
            FoldersInStorage();
            if (!CreateStorageFolder())
            {
                return false;
            }
            SetSetttingsForWatcher();
            
            return true;
        }

        public static bool StopWatching()
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        

        private static void CreateEvent(object source, FileSystemEventArgs e)
        {
            CreateFolder(e.Name);
        }

        private static void RenameEvent(object source, RenamedEventArgs e)
        {
            RenameFolder(e.OldName, e.Name);
        }

        private static void DeleteEvent(object source, FileSystemEventArgs e)
        {
            string nameOfFile = e.Name;
            string pathInStorage = FindNeedFolder(nameOfFile);
            if (!string.IsNullOrEmpty(pathInStorage))
            {
                WriteToHistoryTxt(pathInStorage,nameOfFile,DeletedEventText);
            }
        }

        private static void ChangeEvent(object source, FileSystemEventArgs e)
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                string fileName = e.Name;
                string needFolder = FindNeedFolder(e.Name);
                if (string.IsNullOrEmpty(needFolder))
                {
                    CreateFolder(e.Name);
                    WriteToTextTxt(Path.Combine(needFolder, TextTxtName), Path.Combine(watchingPath, fileName),true);
                }
                else
                {
                    WriteToTextTxt(Path.Combine(needFolder, TextTxtName), Path.Combine(watchingPath, fileName),true);
                }
            }
            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        private static void WriteToTextTxt(string pathToTxt, string fromTxt, bool nessanecessarilyWrite=false)
        {
            string[] stringsInFile = File.ReadAllLines(fromTxt);
            if (stringsInFile.Length == 0 && !nessanecessarilyWrite)
            {
                return;
            }
            if (File.Exists(pathToTxt))
            {
                string[] textWas = File.ReadAllLines(pathToTxt);
                List<string> subText = new List<string>();
                int countOfDates = 0;
                if (textWas.Length != 0)
                {
                    foreach (var item in textWas)
                    {
                        if (item.IndexOf(SeparatorForNumberOfLine) > 0)
                        {
                            int start = item.IndexOf(SeparatorForNumberOfLine) + 1;
                            int tempLength = item.Length - item.IndexOf(SeparatorForNumberOfLine) - 1;
                            if (countOfDates == 1)
                            {
                                subText.Add(item.Substring(start, tempLength));
                            }
                            else
                            {
                                string index = item.Substring(0, item.IndexOf(SeparatorForNumberOfLine));
                                if (int.TryParse(index, out int numberOfString))
                                {
                                    if (numberOfString>=subText.Count)
                                    {
                                        subText.Add(item.Substring(start, tempLength));
                                    }
                                    else
                                    {
                                        subText[numberOfString] = item.Substring(start, tempLength);
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException("Cannot take index of line in text.txt file");
                                }
                            }
                        }
                        else
                        {
                            countOfDates++;
                        }
                    }
                    StreamWriter sw = new StreamWriter(pathToTxt, true);
                    DateTime timeNow = DateTime.Now;
                    int count = 0;
                    sw.WriteLine(timeNow.ToString());
                    foreach (var item in stringsInFile)
                    {
                        if (count<subText.Count )
                        {
                            if (item != subText[count])
                            {
                                sw.WriteLine(count + SeparatorForNumberOfLine + item);
                            }
                        }
                        else
                        {
                            sw.WriteLine(count + SeparatorForNumberOfLine + item);
                        }
                        count++;
                    }
                    if (subText.Count>stringsInFile.Length)
                    {
                        for (int i= stringsInFile.Length; i< subText.Count;i++)
                        {
                            if (!string.IsNullOrEmpty(subText[i]))
                            {
                                sw.WriteLine(i + SeparatorForNumberOfLine);
                            }
                        }
                    }
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(pathToTxt, true);
                DateTime timeNow = DateTime.Now;
                int count = 0;
                sw.WriteLine(timeNow.ToString());
                foreach (var item in stringsInFile)
                {
                    sw.WriteLine(count + SeparatorForNumberOfLine + item);
                    count++;
                }
                sw.Close();
            }

        }

        private static void CreateFolder(string fileName)
        {
            try
            {
                DateTime timeNow = DateTime.Now;
                StringBuilder tempSB = new StringBuilder(40);
                int x = Directory.GetDirectories(StoragePath).Count();
                tempSB.Append(x);
                tempSB.Append(SeparatorForIndex);
                tempSB.Append(timeNow.ToBinary());
                tempSB.Append(SeparatorForDate);
                tempSB.Append(fileName);
                string FolderPath = Path.Combine(StoragePath, tempSB.ToString());
                Directory.CreateDirectory(FolderPath);
                WriteToHistoryTxt(FolderPath, fileName, CreateEventText);
                WriteToTextTxt(Path.Combine(FolderPath, TextTxtName), Path.Combine(watchingPath, fileName));
            }
            catch
            {
                throw new ArgumentException(ErrorText);
            }
        }

        private static void WriteToHistoryTxt(string folderForWrite,string nameOfFile, string nameOfEvent, string oldName="")
        {
            StreamWriter sw = new StreamWriter(Path.Combine(folderForWrite, HistoryTxtName),true);
            sw.WriteLine(nameOfEvent);
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(nameOfFile);
            sw.WriteLine(oldName);
            sw.Close();
        }

        private static void RenameFolder(string oldName, string name)
        {
            string needFolder = FindNeedFolder(oldName);
            if (string.IsNullOrEmpty(needFolder)) {
                CreateFolder(name);
            }
            else
            {
                string newFolderName = WorkWithTxt.CreateNewStringAfterSeparator(needFolder, name, SeparatorForDate);
                Directory.Move(needFolder, newFolderName);
                WriteToHistoryTxt(newFolderName,name,RenameEventText,oldName);
            }
            
        }

        private static string FindNeedFolder(string name)
        {
            FoldersInStorage();
            string needFolder = string.Empty;
            foreach (var item in foldersInStorageList)
            {
                if (item.Contains(name))
                {
                    needFolder = item;
                    break;
                }
            }
            return needFolder;
        }

        public static bool DeleteStorageFolder()
        {
            try
            {
                Directory.Delete(StoragePath, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool CreateStorageFolder()
        {
            try
            {
                Directory.CreateDirectory(StoragePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
