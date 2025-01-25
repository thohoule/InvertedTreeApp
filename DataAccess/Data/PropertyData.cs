using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class PropertyData
    {
        private const string Get_Procedure = "dbo.spProperty_Get";
        private const string Get_All_Procedure = "dbo.spProperty_GetAll";
        private const string Insert_Procedure = "dbo.spProperty_Insert";
        private const string Update_Procedure = "dbo.spProperty_Update";
        private const string Delete_Procedure = "dbo.spProperty_Delete";

        private ISQLDataAccess access;

        public PropertyData(ISQLDataAccess access)
        {
            this.access = access;
        }

        #region Get Models
        public IEnumerable<PropertyModel> GetAll()
        {
            return access.LoadData<PropertyModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<PropertyModel>> GetAllAsync()
        {
            return access.LoadDataAsync<PropertyModel, dynamic>(Get_All_Procedure, new { });
        }

        public PropertyModel? Get(int id)
        {
            var result = access.LoadData<PropertyModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<PropertyModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<PropertyModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }
        #endregion

        #region Insert
        public void Insert(PropertyModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Type, model.Description, model.State });
        }

        public Task InsertAsync(PropertyModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }
        #endregion

        #region Update
        public void Update(PropertyModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Type, model.Description, model.State });
        }

        public Task UpdateAsync(PropertyModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
        #endregion

        #region Delete
        public void Delete(PropertyModel model)
        {
            Delete(model.Id);
        }

        public void Delete(int id)
        {
            access.SaveData(Delete_Procedure, new { Id = id });
        }

        public Task DeleteAsync(PropertyModel model)
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
