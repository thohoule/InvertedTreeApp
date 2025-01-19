using DataAccess.Models;

namespace DataAccess
{
    public interface IElementProxy : IElementBase
    {
        bool IsEdited { get; }
        string DisplayName { get; }
    }
}
