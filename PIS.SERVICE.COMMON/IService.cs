using PIS.DAL.DataModel;
using PIS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Service.Common
{
	public interface IService
	{
		List<PisUsersMmaturanec> GetAllUsers();
		Task<string> Test();
		//List<UserDomain> GetAllUsers();
	}
}
