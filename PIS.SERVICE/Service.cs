using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;
using PIS.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Service
{
	public class Service : IService
	{
		IRepository _repository;

        public Service(IRepository repository)
        {
			repository = _repository;
        }
        public List<PisUsersMmaturanec> GetAllUsers()
		{
			List<PisUsersMmaturanec> users = _repository.GetAllUsers().ToList();

			if(users == null)
			{

				throw new Exception("no users found");
			}
			else
			{ 
				return users;

			}
		}

		public Task<string> Test()
		{
			return "test";
		}
	}
}
