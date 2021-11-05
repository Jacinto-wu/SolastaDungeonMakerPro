using System;
using System.IO;
using System.Linq;

namespace SolastaDungeonMakerPro.Models
{
    public static class ContentBackupContext
    {
        const string BACKUP_FOLDER = "Backup";

        public static void BackupAndDelete(string path, UserContent userContent)
        {
            var backupDirectory = Path.Combine(Main.MOD_FOLDER, BACKUP_FOLDER);

            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            var title = userContent.Title;
            var compliantTitle = IOHelper.GetOsCompliantFilename(title);
            var destinationPath = Path.Combine(backupDirectory, compliantTitle) + "." + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            var backupFiles = Directory.EnumerateFiles(backupDirectory, compliantTitle + "*").ToList();

            backupFiles.Sort();
            
            for (var i = 0; i <= backupFiles.Count - Main.Settings.maxBackupFiles; i++)
            {
                File.Delete(backupFiles[i]);
            }

            File.Copy(path, destinationPath);
            File.Delete(path);
        }
    }
}