using AutoMapper;
using Teste.Data;
using Teste.Repository.Base;

namespace Teste.Services.Base
{
    public class BaseService<T>  where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IBaseRepository<T> repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
    }
}