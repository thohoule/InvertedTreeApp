using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public static class ElementTypeData
    {
        private const string Get_Procedure = "dbo.spElementType_GetByDataName";
        private const string Get_All_Procedure = "dbo.spElementType_GetAll";
        //spElementType_GetAll

        //public static Dictionary<int, string> LoadAll(string connectionString)
        //{
        //    var access = new SQLDataAccess(connectionString);
        //    return LoadAll(access);
        //}

        //public static Dictionary<int, string> LoadAll(SQLDataAccess access)
        //{
        //    var elementTypes = new Dictionary<int, string>();

        //    var assembly = Assembly.GetAssembly(typeof(ElementTypeData));
        //    foreach (var type in assembly.GetTypes())
        //    {
        //        var typeAttribute = type.GetCustomAttributes<ElementTypeAttribute>();

        //        if (typeof(IElementData).IsAssignableFrom(type) &&
        //            typeAttribute != null)
        //        {
        //            var result = access.LoadData<ElementTypeModel, dynamic>(Get_Procedure,
        //                new { type.Name }).FirstOrDefault();

        //            if (result != null)
        //            {
        //                elementTypes.Add(result.Id, result.Name);
        //            }
        //        }
        //    }

        //    return elementTypes;
        //}

        public static List<string> LoadList(SQLDataAccess access)
        {
            return access.LoadData<ElementTypeModel, dynamic>(
                Get_All_Procedure, new { }).OrderBy(item => item.Id).
                Select(item => item.Name).ToList();
        }
    }

    //[AttributeUsage(AttributeTargets.Class)]
    //public class ElementTypeAttribute : Attribute
    //{
    //    public ElementTypeAttribute()
    //    {
    //    }
    //}
}
