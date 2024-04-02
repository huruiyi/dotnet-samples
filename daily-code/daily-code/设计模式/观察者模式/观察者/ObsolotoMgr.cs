namespace 观察者
{
    public delegate void DObs();

    public class ObsolotoMgr
    {
        public static event DObs objHandler;

        public static void Action()
        {
            if (objHandler != null)
            {
                objHandler.Invoke();
            }
        }
    }
}