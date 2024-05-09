﻿using PIS.Common;
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
		string Test();
		Task<Tuple<IEnumerable<UsersDomain>, List<ErrorMessage>>> GetAllUsers();
		IEnumerable<PisUsersMmaturanec> GetAllUsersDb();
		Task<Tuple<UsersDomain, List<ErrorMessage>>> GetUserDomainByUserId(int userId);
		Task<bool> AddUserAsync(UsersDomain userDomain);
		Task<bool> IsValidUser(int id);
	}
}
