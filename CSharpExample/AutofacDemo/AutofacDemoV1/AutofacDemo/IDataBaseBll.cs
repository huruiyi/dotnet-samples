namespace AutofacDemo
{
    public interface IDataBaseBll
    {
        void Add(string commandText);

        void Remove(string commandText);

        void Save(string commandText);

        void Search(string commandText);
    }
}