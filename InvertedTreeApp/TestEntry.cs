using DataAccess;
using DataAccess.DBAccess;
using DataAccess.Models;

namespace InvertedTreeApp
{
    public static class TestEntry
    {
        private const string connectionString = "Data Source=OUROBOROS\\SQLEXPRESS;Initial Catalog=InvertedTreeDB;Integrated Security=True;TrustServerCertificate=True";

        public static void TestInsert()
        {
            SQLDataAccess dataAccess = new SQLDataAccess(connectionString);

            RaceModel human = new RaceModel()
            {
                Name = "Human",
                Description = "Can't see in the dark.",
            };

            RaceModel fey = new RaceModel()
            {
                Name = "Fey",
            };

            RaceData raceData = new RaceData(dataAccess);
            raceData.Insert(human);
            raceData.Insert(fey);
        }
    }
}
