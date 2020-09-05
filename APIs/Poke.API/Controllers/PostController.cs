using System.Threading.Tasks;
using BasicEssentials;
using Microsoft.AspNetCore.Mvc;

namespace Poke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public PostController()
        {
                
        }
        
        [HttpGet]
        public IActionResult GetPosts()
        {
            var client = new ClientHttp();
            var response = client.GetSmp();
            return Ok(response);
        }
    }
}