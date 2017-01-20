namespace ConApp.Model
{
    public class SampleEventArgs
    {
        public SampleEventArgs(string s)
        {
            Text = s;
        }

        public string Text
        {
            get;
            private set;
        }
    }
}