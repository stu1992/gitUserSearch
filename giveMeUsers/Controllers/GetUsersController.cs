using giveMeUsers.HTTPClients;
using giveMeUsers.Models;
using giveMeUsers.Services;
using Microsoft.AspNetCore.Mvc;

namespace giveMeUsers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class retrieveUsersController : ControllerBase
    {
        private readonly ILogger<retrieveUsersController> _logger;
        private readonly IUserService _service;

        public retrieveUsersController(ILogger<retrieveUsersController> logger)
        {
            _logger = logger;
            _service = new UserService(new GithubClient());
        }

        [HttpGet(Name = "retrieveUsers")]
        public ResponseUser[] Get([FromQuery] string[] user)
        {
            List<ResponseUser> response =  _service.getUser(user).Result;
            return response.ToArray() ;
        }
    }
}