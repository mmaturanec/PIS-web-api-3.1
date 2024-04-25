using PIS.DAL.DataModel;
using PIS.Repository.Automapper;
using PIS.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public IQueryable<PisUsersMmaturanec> GetAllUsers()
		{
			return appDbContext.PisUsersMmaturanec.AsQueryable();
		}
	}
}
