using System.Collections.Generic;

namespace Database_SEP3.Persistence.Model.Build
{
    public class BuildList
    {
        private List<BuildModel> _list;
        
        public BuildList()
        {
            _list = new List<BuildModel>();
        }

        public void AddBuild(BuildModel buildModel)
        {
            _list.Add(buildModel);
        }

        public void RemoveBuild(BuildModel buildModel)
        {
            _list.Remove(buildModel);
        }

        public int Size()
        {
            return _list.Count;
        }
        
        public override string ToString()
        {
            string s = "";
            foreach (var VARIABLE in _list)
            {
                s += VARIABLE.ToString();
            }

            return s;
        }
    }
}