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
        private const string Get_Excluded_Options_Procedure = "sRace_GetExcludedHeritageOptions";
        private const string Insert_Hetitage_Option_Procedure = "spRace_InsertHeritageOption";

        private ISQLDataAccess access;

        public RaceData(ISQLDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<RaceModel> GetAll()
        {
            var items = access.LoadData<RaceModel, dynamic>(Get_All_Procedure, new { });

            foreach (var item in items)
                SetHeritageOptions(item);

            return items;
        }

        public async Task<IEnumerable<RaceModel>> GetAllAsync()
        {
            var items = await access.LoadDataAsync<RaceModel, dynamic>(Get_All_Procedure, new {  });

            foreach (var item in items)
                await SetHeritageOptionsAsync(item);

            return items;
        }

        public RaceModel? Get(int id)
        {
            var item = access.LoadData<RaceModel, dynamic>(
                Get_Procedure, new { id }).FirstOrDefault();

            if (item != null)
                SetHeritageOptions(item);

            return item;
        }

        public async Task<RaceModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<RaceModel, dynamic>(Get_Procedure, new { id });
            var item = result.FirstOrDefault();

            if (item != null)
                await SetHeritageOptionsAsync(item);

            return item;
        }

        public IEnumerable<HeritageModel> GetHeritageOptions(int raceID)
        {
            var result = access.LoadData<HeritageModel, dynamic>(
                Get_Options_Procedure, new { raceID });

            return result;
        }

        public async Task<IEnumerable<HeritageModel>> GetHeritageOptionsAsync(int raceID)
        {
            var result = await access.LoadDataAsync<HeritageModel, dynamic>(
                Get_Options_Procedure, new { raceID });

            return result;
        }

        public void SetHeritageOptions(RaceModel model)
        {
            model.HeritageOptions = new List<HeritageModel>(GetHeritageOptions(model.Id));
        }

        public async Task SetHeritageOptionsAsync(RaceModel model)
        {
            var options = await GetHeritageOptionsAsync(model.Id);

            model.HeritageOptions = new List<HeritageModel>(options);
        }

        public IEnumerable<HeritageModel> GetExcludedHeritageOptions(int raceID)
        {
            var result = access.LoadData<HeritageModel, dynamic>(
                Get_Excluded_Options_Procedure, new { raceID });

            return result;
        }

        public void UpdateHeritageOptions(RaceModel race, IEnumerable<HeritageModel> options)
        {
            foreach (var item in options)
            {
                var option = new HeritageOption(race, item);
                access.SaveData(Insert_Hetitage_Option_Procedure,
                    new { option.RaceID, option.HeritageID });
            }
        }

        public void Insert(RaceModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, 
                model.State });
        }

        public Task InsertAsync(RaceModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public void Update(RaceModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(RaceModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
    }
}
