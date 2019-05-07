using AutoMapper;
using Teste.Data;
using Teste.Models;
using Teste.Repository.Base;

namespace Teste.Services.Base
{
    public class BaseService<T1, T2> where T1 : BaseEntity where T2 : BaseModel
    {
        protected readonly IBaseRepository<T1,T2> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IBaseRepository<T1,T2> repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
    }
}