using Business.Service.Abstractions;
using Data.UnitOfWork.Abstractions;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet]
        public  IActionResult Get()
        {
            var user = _userService.GetAllUser();
            
            foreach (var item in user) 
            {
                if (item.UserName == item.InvitedByName)
                {
                    item.InvitedByName = "";
                }
            }
            return Ok(user);
        }
    }
}
