using System;

namespace 发布订阅事件1
{
    internal class NewJobMessageEventArgs : EventArgs
    {
        public string Message;

        public NewJobMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}