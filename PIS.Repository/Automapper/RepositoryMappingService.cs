using AutoMapper;
using PIS.DAL.DataModel;
using PIS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Repository.Automapper
{
	public class RepositoryMappingService : IRepositoryMappingService
	{

		public Mapper mapper;

        public RepositoryMappingService()
        {
			var config = new MapperConfiguration(
				cfg =>
				{
					cfg.CreateMap<PisUsersMmaturanec, UsersDomain>();
				});
			mapper = new Mapper(config);
        }
        public TDestination Map<TDestination>(object source)
		{
			return mapper.Map<TDestination>(source);
		}
	}
}
