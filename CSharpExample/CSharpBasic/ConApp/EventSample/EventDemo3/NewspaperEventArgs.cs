using System;

namespace ConApp.EventSample.EventDemo3
{
    public class NewspaperEventArgs : EventArgs
    {
        public string Content { get; set; }

        public NewspaperEventArgs()
        {
        }

        public NewspaperEventArgs(string content)
        {
            Content = content;
        }
    }
}