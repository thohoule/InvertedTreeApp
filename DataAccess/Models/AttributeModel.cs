
namespace DataAccess.Models
{
    public class AttributeModel : IElementModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}