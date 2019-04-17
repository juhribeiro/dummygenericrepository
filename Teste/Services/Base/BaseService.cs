using AutoMapper;
using Teste.Repository.Base;

namespace Teste.Services.Base
{
    public class BaseService
    {
        protected readonly IBaseRepository _repository;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IBaseRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
    }
}