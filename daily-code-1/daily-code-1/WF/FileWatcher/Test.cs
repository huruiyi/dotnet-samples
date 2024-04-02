using System;
using System.Collections.Generic;
using System.Text;

namespace FileWatcher
{
    class Test
    {
        public static List<int> nums = new List<int>();
        public static Test() 
        {
            nums.Add(1);
        }
        public static void Start()
        {
            System.Windows.Forms.MessageBox.Show("Start");
        }
        public static void Stop()
        {
            System.Windows.Forms.MessageBox.Show("Stop");
        }
    }
}
