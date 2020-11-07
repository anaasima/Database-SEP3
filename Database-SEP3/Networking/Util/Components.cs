namespace Database_SEP3.Networking.Util
{
    public class Components : NetworkPackage
    {
        
        public string toString()
        {
            return getType() + ": ";
        }

        public Components(NetworkType type) : base(type)
        {
            
        }
    }
}