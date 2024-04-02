using System;

namespace FileWatcher
{
    [Serializable]
    public class Configuration
    {
        public string Path { get; set; }

        public string Filter { get; set; }

        public string CopyPath { get; set; }

        public bool IsRename { get; set; }

        public bool IsDelete { get; set; }

        public bool IsModify { get; set; }

        public bool IsCreate { get; set; }

        public bool IsAutoRun { get; set; }
    }
}