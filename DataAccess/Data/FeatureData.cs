using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class FeatureData
    {
        private const string Get_Procedure = "dbo.spFeature_Get";
        private const string Get_All_Procedure = "dbo.spFeature_GetAll";
        private const string Insert_Procedure = "dbo.spFeature_Insert";
        private const string Update_Procedure = "dbo.spFeature_Update";
        private const string Delete_Procedure = "dbo.spFeature_Delete";

        private ISQLDataAccess access;

        public FeatureData(ISQLDataAccess access)
        {
            this.access = access;
        }

        #region Get Models
        public IEnumerable<FeatureModel> GetAll()
        {
            return access.LoadData<FeatureModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<FeatureModel>> GetAllAsync()
        {
            return access.LoadDataAsync<FeatureModel, dynamic>(Get_All_Procedure, new { });
        }

        public FeatureModel? Get(int id)
        {
            var result = access.LoadData<FeatureModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<FeatureModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<FeatureModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }
        #endregion

        #region Insert
        public void Insert(FeatureModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(FeatureModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }
        #endregion

        #region Update
        public void Update(FeatureModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(FeatureModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
        #endregion

        #region Delete
        public void Delete(FeatureModel model)
        {
            Delete(model.Id);
        }

        public void Delete(int id)
        {
            access.SaveData(Delete_Procedure, new { Id = id });
        }

        public Task DeleteAsync(FeatureModel model)
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
