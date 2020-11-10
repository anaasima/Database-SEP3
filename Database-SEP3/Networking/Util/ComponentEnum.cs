namespace Database_SEP3.Networking.Util
{
    public class ComponentEnum : NetworkPackage
    {
        
        public string toString()
        {
            return getType() + "";
        }

        public ComponentEnum(NetworkType type) : base(type)
        {
            base.getType();
        }
    }
}