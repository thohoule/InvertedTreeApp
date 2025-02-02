﻿using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class TraitData
    {
        private const string Get_Procedure = "dbo.spTrait_Get";
        private const string Get_All_Procedure = "dbo.spTrait_GetAll";
        private const string Insert_Procedure = "dbo.spTrait_Insert";
        private const string Update_Procedure = "dbo.spTrait_Update";
        private const string Delete_Procedure = "dbo.spTrait_Delete";
        private const string Get_Requirements_Procedure = "dbo.spTrait_GetRequirements";

        private ISQLDataAccess access;

        public TraitData(ISQLDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<TraitModel> GetAll()
        {
            return access.LoadData<TraitModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<TraitModel>> GetAllAsync()
        {
            return access.LoadDataAsync<TraitModel, dynamic>(Get_All_Procedure, new { });
        }

        public TraitModel? Get(int id)
        {
            var result = access.LoadData<TraitModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<TraitModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<TraitModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        #region Requirements
        public IEnumerable<RequirementModel> GetRequirements(int traitID)
        {
            return access.LoadData<RequirementModel, dynamic>(
                Get_Requirements_Procedure, new { traitID });
        }
        #endregion

        public void Insert(TraitModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(TraitModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public void Update(TraitModel model)
        {
            access.SaveData(Update_Procedure, new { model.Id, model.Name, model.Description, model.State });
        }

        public Task UpdateAsync(TraitModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }

        #region Delete
        public void Delete(TraitModel model)
        {
            Delete(model.Id);
        }

        public void Delete(int id)
        {
            access.SaveData(Delete_Procedure, new { Id = id });
        }

        public Task DeleteAsync(TraitModel model)
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
