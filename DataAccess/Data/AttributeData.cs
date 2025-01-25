using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class AttributeData
    {
        private const string Get_Procedure = "dbo.spAttribute_Get";
        private const string Get_All_Procedure = "dbo.spAttribute_GetAll";
        private const string Insert_Procedure = "dbo.spAttribute_Insert";
        private const string Update_Procedure = "dbo.spAttribute_Update";
        private const string Delete_Procedure = "dbo.spAttribute_Delete";

        private ISQLDataAccess access;

        public AttributeData(ISQLDataAccess access)
        {
            this.access = access;
        }

        #region Get Attributes
        public IEnumerable<AttributeModel> GetAll()
        {
            return access.LoadData<AttributeModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<AttributeModel>> GetAllAsync()
        {
            return access.LoadDataAsync<AttributeModel, dynamic>(Get_All_Procedure, new { });
        }

        public AttributeModel? Get(int id)
        {
            var result = access.LoadData<AttributeModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<AttributeModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<AttributeModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }
        #endregion

        #region Insert
        public void Insert(AttributeModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(AttributeModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }
        #endregion

        #region Update
        public void Update(AttributeModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(AttributeModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
        #endregion

        #region Delete
        public void Delete(AttributeModel model)
        {
            Delete(model.Id);
        }

        public void Delete(int id)
        {
            access.SaveData(Delete_Procedure, new { Id = id });
        }

        public Task DeleteAsync(AttributeModel model)
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
