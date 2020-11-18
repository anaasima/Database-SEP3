using Database_SEP3.Persistence.Model.Build;

namespace Database_SEP3.Persistence.Model
{
    public class BuildComponent
    {
        public int BuildId { get; set; }
        public BuildModel BuildModel { get; set; }
        public int ComponentId { get; set; }
        public ComponentModel ComponentModel { get; set; }
    }
}