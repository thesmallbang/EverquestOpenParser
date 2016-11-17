using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenParser
{
    public class LogFile
    {
        public LogFile(string path, bool watch, bool fromBeginning = false)
        {
            Path = path;
            Watched = watch;
            Character = ParseCharacterName(path);
            Server = ParseServerName(path);

            if (!fromBeginning)
                LastLineNumber = File.ReadAllLines(path).Length;

            if (watch)
                Watch();
        }

        public string Path { get; }
        public bool Watched { get; }
        public string Character { get; private set; }
        public string Server { get; private set; }

        /// <summary>
        ///     Last line number parsed. Used to get only recent changes
        /// </summary>
        private int LastLineNumber { get; set; }

        private FileSystemWatcher FileWatcher { get; } = new FileSystemWatcher();

        public event EventHandler<IEnumerable<LogEntry>> OnChanged;


        private string ParseCharacterName(string path)
        {
            try
            {
                return path.Split('_')[1];
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }

        private string ParseServerName(string path)
        {
            try
            {
                return path.Split('_')[2].Replace(".txt", "");
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }

        private void TriggerChanged(IEnumerable<LogEntry> logLines)
        {
            OnChanged?.Invoke(this, logLines);
        }


        public void Watch()
        {
            if (Watched)
                EndWatch();

            FileWatcher.Path = System.IO.Path.GetDirectoryName(Path);
            FileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            FileWatcher.Filter = System.IO.Path.GetFileName(Path);
            FileWatcher.Changed += FileWatcherOnChanged;
            FileWatcher.EnableRaisingEvents = true;
        }

        private void FileWatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            ReadChanges();
        }

        public void EndWatch()
        {
            if (!Watched)
                return;

            FileWatcher.EnableRaisingEvents = false;
        }

        public void ReadChanges()
        {
            var changes = GetEntries().ToList();

            LastLineNumber += changes.Count;
            TriggerChanged(changes);
        }


        //add specific method for reading larger amounts of data so sequence of changes can be maintained by event handlers
        public void ReadChangesByLine()
        {
            var changes = GetEntries().ToList();

            LastLineNumber += changes.Count;

            foreach (var change in changes)
                TriggerChanged(new List<LogEntry> {change});
        }

        private IEnumerable<LogEntry> GetEntries()
        {
            var changes =
                File.ReadLines(Path)
                    .Skip(LastLineNumber)
                    .Select(LogEntry.Create)
                    .Where(o => !string.IsNullOrEmpty(o.Raw));

            return changes;
        }
    }
}