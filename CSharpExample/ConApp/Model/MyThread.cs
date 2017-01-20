using System.Threading;

namespace ConApp.Model
{
    public class MyThread
    {
        public ParameterizedThreadStart CallBackFunc { get; set; }

        public MyThread(ParameterizedThreadStart start)
        {
            CallBackFunc = start;
        }

        public void Start(object obj)
        {
            CallBackFunc(obj);
        }
    }
}