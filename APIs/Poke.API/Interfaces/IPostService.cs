using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace Poke.API.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetAll();
    }
}