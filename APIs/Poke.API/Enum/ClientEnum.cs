using System.Runtime.Serialization;

namespace Poke.API.Enum
{
              
    public enum ClientEnum
    {
        [EnumMember(Value = "de2p-primary")]
        DE2P = 1,
        [EnumMember(Value = "orig")]
        ORIG = 2,
        [EnumMember(Value = "odb")]
        ODB = 3,
        [EnumMember(Value = "sor-json")]
        SOR = 4
    }
}
