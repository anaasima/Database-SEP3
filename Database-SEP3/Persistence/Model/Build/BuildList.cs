using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Database_SEP3.Persistence.Model.Build
{
    public class BuildList
    {   
        [JsonPropertyName("builds")]
        public IList<BuildModel> Builds { get; set; }
        
        public BuildList()
        {
            Builds = new List<BuildModel>();
        }

        public void AddBuild(BuildModel buildModel)
        {
            Builds.Add(buildModel);
        }

        public void RemoveBuild(BuildModel buildModel)
        {
            Builds.Remove(buildModel);
        }

        public int Size()
        {
            return Builds.Count;
        }

        public BuildModel Get(int index)
        {
            return Builds[index];
        }
        
        public override string ToString()
        {
            string s = "";
            foreach (var VARIABLE in Builds)
            {
                s += VARIABLE.ToString();
            }

            return s;
        }
    }
}