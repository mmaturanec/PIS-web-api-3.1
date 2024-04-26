using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Service.Common;
using PIS.WebAPI.RESTModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.WebAPI.Controllers
{
	[Route("pis")]
	public class HomeController : Controller
	{
		protected IService _service { get; private set; }
        public HomeController(IService service)
        {
            _service = service;
        }
		[HttpGet]
		[Route("test")]
		public string Test()
		{
			return  _service.Test();
		}
		[HttpGet]
		[Route("Users_db")]
		public IEnumerable<PisUsersMmaturanec> GetAllUsersDb()
		{
			IEnumerable<PisUsersMmaturanec> userDb = _service.GetAllUsersDb();

			return userDb;
		}
		[HttpGet]
		[Route("Users")]
		public List<UsersDomain> GetAllUsers()
		{
			List<UsersDomain> users = (List<UsersDomain>)_service.GetAllUsers();

			return users;
		}
		[HttpGet]
		[Route("Users/user_id/{userid}")]
		public UsersDomain GeetUserDomainByUserId(int userId)
		{
			UsersDomain userDomain = _service.GetUserDomainByUserId(userId);
			return userDomain;
		}
		[HttpPost]
		[Route("add")]
		public async Task<IActionResult> AddUserAsync([FromBody] UsersDomain userRest)
		{
			try
			{

				UsersDomain userDomain = new UsersDomain();
				userDomain.UserLoginName = userRest.UserLoginName;
				userDomain.UserName = userRest.UserName;
				userDomain.UserSurname = userRest.UserSurname;

				bool add_user = await _service.AddUserAsync(userDomain);

				if(add_user)
				{
					return Ok("User dodan!");
				}
				else
				{
					return Ok("User nije dodan!");
				}
			}
			catch(Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
			}

		}
     
	}
}
