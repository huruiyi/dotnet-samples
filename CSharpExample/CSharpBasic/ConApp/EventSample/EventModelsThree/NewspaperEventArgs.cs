using System;

namespace ConApp.EventSample.EventModelsThree
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