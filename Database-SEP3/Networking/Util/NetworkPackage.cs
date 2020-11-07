namespace Database_SEP3.Networking.Util
{
    public class NetworkPackage
    {
        private NetworkType type;

        public NetworkPackage(NetworkType type)
        {
            this.type = type;
        }

        public NetworkType getType()
        {
            return type;
        }
    }
}