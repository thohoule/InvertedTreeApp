using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class CharacteristicTypeData
    {
        private const string Get_Procedure = "dbo.spCharacteristicType_Get";
        private const string Get_All_Procedure = "dbo.spCharacteristicType_GetAll";
        private const string Insert_Procedure = "dbo.spCharacteristicType_Insert";
        private const string Update_Procedure = "dbo.spCharacteristicType_Update";
        private const string Delete_Procedure = "dbo.spCharacteristicType_Delete";

        private ISQLDataAccess access;

        public CharacteristicTypeData(ISQLDataAccess access)
        {
            this.access = access;
        }

        #region Get Models
        public IEnumerable<CharacteristicTypeModel> GetAll()
        {
            return access.LoadData<CharacteristicTypeModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<CharacteristicTypeModel>> GetAllAsync()
        {
            return access.LoadDataAsync<CharacteristicTypeModel, dynamic>(Get_All_Procedure, new { });
        }

        public CharacteristicTypeModel? Get(int id)
        {
            var result = access.LoadData<CharacteristicTypeModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<CharacteristicTypeModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<CharacteristicTypeModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }
        #endregion

        #region Insert
        public void Insert(CharacteristicTypeModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(CharacteristicTypeModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }
        #endregion

        #region Update
        public void Update(CharacteristicTypeModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(CharacteristicTypeModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
        #endregion

        #region Delete
        public void Delete(CharacteristicTypeModel model)
        {
            Delete(model.Id);
        }

        public void Delete(int id)
        {
            access.SaveData(Delete_Procedure, new { Id = id });
        }

        public Task DeleteAsync(CharacteristicTypeModel model)
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
