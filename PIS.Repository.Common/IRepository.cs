using PIS.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIS.Repository.Common
{
	public interface IRepository
	{
		IQueryable<PisUsersMmaturanec> GetAllUsers();
	}
}
