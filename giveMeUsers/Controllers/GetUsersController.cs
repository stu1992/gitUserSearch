using giveMeUsers.HTTPClients;
using giveMeUsers.Models;
using giveMeUsers.Services;
using Microsoft.AspNetCore.Mvc;

namespace giveMeUsers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetUsersController : ControllerBase
    {
        private readonly ILogger<GetUsersController> _logger;
        private readonly IUserService _service;

        public GetUsersController(ILogger<GetUsersController> logger)
        {
            _logger = logger;
            _service = new UserService(new GithubClient());
        }

        [HttpGet(Name = "GetUser")]
        public ResponseUser[] Get([FromQuery] string[] user)
        {
            List<ResponseUser> response =  _service.getUser(user).Result;
            return response.ToArray() ;
        }
    }
}