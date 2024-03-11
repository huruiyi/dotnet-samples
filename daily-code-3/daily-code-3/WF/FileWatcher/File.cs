namespace FileWatcher
{
    internal class File
    {
        public File()
        {
        }

        public File(string name, string fullName)
        {
            this.Name = name;
            this.FullName = fullName;
        }

        public string Name { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}