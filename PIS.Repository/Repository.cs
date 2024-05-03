using Microsoft.EntityFrameworkCore.ChangeTracking;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Automapper;
using PIS.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Repository
{
	public class Repository :IRepository
	{
		private readonly PIS_DbContext appDbContext;
		private IRepositoryMappingService _mapper;

        public Repository(PIS_DbContext appDbContext, IRepositoryMappingService mapper)
        {
			this.appDbContext = appDbContext;
			_mapper = mapper;
        }
		public string Test()
		{
			return "I am OK - Repository.";
		}
        public IEnumerable<UsersDomain> GetAllUsers()
		{
			IEnumerable<PisUsersMmaturanec> usersDb = appDbContext.PisUsersMmaturanec.ToList();

			IEnumerable<UsersDomain> usersDomain = _mapper.Map<IEnumerable<UsersDomain>>(usersDb);
			return usersDomain;
		}

		public IEnumerable<PisUsersMmaturanec> GetAllUsersDb()
		{
			IEnumerable<PisUsersMmaturanec> userDb = appDbContext.PisUsersMmaturanec.ToList();
			return userDb;
		}
		public UsersDomain GetUserDomainByUserId(int userId)
		{
			PisUsersMmaturanec userDb = appDbContext.PisUsersMmaturanec.Find(userId);

			UsersDomain user = _mapper.Map<UsersDomain>(userDb);

			return user;
		}
		public async Task<bool> AddUserAsync(UsersDomain userDomain)
		{
			try
			{
				EntityEntry<PisUsersMmaturanec> user_created = await appDbContext.PisUsersMmaturanec.AddAsync(
						_mapper.Map<PisUsersMmaturanec>(userDomain));
				await appDbContext.SaveChangesAsync();
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}
		//public async Task<bool> UpdateUserOibAsync(UsersDomain userDomain)
		//{
		//	try
		//	{
		//		PisUsersMmaturanec userDb =await appDbContext.PisUsersMmaturanec.Find(userDomain.UserId);

		//		if(userDb == null)
		//		{
		//		}
		//			return true;
		//	}
		//	catch(Exception ex)
		//	{
		//		return false;
		//	}
		//}

		public async Task<UsersDomain> IsValidUser(int id)
		{
			PisUsersMmaturanec userDb = await appDbContext.PisUsersMmaturanec.FindAsync(id);
			return _mapper.Map<UsersDomain>(userDb);
			
		}
	}
}
