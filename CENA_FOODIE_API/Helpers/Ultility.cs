using CENA_FOODIE_API.Entities;
using CENA_FOODIE_API.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Services
{
    public static class Ultility
    {
        public static T[] MappingDynamicToT<T>(dynamic[] data)
        {
            T[] res = new T[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i] = JsonConvert.DeserializeObject<T>(data[i].ToString());
            }
            return res;
        }

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
