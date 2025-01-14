﻿using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class AbilityData : IElementData<AbilityModel>
    {
        private const string Get_Procedure = "dbo.spAbility_Get";
        private const string Get_All_Procedure = "dbo.spAbility_GetAll";
        private const string Insert_Procedure = "dbo.spAbility_Insert";
        private const string Update_Procedure = "dbo.spAbility_Update";

        private ISQLDataAccess access;

        public AbilityData(ISQLDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<AbilityModel> GetAll()
        {
            return access.LoadData<AbilityModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<AbilityModel>> GetAllAsync()
        {
            return access.LoadDataAsync<AbilityModel, dynamic>(Get_All_Procedure, new { });
        }

        public AbilityModel? Get(int id)
        {
            var result = access.LoadData<AbilityModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<AbilityModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<AbilityModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public void Insert(AbilityModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(AbilityModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public void Update(AbilityModel model)
        {
            access.SaveData(Update_Procedure, model);
        }

        public Task UpdateAsync(AbilityModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
    }
}
