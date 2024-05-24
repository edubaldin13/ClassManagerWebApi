using System.Net;
using class_management_web_api.src.Requests;
using Microsoft.AspNetCore.Mvc;
namespace class_management_web_api.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        public RegisterController(){

        }
        [HttpPost]
        public Task<HttpStatusCode> RegisterUser([FromBody] RegisterPostRequest request)
        {
            return null;
        }
    }
}