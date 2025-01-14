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

        private static DataManager _instace;
        private static DataManager instance { get => _instace ?? (_instace = new DataManager()); }

        public static IReadOnlyList<string> ElementTypes { get => instance.elementTypes; }
        public static RaceData RaceData { get => instance.raceData; }

        private DataManager()
        {
            access = new SQLDataAccess(ConnectionInfo.Connection_String);
            elementTypes = ElementTypeData.LoadList(access);
            raceData = new RaceData(access);
        }
    }
}
