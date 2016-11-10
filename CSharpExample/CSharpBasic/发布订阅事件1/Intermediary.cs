using System;

namespace 发布订阅事件1
{
    // 中介
    internal class Intermediary
    {
        public string Name;

        public Intermediary(string name)
        {
            Name = name;
        }

        // 获取新的工作信息的时候
        public void ReceiveNewJobMessage(string message)
        {
            // 通知每一个求职者
            if (OnNewJobReceive != null)
            {
                OnNewJobReceive(this, new NewJobMessageEventArgs(message));
            }
        }

        public event EventHandler<NewJobMessageEventArgs> OnNewJobReceive;
    }
}