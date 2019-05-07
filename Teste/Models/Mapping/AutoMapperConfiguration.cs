using System;
using AutoMapper;
using Teste.Data;

namespace Teste.Models.Mapping
{
    public class AutoMapperConfiguration
    {
       public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });         
        }
    }
}