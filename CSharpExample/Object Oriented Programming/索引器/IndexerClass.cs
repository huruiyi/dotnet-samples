namespace 索引器
{
    public class IndexerClass : ISomeInterface
    {
        private int[] arr = new int[100];

        public int this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
    }
}