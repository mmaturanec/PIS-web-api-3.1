using Microsoft.AspNetCore.Mvc;
using PIS.Service.Common;
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
		public async Task<string> Test()
		{
			return await _service.Test();
		}
     
	}
}
