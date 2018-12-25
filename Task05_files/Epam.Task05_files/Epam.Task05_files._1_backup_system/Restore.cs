using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task05_files._1_backup_system
{
    public static class Restore
    {
        private const string SeparatorForIndex = FileStorage.SeparatorForIndex;
        private const string SeparatorForDate = FileStorage.SeparatorForDate;
        private const string SeparatorForNumberOfLine = FileStorage.SeparatorForNumberOfLine;
        private const string FolderBegin = FileStorage.FolderBegin;
        private const string DeletedEventText = FileStorage.DeletedEventText;
        private const string FileHistory = FileStorage.FileHistory;
        private const string FileContent = FileStorage.FileContent;
        private static string storagePath = FileStorage.StoragePath;
        private static Dictionary<string, DateTime> foldersInStorage;

        public static string WatchgerPath
        {
            get;
            set;
        }

        public static DateTime Date
        {
            get;
            set;
        }

        public static bool DoRestore()
        {
            foldersInStorage = new Dictionary<string, DateTime>();
            string[] folders = Directory.GetDirectories(storagePath);
            foreach (var item in folders)
            {
                foldersInStorage.Add(item, GetDateTimeFromFolderName(item));
            }

            bool needResfresh = true;
            foreach (var item in foldersInStorage)
            {
                if (item.Value < Date)
                {
                    if (needResfresh)
                    {
                        RefreshWatcherFolder();
                        needResfresh = false;
                    }

                    if (FindFirstSymbolAfterStorageName(item.Key) != FolderBegin)
                    {
                        string fullPath = Path.Combine(item.Key, FileHistory);
                        string fileName = GetFileNameFromHistoryInDate(fullPath);
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            var createFile = File.Create(Path.Combine(WatchgerPath, fileName));
                            createFile.Close();
                            fullPath = Path.Combine(item.Key, FileContent);
                            if (File.Exists(fullPath))
                            {
                                string[] contentLines = GetFileContentInDate(fullPath);
                                File.WriteAllLines(Path.Combine(WatchgerPath, fileName), contentLines);
                            }
                        }
                    }
                    else
                    {
                        List<string> allSubFolders = FileStorage.GetFullSubFolders(item.Key);
                        foreach (var subItem in allSubFolders)
                        {
                            if (subItem.LastIndexOf(".txt") == subItem.Length - 4)
                            {
                                string fullPath = Path.Combine(subItem, FileHistory);
                                string fileName = GetFileNameFromHistoryInDate(fullPath);
                                if (!string.IsNullOrEmpty(fileName))
                                {
                                    string subFolders = GetSubFoldersInStoragePath(subItem);
                                    string fullWatchingPathWithSubFolders = Path.Combine(WatchgerPath, subFolders);
                                    Directory.CreateDirectory(fullWatchingPathWithSubFolders);
                                    var createFile = File.Create(Path.Combine(fullWatchingPathWithSubFolders, fileName));
                                    createFile.Close();
                                    fullPath = Path.Combine(subItem, FileContent);
                                    if (File.Exists(fullPath))
                                    {
                                        string[] contentLines = GetFileContentInDate(fullPath);
                                        File.WriteAllLines(Path.Combine(fullWatchingPathWithSubFolders, fileName), contentLines);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        private static DateTime GetDateTimeFromFolderName(string folderName)
        {
            int startIndex = folderName.IndexOf(SeparatorForIndex) + 1;
            int length = folderName.IndexOf(SeparatorForDate) - startIndex;
            if (startIndex < 0 || length < 0)
            {
                throw new ArgumentException("Problem with storage");
            }

            string subString = folderName.Substring(startIndex, length);
            DateTime date = DateTime.FromBinary(long.Parse(subString));
            return date;
        }

        private static string GetFileNameFromHistoryInDate(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                return string.Empty;
            }

            string[] allText = File.ReadAllLines(fullPath);
            string fileName = string.Empty;
            for (int i = 1; i < allText.Length; i += 4)
            {
                if (DateTime.Parse(allText[i]) < Date)
                {
                    if (allText[i - 1] != DeletedEventText)
                    {
                        fileName = allText[i + 1];
                        continue;
                    }
                    else
                    {
                        fileName = string.Empty;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return fileName;
        }

        private static int GetNumberOfLine(string line)
        {
            int end = line.IndexOf(SeparatorForNumberOfLine);
            string number = line.Substring(0, end);
            return int.Parse(number);
        }

        private static string GetTextInALine(string line)
        {
            int start = line.IndexOf(SeparatorForNumberOfLine);
            string text = line.Substring(start + 1, line.Length - start - 1);
            return text;
        }

        private static string[] GetFileContentInDate(string fullPath)
        {
            string[] allLines = File.ReadAllLines(fullPath);
            string[] lines = new string[allLines.Length];
            for (int i = 0; i < allLines.Length; i++)
            {
                if (allLines[i].IndexOf(SeparatorForNumberOfLine) < 0)
                {
                    if (DateTime.Parse(allLines[i]) < Date)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    int number = GetNumberOfLine(allLines[i]);
                    lines[number] = GetTextInALine(allLines[i]);
                }
            }

            return lines;
        }

        private static void RefreshWatcherFolder()
        {
            DirectoryInfo di = new DirectoryInfo(WatchgerPath);
            foreach (var item in di.GetFiles())
            {
                item.Delete();
            }

            foreach (var item in di.GetDirectories())
            {
                item.Delete(true);
            }
        }

        private static string FindFirstSymbolAfterStorageName(string path)
        {
            int start = path.LastIndexOf(storagePath);
            char symbol = path[start + storagePath.Length];
            return symbol.ToString();
        }

        private static string GetSubFoldersInStoragePath(string path)
        {
            int start1 = path.LastIndexOf(storagePath) + storagePath.Length;
            string tempString = path.Substring(start1, path.Length - start1);
            int start2 = tempString.IndexOf(@"\");
            int start = start1 + start2;
            int end = path.LastIndexOf(@"\");
            string subFolder = path.Substring(start + 1, end - start - 1);
            return subFolder;
        }
    }
}
