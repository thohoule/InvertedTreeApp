
namespace DataAccess.Models
{
    public class RaceModel : IElementModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }

        public string DisplayName { get; set; }

        public List<HeritageModel> HeritageOptions { get; set; }
    }
}
