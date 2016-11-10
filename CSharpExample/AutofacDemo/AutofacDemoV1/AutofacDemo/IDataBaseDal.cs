namespace AutofacDemo
{
    public interface IDataBaseDal
    {
        string Name { get; }

        void Select(string commandText);

        void Delete(string commandText);

        void Update(string commandText);

        void Insert(string commandText);
    }
}