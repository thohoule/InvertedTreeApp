﻿using DataAccess.DBAccess;
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
        private const string Get_Excluded_CharacteristicType_Options_Procedure = "spHeritage_GetExcludedCharacteristicTypeOptions";
        private const string Get_Excluded_Property_Options_Procedure = "spHeritage_GetExcludedPropertyOptions";
        private const string Get_Excluded_Feature_Options_Procedure = "spHeritage_GetExcludedFeatureOptions";
        private const string Insert_CharacteristicType_Option_Procedure = "spHeritage_InsertCharacteristicTypeOption";
        private const string Insert_Feature_Option_Procedure = "spHeritage_InsertFeatureOption";
        private const string Insert_Property_Option_Procedure = "spHeritage_InsertPropertyOption";

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
            return access.LoadData<CharacteristicTypeModel, dynamic>(Get_CharacteristicType_Options_Procedure, new { heritageId });
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
        public IEnumerable<CharacteristicTypeModel>
            GetExcludedCharacteristicTypeOptions(int heritageId)
        {
            return access.LoadData<CharacteristicTypeModel, dynamic>(
                Get_Excluded_CharacteristicType_Options_Procedure, new { heritageId });
        }

        public IEnumerable<PropertyModel>
            GetExcludedPropertyOptions(int heritageId)
        {
            return access.LoadData<PropertyModel, dynamic>(
                Get_Excluded_Property_Options_Procedure, new { heritageId });
        }

        public IEnumerable<FeatureModel>
            GetExcludedFeatureOptions(int heritageId)
        {
            return access.LoadData<FeatureModel, dynamic>(
                Get_Excluded_Feature_Options_Procedure, new { heritageId });
        }
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

        public void UpdateCharacteristicTypeOptions(HeritageModel model, 
            IEnumerable<CharacteristicTypeModel> options)
        {
            foreach (var option in options)
            {
                access.SaveData(Insert_CharacteristicType_Option_Procedure,
                    new { HeritageId = model.Id, CharacteristicTypeId = option.Id });
            }
        }

        public void UpdatePropertyOptions(HeritageModel model,
            IEnumerable<PropertyModel> options)
        {
            foreach (var option in options)
            {
                access.SaveData(Insert_Property_Option_Procedure,
                    new { HeritageId = model.Id, PropertyId = option.Id });
            }
        }

        public void UpdateFeatureOptions(HeritageModel model,
            IEnumerable<FeatureModel> options)
        {
            foreach (var option in options)
            {
                access.SaveData(Insert_Feature_Option_Procedure,
                    new { HeritageId = model.Id, FeatureId = option.Id });
            }
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
