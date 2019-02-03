using System;
using System.IO;
using System.Text;

namespace Epam.Task6.BackupSystem
{
    public class KeepTrack 
    {
        private static FileSystemWatcher watcher = new FileSystemWatcher();

        public static void Run()
        {
            string path = Environment.CurrentDirectory + @"\..\..\TestFolder";
            Console.WriteLine($"{Environment.NewLine}Watch for changes in the folder {path}");          

            watcher.Path = path;
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            watcher.Filter = "*.txt";

            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnDelete);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press \'q\' to stop watching.");
            if (Console.ReadKey().Key != ConsoleKey.Q)
            {
                watcher.EnableRaisingEvents = false;
                watcher = null;
            }
        }

        public static string GenerateName(FileSystemEventArgs e, string typeAction)
        {
            string dateTime = $"{DateTime.Now}".Replace(':', '.');
            string path = e.FullPath.Replace("TestFolder", "backups");

            Directory.CreateDirectory(path);
            Directory.Delete(path);

            return path.Replace(".txt", $" {typeAction}.{dateTime}.txt");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            string writePath = Environment.CurrentDirectory + @"\history.txt";

            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                sw.WriteLine($"Date: {DateTime.Now}{Environment.NewLine}File: {e.OldFullPath}{Environment.NewLine}renamed to {e.FullPath}{Environment.NewLine}");
            }

            File.Copy(e.FullPath, GenerateName(e, "Renamed"), false);
        }

        private static void OnDelete(object sender, FileSystemEventArgs e)
        {
            string writePath = Environment.CurrentDirectory + @"\history.txt";

            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                sw.WriteLine($"Date: {DateTime.Now}{Environment.NewLine}Delete File: {e.Name}{Environment.NewLine}File Action: {e.ChangeType}{Environment.NewLine}Delete File from path: {e.FullPath}{Environment.NewLine}");
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                watcher.EnableRaisingEvents = false;

                string writePath = Environment.CurrentDirectory + @"\history.txt";

                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                {
                    sw.WriteLine($"Date: {DateTime.Now}{Environment.NewLine}New File is: {e.Name}{Environment.NewLine}And type: {e.ChangeType}{Environment.NewLine}Path of file: {e.FullPath}{Environment.NewLine}");
                }

                File.Copy(e.FullPath, GenerateName(e, "Created"), false);
            }
            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }
    }
}
