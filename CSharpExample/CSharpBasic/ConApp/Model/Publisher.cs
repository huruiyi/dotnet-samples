namespace ConApp.Model
{
    public class SampleEventArgs
    {
        public SampleEventArgs(string s)
        {
            Text = s;
        }

        public string Text { get; }
    }

    public class Publisher
    {
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        public event SampleEventHandler SampleEvent;

        protected virtual void RaiseSampleEvent()
        {
            if (SampleEvent != null)
                SampleEvent(this, new SampleEventArgs("Hello"));
        }
    }
}