using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Poke.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace Poke.API.Models
{
    public class User
    {
        public string UserName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        //[EnumDataType(typeof(ClientEnum))]
        public ClientEnum Client { get; set; }

        public User()
        {
        }

        public User(string userName, ClientEnum crm)
        {
            UserName = userName;
            Client = crm;
        }
    }

}
