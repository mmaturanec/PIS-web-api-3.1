using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIS.Common;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Service;
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
		private int _requestUserId;

		public HomeController(IService service)
		{
			_service = service;
			_requestUserId = -1;
		}
		[HttpGet]
		[Route("test")]
		public string Test()
		{
			return _service.Test();
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
		public async Task<Tuple<IEnumerable<UsersDomain>, List<ErrorMessage>>> GetAllUsers()
		{
			Tuple<IEnumerable<UsersDomain>, List<ErrorMessage>> result =  await _service.GetAllUsers();

			return result;
			
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
			bool lastrequestId = await GetLastUserRequestId();

			if (!lastrequestId)
			{
				return BadRequest("Nije unesen RequestUserId korisnika koji poziva.");

			}
			else
			{

				try
				{
					if (!ModelState.IsValid)
					{
						return BadRequest(ModelState);
					}
					else
					{
						UsersDomain userDomain = new UsersDomain();
						userDomain.UserLoginName = userRest.UserLoginName;
						userDomain.UserName = userRest.UserName;
						userDomain.UserSurname = userRest.UserSurname;

						bool add_user = await _service.AddUserAsync(userDomain);

						if (add_user)
						{

							return Ok("User dodan!");
						}
						else
						{
							return Ok("User nije dodan!");
						}
					}

				}
				catch (Exception e)
				{
					return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
				}
			}

		}
		#region AdditionalCustomFunctions
		public async Task<bool> GetLastUserRequestId()
		{
			IHeaderDictionary headers = this.Request.Headers;
			if (headers.ContainsKey("RequestUserId"))
			{
				if (int.TryParse(headers["RequestUserId"].ToString(), out _requestUserId))
				{
					return await _service.IsValidUser(_requestUserId);
					//return true;
				}
				else return false;
			}
			return false;

		}
		#endregion AdditionalCustomFunctions
	}
}
