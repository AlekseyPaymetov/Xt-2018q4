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
        internal const string FileHistory = "history.txt";
        internal const string FileContent = "text.txt";
        internal const string SeparatorForIndex = "_";
        internal const string SeparatorForDate = "#";
        internal const string SeparatorForNumberOfLine = "#";
        internal const string FolderBegin = "@";
        internal const string FileBegin = "$";
        internal const string DeletedEventText = "deleted";

        private const string ErrorText = "Can not work with Storage";
        
        private const string HistoryTxtName = "history.txt";
        private const string TextTxtName = "text.txt";
        private const string CreateEventText = "created";
        private const string RenameEventText = "renamed";
        private const string ChangedEventText = "changed";
        private const string TypeOfFiles = "*.txt";
        private const int BufferSize = 65536;
        private static string watchingPath;
        private static FileSystemWatcher watcher;
        private static string storagePath = Path.Combine(Environment.SystemDirectory, "MyStorage\\");

        public static string StoragePath
        {
            get
            {
                return storagePath;
            }

            private set
            {
                storagePath = value;
            }
        }

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

        public static bool StartWatching()
        {
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

        public static string CreateNewStringAfterSeparator(string oldFolder, string name, string separator, bool second = false)
        {
            char charSeparator = separator.ToCharArray()[0];
            int indexToCut = oldFolder.IndexOf(charSeparator);
            if (second)
            {
                string tempString = oldFolder.Substring(indexToCut + 1, oldFolder.Length - indexToCut - 1);
                indexToCut += tempString.IndexOf(charSeparator) + 1;
            }

            string newPath = oldFolder.Substring(0, indexToCut + 1);
            return newPath + name;
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

        internal static List<string> FoldersInPath()
        {
            string path = StoragePath;
            List<string> tempList = new List<string>();
            string[] tempString = Directory.GetDirectories(path);
            foreach (var item in tempString)
            {
                tempList.Add(item);
            }

            return tempList;
        }

        internal static List<string> GetFullSubFolders(string path)
        {
            List<string> tempList = new List<string>();
            string[] folders = Directory.GetDirectories(path);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories("*.*", SearchOption.AllDirectories))
            {
                tempList.Add(subDirectoryInfo.FullName);
            }

            return tempList;
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
            watcher.Filter = TypeOfFiles;
            watcher.InternalBufferSize = BufferSize;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        private static void CreateEvent(object source, FileSystemEventArgs e)
        {
            CreateFolder(e.Name);
        }

        private static void RenameEvent(object source, RenamedEventArgs e)
        {
            RenameFolder(e.OldName, e.Name);
        }

        private static string GetFullSubPath(string fileName)
        {
            string folders = GetSubFolders(fileName);
            string needFolder = FindNeedSubFolders(folders);
            fileName = GetFileName(fileName);
            string[] subFolders = Directory.GetDirectories(needFolder);
            foreach (var item in subFolders)
            {
                if (item.Contains(fileName))
                {
                    needFolder = item;
                }
            }

            return needFolder;
        }

        private static void DeleteEvent(object source, FileSystemEventArgs e)
        {
            string fileName = e.Name;
            string pathInStorage = string.Empty;
            if (fileName.IndexOf(@"\") < 0)
            {
                pathInStorage = FindNeedFolder(fileName);
            }
            else
            {
                string needFolder = GetFullSubPath(fileName);
                fileName = GetFileName(fileName);
                pathInStorage = needFolder;
            }

            if (!string.IsNullOrEmpty(pathInStorage))
            {
                WriteToHistoryTxt(pathInStorage, fileName, DeletedEventText);
            }
        }

        private static void ChangeEvent(object source, FileSystemEventArgs e)
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                string fileName = e.Name;
                string fullPath = e.FullPath;
                string needFolder = string.Empty;
                if (fileName.IndexOf(@"\") < 0)
                {
                    needFolder = FindNeedFolder(fileName);
                    if (string.IsNullOrEmpty(needFolder))
                    {
                        CreateFolder(fileName);
                    }
                }
                else
                {
                    needFolder = GetFullSubPath(fileName);
                    if (string.IsNullOrEmpty(needFolder))
                    {
                        CreateFolder(fileName);
                    }
                }

                WriteToTextTxt(Path.Combine(needFolder, TextTxtName), fullPath, true);
            }
            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        private static void WriteToTextTxt(string pathToTxt, string fromTxt, bool nessanecessarilyWrite = false)
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
                                    if (numberOfString >= subText.Count)
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
                        if (count < subText.Count)
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

                    if (subText.Count > stringsInFile.Length)
                    {
                        for (int i = stringsInFile.Length; i < subText.Count; i++)
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

        private static string GetSubFolders(string incorrectFileName)
        {
            string folders = string.Empty;
            int indexOfTxtFile = incorrectFileName.LastIndexOf(@"\") + 1;
            folders = incorrectFileName.Substring(0, indexOfTxtFile - 1);
            return folders;
        }

        private static string GetFileName(string incorrectFileName)
        {
            string fileName = string.Empty;
            int indexOfTxtFile = incorrectFileName.LastIndexOf(@"\") + 1;
            int lengthOfTxtFile = incorrectFileName.Length - incorrectFileName.LastIndexOf(@"\") - 1;
            fileName = incorrectFileName.Substring(indexOfTxtFile, lengthOfTxtFile);
            return fileName;
        }

        private static void CreateFolder(string fileName)
        {
            DateTime timeNow = DateTime.Now;
            string folderPath = string.Empty;
            string incorrectFileName = fileName;
            StringBuilder tempSB = new StringBuilder(50);
            int x = Directory.GetDirectories(StoragePath).Count();
            tempSB.Append(FileBegin);
            tempSB.Append(x);
            tempSB.Append(SeparatorForIndex);
            tempSB.Append(timeNow.ToBinary());
            tempSB.Append(SeparatorForDate);
            if (fileName.IndexOf(@"\") < 0)
            {
                folderPath = StoragePath;
            }
            else
            {
                fileName = GetFileName(incorrectFileName);
                string folders = GetSubFolders(incorrectFileName);
                string folderWasCreated = FindNeedSubFolders(folders);
                if (string.IsNullOrEmpty(folderWasCreated))
                {
                    string partOfPath = FolderBegin + tempSB;
                    partOfPath = Path.Combine(partOfPath, folders);
                    folderPath = Path.Combine(StoragePath, partOfPath);
                }
                else
                {
                    folderPath = folderWasCreated;
                }
            }

            tempSB.Append(fileName);
            folderPath = Path.Combine(folderPath, tempSB.ToString());
            Directory.CreateDirectory(folderPath);
            WriteToHistoryTxt(folderPath, fileName, CreateEventText);
            string pathToTxt = Path.Combine(folderPath, TextTxtName);
            string pathFromTxt = Path.Combine(watchingPath, incorrectFileName);
            WriteToTextTxt(pathToTxt, pathFromTxt);
        }

        private static void WriteToHistoryTxt(string folderForWrite, string nameOfFile, string nameOfEvent, string oldName = "")
        {
            StreamWriter sw = new StreamWriter(Path.Combine(folderForWrite, HistoryTxtName), true);
            sw.WriteLine(nameOfEvent);
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(nameOfFile);
            sw.WriteLine(oldName);
            sw.Close();
        }

        private static void RenameFolder(string oldName, string fileName)
        {
            string needFolder = string.Empty;
            if (fileName.IndexOf(@"\") < 0)
            {
                needFolder = FindNeedFolder(oldName);
            }
            else
            {
                string folders = GetSubFolders(oldName);
                needFolder = FindNeedSubFolders(folders);
            }

            if (string.IsNullOrEmpty(needFolder))
            {
                CreateFolder(fileName);
            }
            else
            {
                bool findSub = false;
                string newFolderName = string.Empty;
                if (fileName.IndexOf(@"\") >= 0)
                {
                    oldName = GetFileName(oldName);
                    string[] subFolders = Directory.GetDirectories(needFolder);
                    foreach (var item in subFolders)
                    {
                        if (item.Contains(oldName))
                        {
                            needFolder = item;
                            findSub = true;
                        }
                    }

                    if (!findSub)
                    {
                        CreateFolder(fileName);
                    }
                    else
                    {
                        fileName = GetFileName(fileName);
                        newFolderName = CreateNewStringAfterSeparator(needFolder, fileName, SeparatorForDate, true);
                        Directory.Move(needFolder, newFolderName);
                        WriteToHistoryTxt(newFolderName, fileName, RenameEventText, oldName);
                    }
                }
                else
                {
                    newFolderName = CreateNewStringAfterSeparator(needFolder, fileName, SeparatorForDate, true);
                    Directory.Move(needFolder, newFolderName);
                    WriteToHistoryTxt(newFolderName, fileName, RenameEventText, oldName);
                }
            }
        }

        private static string FindNeedSubFolders(string subFolder)
        {
            List<string> tempList = FoldersInPath();
            string needFolder = string.Empty;
            tempList.Sort();
            foreach (var item in tempList)
            {
                if (item[item.LastIndexOf(@"\") + 1] == FolderBegin[0])
                {
                    List<string> allSubFolders = GetFullSubFolders(item);
                    foreach (var item2 in allSubFolders)
                    {
                        if (item2.IndexOf(subFolder) > 0 && (item2.LastIndexOf(subFolder) + subFolder.Length) == item2.Length)
                        {
                            needFolder = item2;
                            break;
                        }
                    }
                }
            }

            return needFolder;
        }

        private static string FindNeedFolder(string name)
        {
            List<string> tempList = FoldersInPath();
            string needFolder = string.Empty;
            tempList.Sort();
            foreach (var item in tempList)
            {
                if (item.Contains(name))
                {
                    needFolder = item;
                }
            }

            return needFolder;
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
