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
        private const string Delete_Procedure = "dbo.spCharacteristic_Delete";
        private const string Get_Feature_Options_Procedure = "spCharacteristic_GetFeatureOptions";
        private const string Get_Excluded_Feature_Options_Procedure = "spCharacteristic_GetExcludedFeatureOptions";

        private ISQLDataAccess access;

        public CharacteristicData(ISQLDataAccess access)
        {
            this.access = access;
        }

        #region Get Characteristics
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
        #endregion

        #region Get Options
        public IEnumerable<FeatureModel> GetFeatureOptions(int characteristicId)
        {
            return access.LoadData<FeatureModel, dynamic>(
                Get_Feature_Options_Procedure, new { characteristicId });
        }

        public async Task<IEnumerable<FeatureModel>> GetFeatureOptionsAsync(int characteristicId)
        {
            return await access.LoadDataAsync<FeatureModel, dynamic>(
                Get_Feature_Options_Procedure, new { characteristicId });
        }
        #endregion

        #region Get Excluded Otions
        public IEnumerable<FeatureModel> GetExcludedFeatureOptions(int characteristicId)
        {
            return access.LoadData<FeatureModel, dynamic>(
                Get_Excluded_Feature_Options_Procedure, new { characteristicId });
        }
        #endregion

        #region Insert
        public void Insert(CharacteristicModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(CharacteristicModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }
        #endregion

        #region Upgrade
        public void Update(CharacteristicModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(CharacteristicModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
        #endregion

        #region Delete
        public void Delete(CharacteristicModel model)
        {
            Delete(model.Id);
        }

        public void Delete(int id)
        {
            access.SaveData(Delete_Procedure, new { Id = id });
        }

        public Task DeleteAsync(CharacteristicModel model)
        {
            return DeleteAsync(model.Id);
        }

        public Task DeleteAsync(int id)
        {
            return access.SaveDataAsync(Delete_Procedure, new { Id = id });
        }
        #endregion
    }
}
