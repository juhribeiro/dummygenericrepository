using AutoMapper;
using Teste.Data;

namespace Teste.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.ViceVersa<Category, CategoryEntity>();
        }

        private void ViceVersa<T1, T2>()
        {
            this.CreateMap<T1, T2>();
            this.CreateMap<T2, T1>();
        }
    }
}