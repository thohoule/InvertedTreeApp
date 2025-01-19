
namespace DataAccess.Models
{
    public interface IElementBase
    {
        int Id { get; set; }
        string Name { get; set; }
        string? Description { get; set; }
        int State { get; set; }
    }
}
