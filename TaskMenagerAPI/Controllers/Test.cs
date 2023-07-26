using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskMenagerAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    [Authorize]
    public class Test : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Siemano byki";
        }
    }
}
