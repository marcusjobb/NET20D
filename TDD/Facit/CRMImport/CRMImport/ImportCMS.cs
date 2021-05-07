namespace CRMImport
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Newtonsoft.Json;

    public partial class ImportCMS
    {
        public static List<Person> Import(string json)
        {
            if (json == null) return new List<Person>();
            var import = JsonConvert.DeserializeObject<Person[]>(json);
            var People = new List<Person>();
            try
            {
                foreach (var person in import)
                {
                    var existing = People.Find(i => i.guid == person.guid);
                    if (existing == null && People != null)
                    {
                        People.Add(person);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return People;
        }
    }
}