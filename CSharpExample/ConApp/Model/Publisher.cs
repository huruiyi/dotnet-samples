namespace ConApp.Model
{
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