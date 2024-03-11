namespace IOC.V1
{
    internal class DataBaseManager : IDataBaseBll
    {
        private readonly IDataBaseDal _dataBaseDal;

        public DataBaseManager(IDataBaseDal iDataBaseDal)
        {
            _dataBaseDal = iDataBaseDal;
        }

        public void Add(string commandText)
        {
            _dataBaseDal.Insert(commandText);
        }

        public void Remove(string commandText)
        {
            _dataBaseDal.Delete(commandText);
        }

        public void Save(string commandText)
        {
            _dataBaseDal.Update(commandText);
        }

        public void Search(string commandText)
        {
            _dataBaseDal.Select(commandText);
        }
    }
}