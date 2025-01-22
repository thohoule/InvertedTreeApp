using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class HeritageData
    {
        private const string Get_Procedure = "dbo.spHeritage_Get";
        private const string Get_All_Procedure = "dbo.spHeritage_GetAll";
        private const string Insert_Procedure = "dbo.spHeritage_Insert";
        private const string Update_Procedure = "dbo.spHeritage_Update";

        private ISQLDataAccess access;

        public HeritageData(ISQLDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<HeritageModel> GetAll()
        {
            return access.LoadData<HeritageModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<HeritageModel>> GetAllAsync()
        {
            return access.LoadDataAsync<HeritageModel, dynamic>(Get_All_Procedure, new { });
        }

        public HeritageModel? Get(int id)
        {
            var result = access.LoadData<HeritageModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<HeritageModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<HeritageModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public void Insert(HeritageModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(HeritageModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public void Update(HeritageModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(HeritageModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
    }
}
