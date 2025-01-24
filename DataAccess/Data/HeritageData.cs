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
        private const string Delete_Procedure = "dbo.spHeritage_Delete";
        private const string Get_CharacteristicType_Options_Procedure = "spHeritage_GetCharacteristicTypeOption";
        private const string Get_Property_Options_Procedure = "spHeritage_GetPropertyOption";
        private const string Get_Feature_Options_Procedure = "spHeritage_GetFeatureOption";

        private ISQLDataAccess access;

        public HeritageData(ISQLDataAccess access)
        {
            this.access = access;
        }

        #region Get Heritages
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
        #endregion

        #region Get Options
        /// <summary>
        /// Gets all entries from the CharacteristicType junction table.
        /// </summary>
        /// <param name="heritageId">Id used to match.</param>
        /// <returns>All options that belong to provided id.</returns>
        public IEnumerable<CharacteristicTypeModel> GetCharacteristicTypeOptions(int heritageId)
        {
            return access.LoadData<CharacteristicTypeModel, dynamic>("", new { heritageId });
        }

        public async Task<IEnumerable<CharacteristicTypeModel>> GetCharacteristicTypeOptionsAsync(int heritageId)
        {
            var result = await access.LoadDataAsync<CharacteristicTypeModel, dynamic>(
                Get_CharacteristicType_Options_Procedure, new { heritageId });
            return result;
        }

        /// <summary>
        /// Gets all entries from the Property junction table.
        /// </summary>
        /// <param name="heritageId">Id used to match.</param>
        /// <returns>All options that belong to provided id.</returns>
        public IEnumerable<PropertyModel> GetPropertyOptions(int heritageId)
        {
            return access.LoadData<PropertyModel, dynamic>(
                Get_Property_Options_Procedure, new { heritageId });
        }

        public async Task<IEnumerable<PropertyModel>> GetPropertyOptionsAsync(int heritageId)
        {
            var result = await access.LoadDataAsync<PropertyModel, dynamic>(
                Get_Feature_Options_Procedure, new { heritageId });
            return result;
        }

        /// <summary>
        /// Gets all entries from the Feature junction table.
        /// </summary>
        /// <param name="heritageId">Id used to match.</param>
        /// <returns>All options that belong to provided id.</returns>
        public IEnumerable<FeatureModel> GetFeatureOptions(int heritageId)
        {
            return access.LoadData<FeatureModel, dynamic>(
                Get_Feature_Options_Procedure, new { heritageId });
        }

        public async Task<IEnumerable<FeatureModel>> GetFeatureOptionsAsync(int heritageId)
        {
            var result = await access.LoadDataAsync<FeatureModel, dynamic>(
                Get_Feature_Options_Procedure,new { heritageId });
            return result;
        }
        #endregion

        #region Get Excluded Options
        //public IEnumerable<CharacteristicTypeModel> 
        //    GetExcludedCharacteristicTypeOptions(int heritageId)
        //{

        //}
        #endregion

        #region Insert
        public void Insert(HeritageModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(HeritageModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }
        #endregion

        #region Update
        public void Update(HeritageModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(HeritageModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
        #endregion

        #region Delete
        public void Delete(HeritageModel model)
        {
            Delete(model.Id);
        }

        public void Delete(int id)
        {
            access.SaveData(Delete_Procedure, new { Id = id });
        }

        public Task DeleteAsync(HeritageModel model)
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
