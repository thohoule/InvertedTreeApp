
namespace DataAccess.DBAccess
{
    public interface ISQLDataAccess
    {
        IEnumerable<TItem> LoadData<TItem, TParameter>(string storedProcedure,
            TParameter parameters, string connectionID = "Default");
        Task<IEnumerable<TItem>> LoadDataAsync<TItem, TParameter>(string storedProcedure, TParameter parameters, string connectionID = "Default");
        public void SaveData<TItem>(string storedProcedure,
            TItem parameters, string connectionID = "Default");
        Task SaveDataAsync<TItem>(string storedProcedure, TItem parameters, string connectionID = "Default");
    }
}