using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace PTM.PHDomain
{
    public class DTOMapper
    {
        private IMapper _mapper;
        private IMapper Mapper => _mapper ?? (_mapper = _config.CreateMapper());

        private IConfigurationProvider _config;

        
        public DTOMapper()
        {

            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionListItem, QuestionAPIItem>();
            });
        }

        public void Map(object source, object dest)
        {
            Mapper.Map(source, dest, source.GetType(), dest.GetType());
        }

        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
