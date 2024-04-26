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
			 _repository = repository;
        }
		public string Test()
		{
			return _repository.Test();
		}
		public IEnumerable<UsersDomain> GetAllUsers()
		{
			List<UsersDomain> users = _repository.GetAllUsers().ToList();

			if(users == null)
			{

				throw new Exception("no users found");
			}
			else
			{ 
				return users;

			}
		}

		public IEnumerable<PisUsersMmaturanec> GetAllUsersDb()
		{
			IEnumerable<PisUsersMmaturanec> userDb = _repository.GetAllUsersDb();
			return userDb;
		}

		IEnumerable<UsersDomain> IService.GetAllUsers()
		{
			return _repository.GetAllUsers();
		}

		public UsersDomain GetUserDomainByUserId(int userId)
		{
			return _repository.GetUserDomainByUserId(userId);
		}

		public async Task<bool> AddUserAsync(UsersDomain userDomain)
		{
			return await _repository.AddUserAsync(userDomain);
		}
	}
}
