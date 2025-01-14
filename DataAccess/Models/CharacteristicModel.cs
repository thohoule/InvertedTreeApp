
namespace DataAccess.Models
{
    public class CharacteristicModel : IElementModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}
