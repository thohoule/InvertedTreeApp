using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class CharacteristicData
    {
        private const string Get_Procedure = "dbo.spCharacteristic_Get";
        private const string Get_All_Procedure = "dbo.spCharacteristic_GetAll";
        private const string Insert_Procedure = "dbo.spCharacteristic_Insert";
        private const string Update_Procedure = "dbo.spCharacteristic_Update";

        private ISQLDataAccess access;

        public CharacteristicData(ISQLDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<CharacteristicModel> GetAll()
        {
            return access.LoadData<CharacteristicModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<CharacteristicModel>> GetAllAsync()
        {
            return access.LoadDataAsync<CharacteristicModel, dynamic>(Get_All_Procedure, new { });
        }

        public CharacteristicModel? Get(int id)
        {
            var result = access.LoadData<CharacteristicModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<CharacteristicModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<CharacteristicModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public void Insert(CharacteristicModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(CharacteristicModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public void Update(CharacteristicModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(CharacteristicModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
    }
}
