using DataAccess;
using DataAccess.Data;
using DataAccess.DBAccess;
using DataAccess.Models;
using System.Collections.Generic;

namespace InvertedTreeApp
{
    public class DataManager
    {
        private SQLDataAccess access;
        private List<string> elementTypes;
        private RaceData raceData;
        private HeritageData heritageData;

        private static DataManager _instace;
        private static DataManager instance { get => _instace ?? (_instace = new DataManager()); }

        public static IReadOnlyList<string> ElementTypes { get => instance.elementTypes; }

        public static RaceData RaceData { get => instance.raceData; }
        public static HeritageData HeritageData { get => instance.heritageData; }

        private DataManager()
        {
            access = new SQLDataAccess(ConnectionInfo.Connection_String);
            elementTypes = ElementTypeData.LoadList(access);
            raceData = new RaceData(access);
            heritageData = new HeritageData(access);
        }
    }
}
