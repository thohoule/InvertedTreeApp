using DataAccess.Data;
using DataAccess.DBAccess;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess
{
    public class DataManager
    {
        private SQLDataAccess access;
        private List<string> elementTypes;
        private RaceData raceData;
        private HeritageData heritageData;

        private static DataManager _instace;
        private static DataManager instance { get => _instace ?? (_instace = new DataManager()); }

        internal static RaceData RaceData { get => instance.raceData; }
        internal static HeritageData HeritageData { get => instance.heritageData; }

        public static IReadOnlyList<string> ElementTypes => instance.elementTypes;

        private DataManager()
        {
            access = new SQLDataAccess(ConnectionInfo.Connection_String);
            elementTypes = ElementTypeData.LoadList(access);
            raceData = new RaceData(access);
            heritageData = new HeritageData(access);
        }

        public static ProxySet<RaceModel, RaceProxy> GetAllRaces()
        {
            var proxySet = new ProxySet<RaceModel, RaceProxy>(
                RaceData.GetAll());
            //proxySet.AddRangeTo(RaceData.GetAll());

            return proxySet;
        }

        public static ProxySet<HeritageModel, HeritageProxy> GetAllHeritages()
        {
            var proxySet = new ProxySet<HeritageModel, HeritageProxy>(
                HeritageData.GetAll());
            //proxySet.AddRangeTo(HeritageData.GetAll());

            return proxySet;
        }
    }
}
