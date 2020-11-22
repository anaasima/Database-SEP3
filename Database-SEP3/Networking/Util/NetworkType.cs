using System;


namespace Database_SEP3.Networking.Util
{
    [Flags]
    public enum NetworkType
    {
        COMPONENTS, BUILDS, LOGIN, REGISTER, CONNECTION
    }
}