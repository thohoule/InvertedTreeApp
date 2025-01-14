using DataAccess.Models;

namespace DataAccess
{
    public interface IElementData
    { }

    public interface IElementData<TModel> : IElementData
        where TModel : class, IElementModel
    {
        TModel? Get(int id);
        IEnumerable<TModel> GetAll();
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel?> GetAsync(int id);
        void Insert(TModel model);
        Task InsertAsync(TModel model);
        void Update(TModel model);
        Task UpdateAsync(TModel model);
    }
}