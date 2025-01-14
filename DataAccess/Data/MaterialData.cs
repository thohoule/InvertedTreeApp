using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess
{
    public class MaterialData
    {
        private const string Get_Procedure = "dbo.spMaterial_Get";
        private const string Get_All_Procedure = "dbo.spMaterial_GetAll";
        private const string Insert_Procedure = "dbo.spMaterial_Insert";
        private const string Update_Procedure = "dbo.spMaterial_Update";

        private ISQLDataAccess access;

        public MaterialData(ISQLDataAccess access)
        {
            this.access = access;
        }

        public IEnumerable<MaterialModel> GetAll()
        {
            return access.LoadData<MaterialModel, dynamic>(Get_All_Procedure, new { });
        }

        public Task<IEnumerable<MaterialModel>> GetAllAsync()
        {
            return access.LoadDataAsync<MaterialModel, dynamic>(Get_All_Procedure, new { });
        }

        public MaterialModel? Get(int id)
        {
            var result = access.LoadData<MaterialModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public async Task<MaterialModel?> GetAsync(int id)
        {
            var result = await access.LoadDataAsync<MaterialModel, dynamic>(Get_Procedure, new { id });
            return result.FirstOrDefault();
        }

        public void Insert(MaterialModel model)
        {
            access.SaveData(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public Task InsertAsync(MaterialModel model)
        {
            return access.SaveDataAsync(Insert_Procedure, new { model.Name, model.Description, model.State });
        }

        public void Update(MaterialModel model)
        {
            access.SaveData(Update_Procedure, model);
        }

        public Task UpdateAsync(MaterialModel model)
        {
            return access.SaveDataAsync(Update_Procedure, model);
        }
    }
}
