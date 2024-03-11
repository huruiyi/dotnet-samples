using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace MouseKeyHookDemo
{
    class Program
    {
        private IKeyboardMouseEvents _mGlobalHook;

        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            _mGlobalHook = Hook.GlobalEvents();

            _mGlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            _mGlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("KeyPress: \t{0}", e.KeyChar);
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            Console.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);

            // uncommenting the following line will suppress the middle mouse button click
            // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        }

        public void Unsubscribe()
        {
            _mGlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            _mGlobalHook.KeyPress -= GlobalHookKeyPress;

            //It is recommened to dispose it
            _mGlobalHook.Dispose();
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
