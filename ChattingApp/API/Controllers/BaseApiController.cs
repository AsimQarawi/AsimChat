using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //  if the parameters is sent in the url query i can use the normal format for the function
    //  ex: public async Task<ActionResult<User>> Register(string username, string password)
    //  if the parameters is sent in the body i sould use DTOs
    public class BaseApiController : ControllerBase
    {

    }
}

