
using Poke.API.Enum;

namespace Poke.API.Interfaces
{
    public interface IEnvironmentVariables
    {
        string GetUrl(EnvironmentSection section, EnvironmentService service);
    }
}
