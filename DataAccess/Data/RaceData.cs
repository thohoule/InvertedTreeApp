using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class RaceData
    {
        private const string Get_Procedure = "dbo.spRace_Get";
        private const string Get_All_Procedure = "dbo.spRace_GetAll";
        private const string Insert_Procedure = "dbo.spRace_Insert";
        private const string Update_Procedure = "dbo.spRace_Update";
        private const string Get_Options_Procedure = "spRace_GetHeritageOption";

        private ISQLDataAccess access;

        public RaceData(ISQLDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<RaceModel> GetAll()
        {
            return access.LoadData<RaceModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<RaceModel>> GetAllAsync()
        {
            return access.LoadDataAsync<RaceModel, dynamic>(Get_All_Procedure, new {  });
        }

        public RaceModel? Get(int id)
        {
            var result = access.LoadData<RaceModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<RaceModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<RaceModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public IEnumerable<HeritageModel> GetHeritageOptions(int id)
        {
            var result = access.LoadData<HeritageModel, dynamic>(
                Get_Options_Procedure, new { id });

            return result;
        }

        public void Insert(RaceModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(RaceModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public void Update(RaceModel model)
        {
            access.SaveData(Update_Procedure, model);
        }

        public Task UpdateAsync(RaceModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
    }
}
