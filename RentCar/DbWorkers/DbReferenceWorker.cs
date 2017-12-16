using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DbWorkers
{
    public static class DbReferenceWorker
    {
        public static List<ReferenceValue> GetCityReference()
        {
            return GetReferenceValues("City", "Name");
        }

        public static List<ReferenceValue> GetModelReference()
        {
            return GetReferenceValues("Model", "Name");
        }

        public static List<ReferenceValue> GetMarkReference()
        {
            return GetReferenceValues("Mark", "Name");
        }

        public static List<ReferenceValue> GetTypeReference()
        {
            return GetReferenceValues("Type", "Name");
        }

        public static List<ReferenceValue> GetAreaReference(string city)
        {
            return GetReferenceValues("Area", "Name", string.Format("[City] = '{0}'", city));
        }

        public static List<ReferenceValue> GetAdditionalServiceReference()
        {
            return GetReferenceValues("AdditionalService", "Name");
        }

        public static List<ReferenceValue> GetSexReference()
        {
            return GetReferenceValues("Sex", "Name");
        }

        private static List<ReferenceValue> GetReferenceValues(string name, string column, string search = "")
        {
            using (var context = new Db.OpenRentEntities())
            {
                var query = string.Format(@"SELECT Id, {1} FROM [Reference].[{0}]", name, column);
                if (!string.IsNullOrEmpty(search))
                {
                    query += string.Format(" WHERE {0}", search);
                }

                var reference = context.Database.SqlQuery<ReferenceValue>(query).OrderBy(x => x.Name).ToList();

                return reference;
            }
        }
    }
}
