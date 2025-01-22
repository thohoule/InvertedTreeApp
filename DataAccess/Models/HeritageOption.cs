
namespace DataAccess.Models
{
    internal struct HeritageOption
    {
        public int RaceID { get; private set; }
        public int HeritageID { get; private set; }

        public HeritageOption(RaceModel race, HeritageModel heritage) :
            this(race.Id, heritage.Id)
        { }

        public HeritageOption(int raceID, int heritageID)
        {
            RaceID = raceID;
            HeritageID = heritageID;
        }
    }
}
