using System;
using System.Drawing;
using System.IO;

namespace WfApp.Infrastructure
{
    public class FileView
    {
        private string _path;
        private string _name;
        private long _size;
        private DateTime _modified;
        private DateTime _created;
        private string _type;
        private Icon _icon;

        public FileView(string path) : this(new FileInfo(path))
        {
        }

        public FileView(FileSystemInfo fileInfo)
        {
            SetState(fileInfo);
        }

        public bool IsDirectory
        {
            get { return (_size == -1); }
        }

        private void SetState(FileSystemInfo fileInfo)
        {
            _path = fileInfo.FullName;
            _name = fileInfo.Name;

            if (fileInfo is FileInfo)
            {
                _size = (fileInfo as FileInfo).Length;
            }
            else
            {
                _size = -1;
            }

            Modified = fileInfo.LastWriteTime;
            _created = fileInfo.CreationTime;

            SHFILEINFO info = ShellGetFileInfo.GetFileInfo(fileInfo.FullName);

            _type = info.szTypeName;

            _icon = Icon.FromHandle(info.hIcon);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public long Size
        {
            get { return _size; }
        }

        public DateTime DateModified
        {
            get { return Modified; }
        }

        public DateTime DateCreated
        {
            get { return _created; }
        }

        public string Type
        {
            get { return _type; }
        }

        public Icon Icon
        {
            get { return _icon; }
        }

        public void Update()
        {
            SetState(new FileInfo(_path));
        }

        public string FullName
        {
            get { return _path; }
        }

        public DateTime Modified { get => Modified1; set => Modified1 = value; }
        public DateTime Modified1 { get => Modified2; set => Modified2 = value; }
        public DateTime Modified2 { get => _modified; set => _modified = value; }

        public void Update(FileSystemInfo fsi)
        {
            SetState(fsi);
        }
    }
}