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
        private CharacteristicData characteristicData;
        private TraitData traitData;
        private AbilityData abilityData;
        private MaterialData materialData;
        private CharacteristicTypeData characteristicTypeData;
        private PropertyData propertyData;
        private FeatureData featureData;

        private static DataManager _instace;
        private static DataManager instance { get => _instace ?? (_instace = new DataManager()); }

        internal static RaceData RaceData { get => instance.raceData; }
        internal static HeritageData HeritageData { get => instance.heritageData; }
        internal static CharacteristicData CharacteristicData { get => instance.characteristicData; }
        internal static TraitData TraitData { get => instance.traitData; }
        internal static AbilityData AbilityData { get => instance.abilityData; }
        internal static MaterialData MaterialData { get => instance.materialData; }
        internal static CharacteristicTypeData CharacteristicTypeData { get => instance.characteristicTypeData; }
        internal static PropertyData PropertyData { get => instance.propertyData; }
        internal static FeatureData FeatureData { get => instance.featureData; }

        public static IReadOnlyList<string> ElementTypes => instance.elementTypes;

        private DataManager()
        {
            access = new SQLDataAccess(ConnectionInfo.Connection_String);
            elementTypes = ElementTypeData.LoadList(access);
            raceData = new RaceData(access);
            heritageData = new HeritageData(access);
            characteristicData = new CharacteristicData(access);
            traitData = new TraitData(access);
            abilityData = new AbilityData(access);
            materialData = new MaterialData(access);
        }

        /// <summary>
        /// Loads all race models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<RaceModel, RaceProxy> GetAllRaces()
        {
            var proxySet = new ProxySet<RaceModel, RaceProxy>(
                RaceData.GetAll());
            //proxySet.AddRangeTo(RaceData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all heritage models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<HeritageModel, HeritageProxy> GetAllHeritages()
        {
            var proxySet = new ProxySet<HeritageModel, HeritageProxy>(
                HeritageData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all characteristic models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<CharacteristicModel, CharacteristicProxy> GetAllCharacteristics()
        {
            var proxySet = new ProxySet<CharacteristicModel, CharacteristicProxy>(
                CharacteristicData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all trait models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<TraitModel, TraitProxy> GetAllTraits()
        {
            var proxySet = new ProxySet<TraitModel, TraitProxy>(
                TraitData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all ability models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<AbilityModel, AbilityProxy> GetAllAbilities()
        {
            var proxySet = new ProxySet<AbilityModel, AbilityProxy>(
                AbilityData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all material models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<MaterialModel, MaterialProxy> GetAllMaterials()
        {
            var proxySet = new ProxySet<MaterialModel, MaterialProxy>(
                MaterialData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all characteristic type models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<CharacteristicTypeModel, CharacteristicTypeProxy> GetAllCharacteristicTypes()
        {
            var proxySet = new ProxySet<CharacteristicTypeModel, CharacteristicTypeProxy>(
                CharacteristicTypeData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all property models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<PropertyModel, PropertyProxy> GetAllProperties()
        {
            var proxySet = new ProxySet<PropertyModel, PropertyProxy>(
                PropertyData.GetAll());

            return proxySet;
        }

        /// <summary>
        /// Loads all feature models then wraps each in a proxy. 
        /// </summary>
        /// <returns>A Proxy Set contraining all loaded proxies of the type.</returns>
        public static ProxySet<FeatureModel, FeatureProxy> GetAllFeatures()
        {
            var proxySet = new ProxySet<FeatureModel, FeatureProxy>(
                FeatureData.GetAll());

            return proxySet;
        }
    }
}
